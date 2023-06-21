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

            Students.InMemoryDataStudents();

            while (true)
            {
                UserInterfaceMenu.DisplayMainMenu();

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

