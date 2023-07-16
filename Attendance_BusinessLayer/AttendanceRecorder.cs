using System;
using System.Collections.Generic;
using Attendance_Models;
using Attendance_DataLayer;

namespace Attendance_BusinessRules
{
    public class AttendanceRecorder
    {
        public bool AddAttendance()
        {
            Console.WriteLine("Enter student details:");
            Console.Write("Student number: ");
            string number = Console.ReadLine();

            Console.Write("Student name: ");
            string name = Console.ReadLine();

            List<Student> students = AttendanceData.GetStudents();
            Student student = students.Find(s => s.StudentNumber == number && s.StudentName == name);

            if (student == null)
            {
                Console.WriteLine("Student does not exist.");
                return false;
            }

            Console.WriteLine("Select attendance status:");
            Console.WriteLine("1. Present");
            Console.WriteLine("2. Absent");
            Console.WriteLine("3. Excused");

            int statusOption;
            if (!int.TryParse(Console.ReadLine(), out statusOption) || statusOption < 1 || statusOption > 3)
            {
                Console.WriteLine("Invalid option selected.");
                return false;
            }

            AttendanceStatus status = (AttendanceStatus)(statusOption - 1);

            AttendanceRecord attendance = new AttendanceRecord
            {
                Student = student,
                Status = status,
                DateTime = DateTime.Now
            };

            AttendanceData.AddAttendanceRecord(attendance);
            Console.WriteLine("Attendance added successfully.");
            return true;
        }

        public bool EditAttendance()
        {
            Console.Write("Enter student number: ");
            string number = Console.ReadLine();

            Console.Write("Enter student name: ");
            string name = Console.ReadLine();

            List<Student> students = AttendanceData.GetStudents();
            Student student = students.Find(s => s.StudentNumber == number && s.StudentName == name);

            if (student == null)
            {
                Console.WriteLine("Student does not exist.");
                return false;
            }

            Console.WriteLine("Select attendance to edit:");
            List<AttendanceRecord> studentAttendance = AttendanceData.GetAttendanceRecords().FindAll(a => a.Student == student);

            for (int i = 0; i < studentAttendance.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {studentAttendance[i].DateTime} - {studentAttendance[i].Status}");
            }

            int attendanceIndex;
            if (!int.TryParse(Console.ReadLine(), out attendanceIndex) || attendanceIndex < 1 || attendanceIndex > studentAttendance.Count)
            {
                Console.WriteLine("Invalid option selected.");
                return false;
            }

            Console.WriteLine("Select new attendance status:");
            Console.WriteLine("1. Present");
            Console.WriteLine("2. Absent");
            Console.WriteLine("3. Excused");

            int statusOption;
            if (!int.TryParse(Console.ReadLine(), out statusOption) || statusOption < 1 || statusOption > 3)
            {
                Console.WriteLine("Invalid option selected.");
                return false;
            }

            AttendanceStatus newStatus = (AttendanceStatus)(statusOption - 1);

            studentAttendance[attendanceIndex - 1].Status = newStatus;
            Console.WriteLine("Attendance updated successfully.");
            return true;
        }

        public void ViewStudentAttendance()
        {
            Console.Write("Enter student number: ");
            string number = Console.ReadLine();

            Console.Write("Enter student name: ");
            string name = Console.ReadLine();

            List<Student> students = AttendanceData.GetStudents();
            Student student = students.Find(s => s.StudentNumber == number && s.StudentName == name);

            if (student == null)
            {
                Console.WriteLine("Student does not exist.");
                return;
            }

            Console.WriteLine($"Attendance for {student.StudentName} ({student.StudentNumber}):");

            List<AttendanceRecord> studentAttendance = AttendanceData.GetAttendanceRecords().FindAll(a => a.Student == student);

            foreach (AttendanceRecord attendance in studentAttendance)
            {
                Console.WriteLine($"{attendance.DateTime} - {attendance.Status}");
            }
        }

        public void ViewAllStudentsAttendance()
        {
            List<Student> students = AttendanceData.GetStudents();
            List<AttendanceRecord> attendanceRecords = AttendanceData.GetAttendanceRecords();

            if (attendanceRecords.Count == 0)
            {
                Console.WriteLine("No attendance records available.");
                return;
            }

            Console.WriteLine("Attendance Records");
            Console.WriteLine("-----------------");

            foreach (Student student in students)
            {
                Console.WriteLine($"{student.StudentName} ({student.StudentNumber}):");

                List<AttendanceRecord> studentAttendance = attendanceRecords.FindAll(a => a.Student == student);

                foreach (AttendanceRecord attendance in studentAttendance)
                {
                    Console.WriteLine($"{attendance.DateTime} - {attendance.Status}");
                }

                Console.WriteLine();
            }
        }
    }
}
