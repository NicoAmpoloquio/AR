using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Attendance_Models;

namespace Attendance_DataLayer
{
    public class SqlData
    {
        static string connectionString = "Server=DESKTOP-PT80VE9\\SQLEXPRESS;Initial Catalog=PUPAttendance;Integrated Security=True;";
        
        static SqlConnection sqlConnection;

        public SqlData()
        {
            sqlConnection = new SqlConnection(connectionString);
        }
        public bool AddAttendance(AttendanceRecord attendance)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Attendance (StudentNumber, StudentName, Status, Date) " +
                               "VALUES (@StudentNumber, @StudentName, @Status, @Date)";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@StudentNumber", attendance.Student.StudentNumber);
                command.Parameters.AddWithValue("@StudentName", attendance.Student.StudentName);
                command.Parameters.AddWithValue("@Status", attendance.Status.ToString());
                command.Parameters.AddWithValue("@Date", attendance.DateTime);

                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();

                return rowsAffected > 0;
            }
        }
        public bool EditAttendance(AttendanceRecord attendance)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE Attendance SET Status = @Status WHERE StudentNumber = @StudentNumber AND Date = @Date";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Status", attendance.Status.ToString());
                command.Parameters.AddWithValue("@StudentNumber", attendance.Student.StudentNumber);
                command.Parameters.AddWithValue("@Date", attendance.DateTime);

                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();

                return rowsAffected > 0;
            }
        }
        public bool DeleteAttendance(DateTime attendanceDateTime)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Attendance WHERE Date = @Date";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Date", attendanceDateTime);

                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();

                return rowsAffected > 0;
            }
        }
        public List<AttendanceRecord> GetStudentAttendance(string number, string name)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT StudentNumber, StudentName, Status, Date " +
                               "FROM Attendance " +
                               "WHERE StudentNumber = @StudentNumber AND StudentName = @StudentName";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@StudentNumber", number);
                command.Parameters.AddWithValue("@StudentName", name);

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                List<AttendanceRecord> studentAttendance = new List<AttendanceRecord>();

                while (reader.Read())
                {
                    AttendanceRecord attendance = new AttendanceRecord
                    {
                        Student = new Student
                        {
                            StudentNumber = reader.GetString(0),
                            StudentName = reader.GetString(1)
                        },
                        Status = (AttendanceStatus)Enum.Parse(typeof(AttendanceStatus), reader.GetString(2)),
                        DateTime = reader.GetDateTime(3)
                    };

                    studentAttendance.Add(attendance);
                }

                return studentAttendance;
            }
        }
        public List<AttendanceRecord> GetAllStudentsAttendance()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT StudentNumber, StudentName, Status, Date FROM Attendance";

                SqlCommand command = new SqlCommand(query, connection);

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                List<AttendanceRecord> attendanceRecords = new List<AttendanceRecord>();

                while (reader.Read())
                {
                    AttendanceRecord attendance = new AttendanceRecord
                    {
                        Student = new Student
                        {
                            StudentNumber = reader.GetString(0),
                            StudentName = reader.GetString(1)
                        },
                        Status = (AttendanceStatus)Enum.Parse(typeof(AttendanceStatus), reader.GetString(2)),
                        DateTime = reader.GetDateTime(3)
                    };

                    attendanceRecords.Add(attendance);
                }

                return attendanceRecords;
            }
        }
    }
}
