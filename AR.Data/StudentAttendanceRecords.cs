using System;
using System.Collections.Generic;

namespace AR.Data
{
    public class StudentAttendanceRecords
    {
        public string StudentName { get; }
        public List<AttendanceRecords> AttendanceRecords { get; }

        public StudentAttendanceRecords(string studentName)
        {
            StudentName = studentName;
            AttendanceRecords = new List<AttendanceRecords>();
        }
    }
    public class AttendanceRecords
    {
        public DateTime Time { get; }
        public string Status { get; }

        public AttendanceRecords(DateTime time, string status)
        {
            Time = time;
            Status = status;
        }
    }
}
