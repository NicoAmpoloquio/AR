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

            Console.WriteLine("Welcome to the Attendance Recorder Program!");
            Console.WriteLine("-------------------------------------------");

            AttendanceRecorder recorder = new AttendanceRecorder();

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
                        recorder.AddAttendance();
                        break;
                    case "2":
                        recorder.EditAttendance();
                        break;
                    case "3":
                        recorder.ViewStudentAttendance();
                        break;
                    case "4":
                        recorder.ViewAllStudentsAttendance();
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
    }
}