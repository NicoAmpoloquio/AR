//using Attendance_DataLayer;
//using Attendance_Models;
//using System;
//using System.Collections.Generic;

//namespace Attendance
//{
//    public class UserInterfaceMenu
//    {
//        public static void DisplayMainTitle()
//        {
//            Console.WriteLine("Attendance is a Must, attendance muna bago umalis mga ya.");
//            Console.WriteLine("-------------------------------------------");
//        }
//        public static void DisplayMainMenu()
//        {
//            Console.WriteLine("\nPlease select an option:");
//            Console.WriteLine("1. Record attendance");
//            Console.WriteLine("2. View attendance records by student");
//            Console.WriteLine("3. View attendance records for all students");
//            Console.WriteLine("4. Edit attendance records");
//            Console.WriteLine("5. Exit");
//            Console.Write("Enter your choice: ");
//        }
//        public static void DisplayExitMessage()
//        {
//            Console.WriteLine("Bounce program na par...");
//        }

//        public static void DisplayInvalidChoiceMessage()
//        {
//            Console.WriteLine("Invalid choice, please try again.");
//        }
//    }
//    public class UserInterfaceRecord
//    {
//        public static string GetStudentName()
//        {
//            Console.Write("Enter student name: ");
//            return Console.ReadLine();
//        }
//        public static string GetAttendanceStatus()
//        {
//            Console.WriteLine("Select attendance status:");
//            Console.WriteLine("1. Present");
//            Console.WriteLine("2. Absent");
//            Console.WriteLine("3. Excused");
//            Console.Write("Enter your choice: ");
//            return Console.ReadLine();
//        }
//        public static void DisplayInvalidStudentNameMessage()
//        {
//            Console.WriteLine("Invalid student name! Attendance not marked.");
//        }
//        public static void DisplayInvalidChoiceMessage()
//        {
//            Console.WriteLine("Invalid choice! Attendance not marked.");
//        }
//        public static void DisplayAttendanceMarkedMessage()
//        {
//            Console.WriteLine("Attendance marked successfully.");
//        }
//        public static void DisplayPresent()
//        {
//            Console.WriteLine("Present");
//        }
//        public static void DisplayAbsent()
//        {
//            Console.WriteLine("Absent");
//        }
//        public static void DisplayExcused()
//        {
//            Console.WriteLine("Excused");
//        }
//    }
//    public class UserInterfaceView
//    {
//        public static void DisplayNoRecordsFoundMessage()
//        {
//            Console.WriteLine("No attendance records found for this student.");
//        }

//        public static void DisplayAttendanceRecords(string studentName, List<RecordDateTime> records)
//        {
//            Console.WriteLine($"Attendance records for {studentName}:");
//            foreach (var record in records)
//            {
//                Console.WriteLine($"Date: {record.Time.ToShortDateString()}, Time: {record.Time.ToShortTimeString()}, Status: {record.Status}");
//            }
//        }
//        public static void ViewAttendanceRecordsByStudent()
//        {
//            string studentName = UserInterfaceRecord.GetStudentName();

//            StudentAttendanceRecord studentRecord = Students.StudentList.Find(record => record.StudentName == studentName);

//            if (studentRecord == null)
//            {
//                UserInterfaceView.DisplayNoRecordsFoundMessage();
//                return;
//            }

//            UserInterfaceView.DisplayAttendanceRecords(studentName, studentRecord.StudentList);
//        }
//        public static void ViewAttendanceRecordsForAllStudents()
//        {
//            Console.WriteLine("Attendance records for all students:");

//            if (Students.StudentList.Count == 0)
//            {
//                Console.WriteLine("No attendance records found for any student.");
//                return;
//            }

//            foreach (var student in Students.StudentList)
//            {
//                Console.WriteLine($"Student: {student.StudentName}");
//                foreach (var record in student.StudentList)
//                {
//                    Console.WriteLine($"Date: {record.Time.ToShortDateString()}, Time: {record.Time.ToShortTimeString()}, Status: {record.Status}");
//                }
//                Console.WriteLine();
//            }
//        }
//    }

//    public enum AttendanceStatus
//    {
//        Unknown = 0,
//        Present = 1,
//        Absent = 2,
//        Excused = 3
//    }
//}
