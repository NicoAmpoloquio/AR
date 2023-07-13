using System;
using System.Collections.Generic;
using Attendance_Models;

namespace Attendance_DataLayer
{
    public class Students
    {
        public static List<StudentAttendanceRecord> StudentList = new List<StudentAttendanceRecord>();

        public static void InMemoryDataStudents()
        {
            StudentList.Add(new StudentAttendanceRecord("Nico Ampoloquio", "A001"));
            StudentList.Add(new StudentAttendanceRecord("Joanvic Vargas", "A002"));
            StudentList.Add(new StudentAttendanceRecord("Mekaila Aguila", "A003"));
            StudentList.Add(new StudentAttendanceRecord("Nelson James Abuan", "A004"));
            StudentList.Add(new StudentAttendanceRecord("Rose Joy Balonzo", "A005"));
            StudentList.Add(new StudentAttendanceRecord("Laurence Lagado", "A006"));
            StudentList.Add(new StudentAttendanceRecord("Patricia Laine Sison", "A007"));
        }
    }
}
