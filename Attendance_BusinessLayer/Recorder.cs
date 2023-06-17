using System;
using System.Collections.Generic;
using Attendance_DataLayer;
using Attendance_Models;
using Attendance_UserInterface;

namespace Attendance_BusinessLayer
{
    public class AttendanceManager
    {
        public static void RecordAttendance()
        {
            string studentName = UserInterfaceRecord.GetStudentName();

            StudentAttendanceRecord studentRecord = Students.StudentList.Find(record => record.StudentName == studentName);

            if (studentRecord == null)
            {
                UserInterfaceRecord.DisplayInvalidStudentNameMessage();
                return;
            }

            string statusChoice = UserInterfaceRecord.GetAttendanceStatus();
            string attendanceStatus;

            switch (statusChoice)
            {
                case "1":
                    attendanceStatus = "Present";
                    break;
                case "2":
                    attendanceStatus = "Absent";
                    break;
                case "3":
                    attendanceStatus = "Excused";
                    break;
                default:
                    UserInterfaceRecord.DisplayInvalidChoiceMessage();
                    return;
            }

            DateTime currentTime = DateTime.Now;

            studentRecord.StudentList.Add(new RecordDateTime(currentTime, attendanceStatus));
            UserInterfaceRecord.DisplayAttendanceMarkedMessage();
        }
        public static void ViewAttendanceRecordsByStudent()
        {
            string studentName = UserInterfaceRecord.GetStudentName();

            StudentAttendanceRecord studentRecord = Students.StudentList.Find(record => record.StudentName == studentName);

            if (studentRecord == null)
            {
                UserInterfaceView.DisplayNoRecordsFoundMessage();
                return;
            }

            UserInterfaceView.DisplayAttendanceRecords(studentName, studentRecord.StudentList);
        }
        public static void ViewAttendanceRecordsForAllStudents()
        {
            Console.WriteLine("Attendance records for all students:");

            if (Students.StudentList.Count == 0)
            {
                Console.WriteLine("No attendance records found for any student.");
                return;
            }

            foreach (var student in Students.StudentList)
            {
                Console.WriteLine($"Student: {student.StudentName}");
                foreach (var record in student.StudentList)
                {
                    Console.WriteLine($"Date: {record.Time.ToShortDateString()}, Time: {record.Time.ToShortTimeString()}, Status: {record.Status}");
                }
                Console.WriteLine();
            }
        }
        public static void EditAttendance()
        {
            Console.Write("Enter student name: ");
            string studentName = Console.ReadLine();

            StudentAttendanceRecord studentRecord = Students.StudentList.Find(record => record.StudentName == studentName);

            if (studentRecord == null)
            {
                Console.WriteLine("No attendance records found for this student.");
                return;
            }

            Console.WriteLine($"Attendance records for {studentName}:");
            for (int i = 0; i < studentRecord.StudentList.Count; i++)
            {
                var record = studentRecord.StudentList[i];
                Console.WriteLine($"{i + 1}. Date: {record.Time.ToShortDateString()}, Time: {record.Time.ToShortTimeString()}, Status: {record.Status}");
            }

            Console.Write("Enter the number of the record you want to edit: ");
            string recordChoice = Console.ReadLine();

            if (!int.TryParse(recordChoice, out int recordIndex) || recordIndex < 1 || recordIndex > studentRecord.StudentList.Count)
            {
                Console.WriteLine("Invalid record number! Attendance not edited.");
                return;
            }
            else
            {
                Console.WriteLine("Select new attendance status:");
                Console.WriteLine("1. Present");
                Console.WriteLine("2. Absent");
                Console.WriteLine("3. Excused");
                Console.Write("Enter your choice: ");
                string statusChoice = Console.ReadLine();

                string attendanceStatus;

                switch (statusChoice)
                {
                    case "1":
                        attendanceStatus = "Present";
                        break;
                    case "2":
                        attendanceStatus = "Absent";
                        break;
                    case "3":
                        attendanceStatus = "Excused";
                        break;
                    default:
                        Console.WriteLine("Invalid choice! Attendance not edited.");
                        return;
                }
                DateTime currentTime = DateTime.Now;

                studentRecord.StudentList.Add(new RecordDateTime(currentTime, attendanceStatus));
            }

            Console.WriteLine("Attendance edited successfully.");
        }
    }
}

