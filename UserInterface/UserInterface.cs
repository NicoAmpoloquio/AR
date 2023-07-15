﻿using Attendance_Models;
using System;
using System.Collections.Generic;

namespace UserInterface
{
    public class UserInterfaceMenu
    {
        public static void DisplayMainTitle()
        {
            Console.WriteLine("Attendance is a Must, attendance muna bago umalis mga ya.");
            Console.WriteLine("-------------------------------------------");
        }
        public static void DisplayMainMenu()
        {
            Console.WriteLine("\nPlease select an option:");
            Console.WriteLine("1. Record attendance");
            Console.WriteLine("2. View attendance records by student");
            Console.WriteLine("3. View attendance records for all students");
            Console.WriteLine("4. Edit attendance records");
            Console.WriteLine("5. Exit");
            Console.Write("Enter your choice: ");
        }
    }
    public class UserInterfaceRecord
    {
        public static string GetStudentName()
        {
            Console.Write("Enter student name: ");
            return Console.ReadLine();
        }
        public static string GetStudentNumber()
        {
            Console.Write("Enter student number: ");
            return Console.ReadLine();
        }
        public static string GetAttendanceStatus()
        {

            Console.WriteLine("Select attendance status:");
            Console.WriteLine("1. Present");
            Console.WriteLine("2. Absent");
            Console.WriteLine("3. Excused");
            Console.Write("Enter your choice: ");

            return Console.ReadLine();
        }
    }
    public class UserInterfaceEdit
    {
        public static void EditCancel()
        {
            Console.WriteLine("Attendance edit canceled.");
        }
        public static void DisplayInvalidIndex()
        {
            Console.WriteLine("Invalid index! Attendance not edited.");
        }
        public static void EnterIndex()
        {
            Console.Write("Enter the index of the attendance record to edit (-1 to cancel): ");
        }
    }
    public class UserInterfaceView
    {
        public static void DisplayAttendanceRecords(string studentName, List<RecordDateTime> records)
        {
            Console.WriteLine($"Attendance records for {studentName}:");
            foreach (var record in records)
            {
                Console.WriteLine($"Date: {record.Time.ToShortDateString()}, Time: {record.Time.ToShortTimeString()}, Status: {record.Status}");
            }
        }
    }
    public class UserInterfaceMessage
    {
        public static void DisplayExitMessage()
        {
            Console.WriteLine("Bounce program na par...");
        }
        public static void DisplayTryAgainMessage()
        {
            Console.WriteLine("Invalid choice, please try again.");
        }
        public static void DisplayInvalidStudentNameMessage()
        {
            Console.WriteLine("Invalid student name or number! Attendance not marked.");
        }
        public static void DisplayInvalidChoiceMessage()
        {
            Console.WriteLine("Invalid choice! Attendance not marked.");
        }
        public static void DisplayAttendanceMarkedMessage()
        {
            Console.WriteLine("Attendance marked successfully.");
        }
        public static void DisplayAttendanceEditSuccessMessage()
        {
            Console.WriteLine("Attendance edited successfully.");
        }
        public static void DisplayAttendanceRecordMessage()
        {
            Console.WriteLine("Attendance records for all students:");
        }
        public static void DisplayAttendanceInvalidEditMessage()
        {
            Console.WriteLine("Invalid choice! Attendance not edited.");
        }
        public static void AttendanceStatus()
        {
            Console.WriteLine("No attendance records found for this student.");
        }
        public static void AllStudentsStatus()
        {
            Console.WriteLine("No attendance records found for any student.");
        }
        public static void DisplayNoRecordsFoundMessage()
        {
            Console.WriteLine("No attendance records found for this student.");
        }
    }
}