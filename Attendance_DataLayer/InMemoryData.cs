﻿using System;
using System.Collections.Generic;
using Attendance_Models;

namespace Attendance_DataLayer
{
    public static class InMemoryData
    {
        static List<Student> students = new List<Student>();
        static List<AttendanceRecord> attendanceRecords = new List<AttendanceRecord>();

        public static string AcademicYear { get; set; } = "2022-2023";
        public static string Section { get; set; } = "BSIT 2-1";

        public static void InMemoryStudents()
        {
                Student student1 = new Student
                {
                    StudentNumber = "A001",
                    StudentName = "Nelson James Abuan"
                };

                Student student2 = new Student
                {
                    StudentNumber = "A002",
                    StudentName = "Mekaila Aguila"
                };

                Student student3 = new Student
                {
                    StudentNumber = "A003",
                    StudentName = "Nico Ampoloquio"
                };

                Student student4 = new Student
                {
                    StudentNumber = "A004",
                    StudentName = "Rose Joy Balonzo"
                };

                Student student5 = new Student
                {
                    StudentNumber = "A005",
                    StudentName = "Laurence Lagado"
                };

                Student student6 = new Student
                {
                    StudentNumber = "A006",
                    StudentName = "Joanvic Vargas"
                };

                students.Add(student1);
                students.Add(student2);
                students.Add(student3);
                students.Add(student4);
                students.Add(student5);
                students.Add(student6);

            foreach (Student student in students)
            {
                student.AcademicYear = AcademicYear;
                student.Section = Section;
            }
        }

        public static List<Student> GetStudents()
        {
            return students;
        }
    }
}
