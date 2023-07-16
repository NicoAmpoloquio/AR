using System;
using System.Collections.Generic;
using Attendance_Models;
using Attendance_DataLayer;

namespace Attendance_BusinessRules
{
    public class AttendanceRecorder
    {
        public AttendanceRecord AddAttendance(string studentNumber, string studentName, AttendanceStatus status)
        {
            List<Student> students = InMemoryData.GetStudents();
            Student student = students.Find(s => s.StudentNumber == studentNumber && s.StudentName == studentName);

            if (student == null)
            {
                return null;
            }

            AttendanceRecord attendance = new AttendanceRecord
            {
                Student = student,
                Status = status,
                DateTime = DateTime.Now
            };

            InMemoryData.AddAttendanceRecord(attendance);
            return attendance;
        }

        public void EditAttendance(string studentNumber, string studentName, int attendanceIndex, AttendanceStatus newStatus)
        {
            List<Student> students = InMemoryData.GetStudents();
            Student student = students.Find(s => s.StudentNumber == studentNumber && s.StudentName == studentName);

            if (student == null)
            {
                return;
            }

            List<AttendanceRecord> studentAttendance = InMemoryData.GetAttendanceRecords().FindAll(a => a.Student == student);

            if (attendanceIndex < 1 || attendanceIndex > studentAttendance.Count)
            {
                return;
            }

            studentAttendance[attendanceIndex - 1].Status = newStatus;
        }

        public List<AttendanceRecord> GetStudentAttendance(string studentNumber, string studentName)
        {
            List<Student> students = InMemoryData.GetStudents();
            Student student = students.Find(s => s.StudentNumber == studentNumber && s.StudentName == studentName);

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
