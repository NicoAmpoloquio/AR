using System;

namespace Attendance_Models
{
    public class RecordDateTime
    {
        public DateTime Time { get; set; }
        public string StudentName { get; set; }
        public string StudentNumber { get; set; }
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
