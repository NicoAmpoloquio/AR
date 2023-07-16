using System;
using System.Collections.Generic;
using Attendance_Models;
using Attendance_BusinessRules;
using Attendance_DataLayer;

namespace Program
{
    internal class Program
    {
        static void Main(string[] args)
        {
            InMemoryData.InMemoryStudents();

            AttendanceRecorder recorder = new AttendanceRecorder();

            Console.WriteLine("Welcome to the Attendance Recorder Program!");
            Console.WriteLine("-------------------------------------------");

            while (true)
            {
                Console.WriteLine("\nPlease select an option:");
                Console.WriteLine("1. Add attendance");
                Console.WriteLine("2. Edit attendance");
                Console.WriteLine("3. View student's attendance");
                Console.WriteLine("4. View all students' attendance");
                Console.WriteLine("5. Exit");

                string input = Console.ReadLine();
                Console.WriteLine();

                switch (input)
                {
                    case "1":
                        AddAttendanceUI(recorder);
                        break;
                    case "2":
                        EditAttendanceUI(recorder);
                        break;
                    case "3":
                        ViewStudentAttendanceUI(recorder);
                        break;
                    case "4":
                        ViewAllStudentsAttendanceUI(recorder);
                        break;
                    case "5":
                        Console.WriteLine("Exiting program...");
                        return;
                    default:
                        Console.WriteLine("Invalid option selected, please try again.");
                        break;
                }
            }
        }

        static void AddAttendanceUI(AttendanceRecorder recorder)
        {
            Console.WriteLine("Enter student details:");
            Console.Write("Student number: ");
            string number = Console.ReadLine();

            Console.Write("Student name: ");
            string name = Console.ReadLine();

            Console.WriteLine("Select attendance status:");
            Console.WriteLine("1. Present");
            Console.WriteLine("2. Absent");
            Console.WriteLine("3. Excused");

            int statusOption;
            if (!int.TryParse(Console.ReadLine(), out statusOption) || statusOption < 1 || statusOption > 3)
            {
                Console.WriteLine("Invalid option selected.");
                return;
            }

            AttendanceStatus status = (AttendanceStatus)(statusOption - 1);

            bool success = recorder.AddAttendance(number, name, status);
            if (success)
            {
                Console.WriteLine("Attendance added successfully.");
            }
            else
            {
                Console.WriteLine("Failed to add attendance. Student does not exist.");
            }
        }

        static void EditAttendanceUI(AttendanceRecorder recorder)
        {
            Console.Write("Enter student number: ");
            string number = Console.ReadLine();

            Console.Write("Enter student name: ");
            string name = Console.ReadLine();

            List<AttendanceRecord> studentAttendance = recorder.GetStudentAttendance(number, name);

            if (studentAttendance == null)
            {
                Console.WriteLine("Student does not exist.");
                return;
            }

            Console.WriteLine("Select attendance to edit:");

            for (int i = 0; i < studentAttendance.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {studentAttendance[i].DateTime} - {studentAttendance[i].Status}");
            }

            Console.Write("Enter the attendance index to edit: ");
            int attendanceIndex;
            if (!int.TryParse(Console.ReadLine(), out attendanceIndex) || attendanceIndex < 1 || attendanceIndex > studentAttendance.Count)
            {
                Console.WriteLine("Invalid option selected.");
                return;
            }

            Console.WriteLine("Select new attendance status:");
            Console.WriteLine("1. Present");
            Console.WriteLine("2. Absent");
            Console.WriteLine("3. Excused");

            int statusOption;
            if (!int.TryParse(Console.ReadLine(), out statusOption) || statusOption < 1 || statusOption > 3)
            {
                Console.WriteLine("Invalid option selected.");
                return;
            }

            AttendanceStatus newStatus = (AttendanceStatus)(statusOption - 1);

            bool success = recorder.EditAttendance(number, name, attendanceIndex, newStatus);
            if (success)
            {
                Console.WriteLine("Attendance updated successfully.");
            }
            else
            {
                Console.WriteLine("Failed to update attendance. Invalid option selected or student does not exist.");
            }
        }

        static void ViewStudentAttendanceUI(AttendanceRecorder recorder)
        {
            Console.Write("Enter student number: ");
            string number = Console.ReadLine();

            Console.Write("Enter student name: ");
            string name = Console.ReadLine();

            List<AttendanceRecord> studentAttendance = recorder.GetStudentAttendance(number, name);

            if (studentAttendance == null)
            {
                Console.WriteLine("Student does not exist.");
                return;
            }

            Console.WriteLine($"Attendance for {name} ({number}):");

            foreach (AttendanceRecord attendance in studentAttendance)
            {
                Console.WriteLine($"{attendance.DateTime} - {attendance.Status}");
            }
        }

        static void ViewAllStudentsAttendanceUI(AttendanceRecorder recorder)
        {
            List<AttendanceRecord> attendanceRecords = recorder.GetAllStudentsAttendance();

            if (attendanceRecords.Count == 0)
            {
                Console.WriteLine("No attendance records available.");
                return;
            }

            Console.WriteLine("Attendance Records");
            Console.WriteLine("-----------------");

            foreach (AttendanceRecord attendance in attendanceRecords)
            {
                Console.WriteLine($"{attendance.Student.StudentName} ({attendance.Student.StudentNumber}):");
                Console.WriteLine($"{attendance.DateTime} - {attendance.Status}");
                Console.WriteLine();
            }
        }

    }
}