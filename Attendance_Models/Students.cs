using System;
using System.Collections.Generic;

namespace Attendance_Models
{
    public class StudentAttendanceRecord
    {
        public string StudentName { get; }
        public string StudentNumber { get; }
        public List<RecordDateTime> StudentList { get; }
        public StudentAttendanceRecord(string studentName, string studentNumber)
        {
            StudentName = studentName;
            StudentNumber = studentNumber;
            StudentList = new List<RecordDateTime>();
        }
    }
}
