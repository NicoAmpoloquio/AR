using System;
using System.Collections.Generic;

namespace Attendance_Models
{
    public class StudentAttendanceRecord
    {
        public string StudentName { get; }
        public List<RecordDateTime> StudentList { get; }
        public StudentAttendanceRecord(string studentName)
        {
            StudentName = studentName;
            StudentList = new List<RecordDateTime>();
        }
    }
}
