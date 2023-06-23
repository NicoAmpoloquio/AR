using System;

namespace Attendance_Models
{
    public class RecordDateTime
    {
        public DateTime Time { get; }
        public string StudentName { get; }
        public string StudentNumber { get; }
        public AttendanceStatus Status { get; set; }

        public RecordDateTime(DateTime time, string studentName, string studentNumber, AttendanceStatus status)
        {
            Time = time;
            StudentName = studentName;
            StudentNumber = studentNumber;
            Status = status;
        }
    }
}
