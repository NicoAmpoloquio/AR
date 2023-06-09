﻿using System;
using Attendance_DataLayer;
using Attendance_Models;
using Attendance_BusinessLayer;
using UserInterface;

namespace AttendanceRecorder
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
                        UserInterfaceView.ViewAttendanceRecordsByStudent();
                        break;
                    case "3":
                        UserInterfaceView.ViewAttendanceRecordsForAllStudents();
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

