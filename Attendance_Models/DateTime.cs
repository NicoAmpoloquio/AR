using System;

namespace Attendance_Models
{
    public class RecordDateTime
    {
        public string StudentName { get; set; }
        public string StudentNumber { get; set; }
        public DateTime Time { get; set; }
        public AttendanceStatus Status { get; set; }
        public RecordDateTime(string studentName, string studentNumber, DateTime time, AttendanceStatus status)
        {
            StudentName = studentName;
            StudentNumber = studentNumber;
            Time = time;
            Status = status;
        }
    }
}