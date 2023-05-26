using System;

namespace Attendance_Models
{
    public class RecordDateTime
    {
        public DateTime Time { get; }
        public string Status { get; }

        public RecordDateTime(DateTime time, string status)
        {
            Time = time;
            Status = status;
        }
    }
}
