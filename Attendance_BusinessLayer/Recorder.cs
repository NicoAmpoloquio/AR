using System;
using System.Collections.Generic;
using Attendance_DataLayer;
using Attendance_Models;
using UserInterface;

namespace Attendance_BusinessLayer
{
    public class AttendanceManager
    {
        public static void RecordAttendance()
        {
            UserInterfaceRecord.GetStudentNumber();
            string studentNumber = Console.ReadLine();

            UserInterfaceRecord.GetStudentName();
            string studentName = Console.ReadLine();

            StudentAttendanceRecord studentRecord = InMemoryData.StudentList.Find(record => record.StudentName == studentName && record.StudentNumber == studentNumber);

            if (studentRecord == null)
            {
                UserInterfaceMessage.DisplayInvalidStudentNameMessage();
                return;
            }

            UserInterfaceRecord.GetAttendanceStatus();
            string statusChoice = Console.ReadLine();

            if (!Enum.TryParse(statusChoice, out AttendanceStatus attendanceStatus))
            {
                UserInterfaceMessage.DisplayInvalidChoiceMessage();
                return;
            }

            DateTime currentTime = DateTime.Now;

            studentRecord.StudentList.Add(new RecordDateTime(studentNumber, studentName, currentTime, attendanceStatus));
            UserInterfaceMessage.DisplayAttendanceMarkedMessage();
        }
        public static void EditAttendance()
        {
            UserInterfaceRecord.GetStudentNumber();
            string studentNumber = Console.ReadLine();

            UserInterfaceRecord.GetStudentName();
            string studentName = Console.ReadLine();

            StudentAttendanceRecord studentRecord = InMemoryData.StudentList.Find(record => record.StudentNumber == studentNumber && record.StudentName == studentName);

            if (studentRecord == null)
            {
                UserInterfaceMessage.AttendanceStatus();
                return;
            }

            Console.WriteLine($"Attendance records for {studentNumber} ({studentName}):");
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
                UserInterfaceMessage.DisplayAttendanceInvalidEditMessage();
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
                UserInterfaceMessage.DisplayAttendanceInvalidEditMessage();
                return;
            }

            selectedRecord.Status = newStatus;

            UserInterfaceMessage.DisplayAttendanceEditSuccessMessage();
        }
        public static void ViewAttendanceRecordsByStudent()
        {
            UserInterfaceRecord.GetStudentNumber();
            string studentNumber = Console.ReadLine();

            UserInterfaceRecord.GetStudentName();
            string studentName = Console.ReadLine();

            StudentAttendanceRecord studentRecord = InMemoryData.StudentList.Find(record => record.StudentNumber == studentNumber && record.StudentName == studentName);

            if (studentRecord == null)
            {
                UserInterfaceMessage.DisplayNoRecordsFoundMessage();
                return;
            }

            Console.WriteLine($"Attendance records for {studentNumber} ({studentName}):");
            foreach (var record in studentRecord.StudentList)
            {
                Console.WriteLine($"Date: {record.Time.ToShortDateString()}, Time: {record.Time.ToShortTimeString()}, Status: {record.Status}");
            }

            UserInterfaceView.DisplayAttendanceRecords(studentNumber, studentRecord.StudentList);
        }
        public static void ViewAttendanceRecordsForAllStudents()
        {
            UserInterfaceMessage.DisplayAttendanceRecordMessage();

            if (InMemoryData.StudentList.Count == 0)
            {
                UserInterfaceMessage.AllStudentsStatus();
                return;
            }

            foreach (var student in InMemoryData.StudentList)
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