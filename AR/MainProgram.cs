using System;
using System.Collections.Generic;
using Attendance_BusinessLayer;
using Attendance_DataLayer;
using Attendance_UserInterface;

namespace Attendance
{
    internal class MainProgram
    {
        static void Main(string[] args)
        {
            UserInterfaceMenu.DisplayMainTitle();
            //Console.WriteLine("Attendance is a Must, attendance muna bago umalis mga ya.");
            //Console.WriteLine("-------------------------------------------");

            Students.InMemoryDataStudents();

            while (true)
            {
                UserInterfaceMenu.DisplayMainMenu();
                //Console.WriteLine("\nPlease select an option:");
                //Console.WriteLine("1. Record attendance");
                //Console.WriteLine("2. View attendance records by student");
                //Console.WriteLine("3. View attendance records for all students");
                //Console.WriteLine("4. Edit attendance records");
                //Console.WriteLine("5. Exit");
                //Console.Write("Enter your choice: ");

                string input = Console.ReadLine();
                Console.WriteLine();

                switch (input)
                {
                    case "1":
                        AttendanceManager.RecordAttendance();
                        break;
                    case "2":
                        AttendanceManager.ViewAttendanceRecordsByStudent();
                        break;
                    case "3":
                        AttendanceManager.ViewAttendanceRecordsForAllStudents();
                        break;
                    case "4":
                        AttendanceManager.EditAttendance();
                        break;
                    case "5":
                        UserInterfaceMenu.DisplayExitMessage();
                        return;
                    default:
                        UserInterfaceMenu.DisplayInvalidChoiceMessage();
                        break;
                }
            }
        }
    }
}

//using System;
//using System.Collections.Generic;

//class AttendanceRecorder
//{
//    static List<StudentAttendanceRecord> attendanceRecords = new List<StudentAttendanceRecord>();

//    static void Main(string[] args)
//    {
//        InitializeStudents();

//        while (true)
//        {
//            Console.WriteLine("1. Mark attendance");
//            Console.WriteLine("2. View attendance by student");
//            Console.WriteLine("3. View attendance for all students");
//            Console.WriteLine("4. Exit");
//            Console.Write("Enter your choice: ");
//            string choice = Console.ReadLine();

//            switch (choice)
//            {
//                case "1":
//                    MarkAttendance();
//                    break;
//                case "2":
//                    ViewAttendanceByStudent();
//                    break;
//                case "3":
//                    ViewAttendanceForAllStudents();
//                    break;
//                case "4":
//                    Environment.Exit(0);
//                    break;
//                default:
//                    Console.WriteLine("Invalid choice! Please try again.");
//                    break;
//            }

//            Console.WriteLine();
//        }
//    }

//    static void InitializeStudents()
//    {
//        attendanceRecords.Add(new StudentAttendanceRecord("Nico Ampoloquio"));
//        attendanceRecords.Add(new StudentAttendanceRecord("Joanvic Vargas"));
//        attendanceRecords.Add(new StudentAttendanceRecord("Mekaila Aguila"));
//    }

//    static void MarkAttendance()
//    {
//        Console.Write("Enter student name: ");
//        string studentName = Console.ReadLine();

//        StudentAttendanceRecord studentRecord = attendanceRecords.Find(record => record.StudentName == studentName);

//        if (studentRecord == null)
//        {
//            Console.WriteLine("Invalid student name! Attendance not marked.");
//            return;
//        }

//        Console.WriteLine("Select attendance status:");
//        Console.WriteLine("1. Present");
//        Console.WriteLine("2. Absent");
//        Console.WriteLine("3. Excused");
//        Console.Write("Enter your choice: ");
//        string statusChoice = Console.ReadLine();

//        string attendanceStatus;

//        switch (statusChoice)
//        {
//            case "1":
//                attendanceStatus = "Present";
//                break;
//            case "2":
//                attendanceStatus = "Absent";
//                break;
//            case "3":
//                attendanceStatus = "Excused";
//                break;
//            default:
//                Console.WriteLine("Invalid choice! Attendance not marked.");
//                return;
//        }

//        DateTime currentTime = DateTime.Now;

//        studentRecord.AttendanceRecords.Add(new AttendanceRecord(currentTime, attendanceStatus));
//        Console.WriteLine("Attendance marked successfully.");
//    }

//    static void ViewAttendanceByStudent()
//    {
//        Console.Write("Enter student name: ");
//        string studentName = Console.ReadLine();

//        StudentAttendanceRecord studentRecord = attendanceRecords.Find(record => record.StudentName == studentName);

//        if (studentRecord == null)
//        {
//            Console.WriteLine("No attendance records found for this student.");
//            return;
//        }

//        Console.WriteLine($"Attendance records for {studentName}:");
//        foreach (var record in studentRecord.AttendanceRecords)
//        {
//            Console.WriteLine($"Date: {record.Time.ToShortDateString()}, Time: {record.Time.ToShortTimeString()}, Status: {record.Status}");
//        }
//    }

//    static void ViewAttendanceForAllStudents()
//    {
//        Console.WriteLine("Attendance records for all students:");

//        if (attendanceRecords.Count == 0)
//        {
//            Console.WriteLine("No attendance records found for any student.");
//            return;
//        }

//        foreach (var student in attendanceRecords)
//        {
//            Console.WriteLine($"Student: {student.StudentName}");
//            foreach (var record in student.AttendanceRecords)
//            {
//                Console.WriteLine($"Date: {record.Time.ToShortDateString()}, Time: {record.Time.ToShortTimeString()}, Status: {record.Status}");
//            }
//            Console.WriteLine();
//        }
//    }
//}

//class StudentAttendanceRecord
//{
//    public string StudentName { get; }
//    public List<AttendanceRecord> AttendanceRecords { get; }

//    public StudentAttendanceRecord(string studentName)
//    {
//        StudentName = studentName;
//        AttendanceRecords = new List<AttendanceRecord>();
//    }
//}

//class AttendanceRecord
//{
//    public DateTime Time { get; }
//    public string Status { get; }

//    public AttendanceRecord(DateTime time, string status)
//    {
//        Time = time;
//        Status = status;
//    }
//}
