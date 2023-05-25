using System;
using System.Collections.Generic;

namespace AR.Models
{
    public class StudentAttendanceRecord
    {
        public string StudentName { get; }
        public List<AttendanceRecord> AttendanceRecords { get; }

        public StudentAttendanceRecord(string studentName)
        {
            StudentName = studentName;
            AttendanceRecords = new List<AttendanceRecord>();
        }
    }

    public class AttendanceRecord
    {
        public DateTime Time { get; }
        public string Status { get; }

        public AttendanceRecord(DateTime time, string status)
        {
            Time = time;
            Status = status;
        }
    }
}
