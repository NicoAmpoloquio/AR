using System;
using System.Collections.Generic;
using Attendance_DataLayer;
using Attendance_Models;
using UserInterface;

namespace Attendance_BusinessLayer
{
    public class AttendanceManager
    {
        public static List<StudentAttendanceRecord> StudentList = new List<StudentAttendanceRecord>();
        public static void RecordAttendance()
        {
            UserInterfaceRecord.GetStudentName();
            string studentName = Console.ReadLine();

            UserInterfaceRecord.GetStudentNumber();
            string studentNumber = Console.ReadLine();

            StudentAttendanceRecord studentRecord = Students.StudentList.Find(record => record.StudentName == studentName && record.StudentNumber == studentNumber);

            if (studentRecord == null)
            {
                UserInterfaceRecord.DisplayInvalidStudentNameMessage();
                return;
            }

            UserInterfaceRecord.GetAttendanceStatus();
            string statusChoice = Console.ReadLine();

            if (!Enum.TryParse(statusChoice, out AttendanceStatus attendanceStatus))
            {
                UserInterfaceRecord.DisplayInvalidChoiceMessage();
                return;
            }

            DateTime currentTime = DateTime.Now;

            studentRecord.StudentList.Add(new RecordDateTime(currentTime, studentName, studentNumber, attendanceStatus));
            UserInterfaceRecord.DisplayAttendanceMarkedMessage();
        }
        public static void EditAttendance()
        {
            UserInterfaceRecord.GetStudentName();
            string studentName = Console.ReadLine();

            UserInterfaceRecord.GetStudentNumber();
            string studentNumber = Console.ReadLine();

            StudentAttendanceRecord studentRecord = Students.StudentList.Find(record => record.StudentName == studentName && record.StudentNumber == studentNumber);

            if (studentRecord == null)
            {
                UserInterfaceRecord.AttendanceStatus();
                return;
            }

            Console.WriteLine($"Attendance records for {studentName} ({studentNumber}):");
            int index = 0;
            foreach (var record in studentRecord.StudentList)
            {
                Console.WriteLine($"[{index}] Date: {record.Time.ToShortDateString()}, Time: {record.Time.ToShortTimeString()}, Status: {record.Status}");
                index++;
            }

            UserInterfaceEdit.EnterIndex();
            string editChoice = Console.ReadLine();

            if (!int.TryParse(editChoice, out int selectedIndex))
            {
                UserInterfaceRecord.DisplayAttendanceInvalidEditMessage();
                return;
            }

            if (selectedIndex == -1)
            {
                UserInterfaceEdit.EditCancel();
                return;
            }

            if (selectedIndex < 0 || selectedIndex >= studentRecord.StudentList.Count)
            {
                UserInterfaceEdit.DisplayInvalidIndex();
                return;
            }

            RecordDateTime selectedRecord = studentRecord.StudentList[selectedIndex];

            Console.WriteLine($"Editing attendance record: Date: {selectedRecord.Time.ToShortDateString()}, Time: {selectedRecord.Time.ToShortTimeString()}, Status: {selectedRecord.Status}");
            UserInterfaceRecord.GetAttendanceStatus();
            string statusChoice = Console.ReadLine();

            if (!Enum.TryParse(statusChoice, out AttendanceStatus newStatus))
            {
                UserInterfaceRecord.DisplayAttendanceInvalidEditMessage();
                return;
            }

            selectedRecord.Status = newStatus;

            UserInterfaceRecord.DisplayAttendanceEditSuccessMessage();
        }
        public static void ViewAttendanceRecordsByStudent()
        {
            Console.Write("Enter student name: ");
            string studentName = Console.ReadLine();

            Console.Write("Enter student number: ");
            string studentNumber = Console.ReadLine();

            StudentAttendanceRecord studentRecord = Students.StudentList.Find(record => record.StudentName == studentName && record.StudentNumber == studentNumber);

            if (studentRecord == null)
            {
                Console.WriteLine("No attendance records found for this student.");
                return;
            }

            Console.WriteLine($"Attendance records for {studentName} ({studentNumber}):");
            foreach (var record in studentRecord.StudentList)
            {
                Console.WriteLine($"Date: {record.Time.ToShortDateString()}, Time: {record.Time.ToShortTimeString()}, Status: {record.Status}");
            }

            UserInterfaceView.DisplayAttendanceRecords(studentName, studentRecord.StudentList);
        }
        public static void ViewAttendanceRecordsForAllStudents()
        {
            Console.WriteLine("Attendance records for all students:");

            if (Students.StudentList.Count == 0)
            {
                Console.WriteLine("No attendance records found for any student.");
                return;
            }

            foreach (var student in Students.StudentList)
            {
                Console.WriteLine($"Student: {student.StudentName}");
                foreach (var record in student.StudentList)
                {
                    Console.WriteLine($"Date: {record.Time.ToShortDateString()}, Time: {record.Time.ToShortTimeString()}, Status: {record.Status}");
                }
                Console.WriteLine();
            }
        }
    }
}

