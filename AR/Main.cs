using System;
using AR.Business;
using AR.Models;

class AttendanceRecorder
{
    static void Main(string[] args)
    {
        Console.WriteLine("Attendance is a Must, attendance muna bago umui mga idok.");
        Console.WriteLine("-------------------------------------------");

        AttendanceManager attendanceManager = new AttendanceManager();
        attendanceManager.InitializeStudents();

        while (true)
        {
            Console.WriteLine("1. Mark attendance");
            Console.WriteLine("2. View attendance by student");
            Console.WriteLine("3. View attendance for all students");
            Console.WriteLine("4. Exit");
            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    attendanceManager.MarkAttendance();
                    break;
                case "2":
                    attendanceManager.ViewAttendanceByStudent();
                    break;
                case "3":
                    attendanceManager.ViewAttendanceForAllStudents();
                    break;
                case "4":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid choice! Please try again.");
                    break;
            }

            Console.WriteLine();
        }
    }
}
