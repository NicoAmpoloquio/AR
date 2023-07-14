using System;
using System.Collections.Generic;

namespace Attendance_Models
{
    public class StudentAttendanceRecord
    {
        public string StudentName { get; set; }
        public string StudentNumber { get; set; }
        
        public List<RecordDateTime> StudentList { get; set; }
        public StudentAttendanceRecord(string studentName, string studentNumber)
        {
            StudentName = studentName;
            StudentNumber = studentNumber;
            
            StudentList = new List<RecordDateTime>();
        }
    }
}