using System;
using System.Collections.Generic;
using Attendance_Models;
using Attendance_DataLayer;

namespace Attendance_BusinessRules
{

    public class AttendanceRecorder
    {
        private SqlData sqlData;

        public AttendanceRecorder()
        {
            sqlData = new SqlData();
        }

        public bool AddAttendance(string number, string name, AttendanceStatus status)
        {
            List<Student> students = InMemoryData.GetStudents();
            Student student = students.Find(s => s.StudentNumber == number && s.StudentName == name);

            if (student == null)
            {
                return false;
            }

            AttendanceRecord attendance = new AttendanceRecord
            {
                Student = student,
                Status = status,
                DateTime = DateTime.Now
            };

            return sqlData.AddAttendance(attendance);
        }
        public bool EditAttendance(string number, string name, int attendanceIndex, AttendanceStatus newStatus)
        {
            List<Student> students = InMemoryData.GetStudents();
            Student student = students.Find(s => s.StudentNumber == number && s.StudentName == name);

            if (student == null)
            {
                return false;
            }

            List<AttendanceRecord> studentAttendance = sqlData.GetStudentAttendance(number, name);

            if (attendanceIndex < 1 || attendanceIndex > studentAttendance.Count)
            {
                return false;
            }
            AttendanceRecord selectedAttendance = studentAttendance[attendanceIndex - 1];

            selectedAttendance.Status = newStatus;

            return sqlData.EditAttendance(selectedAttendance);
        }
        public bool DeleteAttendance(string number, string name, int attendanceIndex)
        {
            List<Student> students = InMemoryData.GetStudents();
            Student student = students.Find(s => s.StudentNumber == number && s.StudentName == name);

            if (student == null)
            {
                return false;
            }

            List<AttendanceRecord> studentAttendance = sqlData.GetStudentAttendance(number, name);

            if (attendanceIndex < 1 || attendanceIndex > studentAttendance.Count)
            {
                return false;
            }

            return sqlData.DeleteAttendance(studentAttendance[attendanceIndex - 1].DateTime);
        }
        public List<AttendanceRecord> GetStudentAttendance(string number, string name)
        {
            return sqlData.GetStudentAttendance(number, name);
        }
        public List<AttendanceRecord> GetAllStudentsAttendance()
        {
            return sqlData.GetAllStudentsAttendance();
        }
    }
}
