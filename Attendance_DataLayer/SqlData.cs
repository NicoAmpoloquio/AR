using Attendance_Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using UserInterface;
using Attendance_DataLayer;


namespace Attendance_DataLayer
{
    public class SqlData
    {
        static string connectionString
        = "Server = DESKTOP-PT80VE9\\SQLEXPRESS; Initial Catalog = PUPAttendance; Integrated Security = True;";
        //= "Server=tcp://,1433;Database=PUPAttendance;User Id=sa;Password=PUPAttendance@2023!;";
        static string selectStatement = "SELECT TOP (1000) [StudentNumber]\r\n     ,[StudentName]\r\n      ,[Date]\r\n      ,[Status]\r\n  FROM [PUPAttendance].[dbo].[Attendance]";

        static SqlConnection sqlConnection;

       

        public SqlData()
        {
            sqlConnection = new SqlConnection(connectionString);
        }

        //public static void RecordAttendance()
        //{
        //    RecordDateTime datetime = new RecordDateTime();
        //    String studentNumber = datetime.StudentNumber;
        //    String studentName = datetime.StudentName;
        //    DateTime date = datetime.Time;
        //    AttendanceStatus attendance = datetime.Status;


        //    sqlConnection.Open();
        //    string sqlQuery = "INSERT INTO Attendance(StudentNumber,StudentName,Date,Status) VALUES(@StudentNumber,@StudentName,@Date,@Status)";
        //    SqlCommand cmd = new SqlCommand(connectionString, sqlConnection);
        //    cmd.Parameters.AddWithValue("@StudentNumber", studentNumber);
        //    cmd.Parameters.AddWithValue("@StudentName", studentName);
        //    cmd.Parameters.AddWithValue("@Date", date);
        //    cmd.Parameters.AddWithValue("@Status", attendance);

        //    cmd.ExecuteNonQuery();
        //    sqlConnection.Close();
        //}
        public static void EditAttendance()
        {

        } 
        public static void ViewAttendanceRecordsByStudent()
        {

        }

        public static void ViewAttendanceRecordsForAllStudents()
        {

        }
    }
}