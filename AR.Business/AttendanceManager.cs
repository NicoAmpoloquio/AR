using System;
using System.Collections.Generic;
using AR.Data;

namespace AR.Business
{
    public class AttendanceManager
    {
        //private List<GetStudentName> studentList = new List<GetStudentName>();

        //public void InMemoryData()
        //{
        //    studentList.Add(new GetStudentName("Nico Ampoloquio"));
        //    studentList.Add(new GetStudentName("Joanvic Vargas"));
        //    studentList.Add(new GetStudentName("Mekaila Aguila"));
        //}

        public void InMemoryDataStudents()
        {
            throw new NotImplementedException();
        }

        public void MarkAttendance()
        {
            Console.Write("Enter student name: ");
            string studentName = Console.ReadLine();

            GetStudentName studentRecord = studentList.Find(record => record.StudentName == studentName);

            if (studentRecord == null)
            {
                Console.WriteLine("Invalid student name! Attendance not marked.");
                return;
            }

            Console.WriteLine("Select attendance status:");
            Console.WriteLine("1. Present");
            Console.WriteLine("2. Absent");
            Console.WriteLine("3. Excused");
            Console.Write("Enter your choice: ");
            string statusChoice = Console.ReadLine();

            string attendanceStatus;

            switch (statusChoice)
            {
                case "1":
                    attendanceStatus = "Present";
                    break;
                case "2":
                    attendanceStatus = "Absent";
                    break;
                case "3":
                    attendanceStatus = "Excused";
                    break;
                default:
                    Console.WriteLine("Invalid choice! Attendance not marked.");
                    return;
            }

            DateTime currentTime = DateTime.Now;

            studentRecord.AttendanceRecords.Add(new AttendanceRecords(currentTime, attendanceStatus));
            Console.WriteLine("Attendance marked successfully.");
        }
        public void ViewAttendanceByStudent()
        {
            Console.Write("Enter student name: ");
            string studentName = Console.ReadLine();

            GetStudentName studentRecord = studentList.Find(record => record.StudentName == studentName);

            if (studentRecord == null)
            {
                Console.WriteLine("No attendance records found for this student.");
                return;
            }

            Console.WriteLine($"Attendance records for {studentName}:");
            foreach (var record in studentRecord.AttendanceRecords)
            {
                Console.WriteLine($"Date: {record.Time.ToShortDateString()}, Time: {record.Time.ToShortTimeString()}, Status: {record.Status}");
            }
        }
        public void ViewAttendanceForAllStudents()
        {
            Console.WriteLine("Attendance records for all students:");

            if (studentList.Count == 0)
            {
                Console.WriteLine("No attendance records found for any student.");
                return;
            }

            foreach (var student in studentList)
            {
                Console.WriteLine($"Student: {student.StudentName}");
                foreach (var record in student.AttendanceRecords)
                {
                    Console.WriteLine($"Date: {record.Time.ToShortDateString()}, Time: {record.Time.ToShortTimeString()}, Status: {record.Status}");
                }
                Console.WriteLine();
            }
        }
    }
}
