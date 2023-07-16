using System;
using System.Collections.Generic;
using Attendance_Models;
using Attendance_DataLayer;

namespace Attendance_BusinessRules
{
    public class AttendanceRecorder
    {
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

            InMemoryData.AddAttendanceRecord(attendance);
            return true;
        }
        public bool EditAttendance(string number, string name, int attendanceIndex, AttendanceStatus newStatus)
        {
            List<Student> students = InMemoryData.GetStudents();
            Student student = students.Find(s => s.StudentNumber == number && s.StudentName == name);

            if (student == null)
            {
                return false;
            }

            List<AttendanceRecord> studentAttendance = InMemoryData.GetAttendanceRecords().FindAll(a => a.Student == student);

            if (attendanceIndex < 1 || attendanceIndex > studentAttendance.Count)
            {
                return false;
            }

            studentAttendance[attendanceIndex - 1].Status = newStatus;
            return true;
        }
        public List<AttendanceRecord> GetStudentAttendance(string number, string name)
        {
            List<Student> students = InMemoryData.GetStudents();
            Student student = students.Find(s => s.StudentNumber == number && s.StudentName == name);

            if (student == null)
            {
                return null;
            }

            List<AttendanceRecord> studentAttendance = InMemoryData.GetAttendanceRecords().FindAll(a => a.Student == student);
            return studentAttendance;
        }
        public List<AttendanceRecord> GetAllStudentsAttendance()
        {
            List<Student> students = InMemoryData.GetStudents();
            List<AttendanceRecord> attendanceRecords = InMemoryData.GetAttendanceRecords();
            return attendanceRecords;
        }
    }
}
