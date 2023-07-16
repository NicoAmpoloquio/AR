//using System;
//using System.Collections.Generic;
//using System.Data.SqlClient;
//using Attendance_Models;

//namespace Attendance_DataLayer
//{
//    public class SqlData
//    {
//        private string connectionString = "Server=DESKTOP-PT80VE9\\SQLEXPRESS;Initial Catalog=PUPAttendance;Integrated Security=True;";

//        public AttendanceRecord AddAttendance(string studentNumber, string studentName, AttendanceStatus status)
//        {
//            using (SqlConnection connection = new SqlConnection(connectionString))
//            {
//                connection.Open();

//                // Check if the student exists in the database
//                using (SqlCommand command = new SqlCommand("SELECT * FROM [Students] WHERE [StudentNumber] = @StudentNumber AND [StudentName] = @StudentName", connection))
//                {
//                    command.Parameters.AddWithValue("@StudentNumber", studentNumber);
//                    command.Parameters.AddWithValue("@StudentName", studentName);

//                    using (SqlDataReader reader = command.ExecuteReader())
//                    {
//                        if (!reader.HasRows)
//                        {
//                            return null;
//                        }
//                    }
//                }

//                // Insert the attendance record into the database
//                using (SqlCommand command = new SqlCommand("INSERT INTO [Attendance] ([StudentNumber], [StudentName], [Status], [Date]) VALUES (@StudentNumber, @StudentName, @Status, @Date)", connection))
//                {
//                    command.Parameters.AddWithValue("@StudentNumber", studentNumber);
//                    command.Parameters.AddWithValue("@StudentName", studentName);
//                    command.Parameters.AddWithValue("@Status", (int)status);
//                    command.Parameters.AddWithValue("@Date", DateTime.Now);

//                    command.ExecuteNonQuery();
//                }
//            }

//            AttendanceRecord attendance = new AttendanceRecord
//            {
//                Student = new Student { StudentNumber = studentNumber, StudentName = studentName },
//                Status = status,
//                DateTime = DateTime.Now
//            };

//            return attendance;
//        }

//        public void EditAttendance(string studentNumber, string studentName, int attendanceIndex, AttendanceStatus newStatus)
//        {
//            using (SqlConnection connection = new SqlConnection(connectionString))
//            {
//                connection.Open();

//                // Check if the student exists in the database
//                using (SqlCommand command = new SqlCommand("SELECT * FROM [Students] WHERE [StudentNumber] = @StudentNumber AND [StudentName] = @StudentName", connection))
//                {
//                    command.Parameters.AddWithValue("@StudentNumber", studentNumber);
//                    command.Parameters.AddWithValue("@StudentName", studentName);

//                    using (SqlDataReader reader = command.ExecuteReader())
//                    {
//                        if (!reader.HasRows)
//                        {
//                            return;
//                        }
//                    }
//                }

//                // Get the attendance records for the student from the database
//                List<AttendanceRecord> studentAttendance = new List<AttendanceRecord>();
//                using (SqlCommand command = new SqlCommand("SELECT * FROM [Attendance] WHERE [StudentNumber] = @StudentNumber AND [StudentName] = @StudentName", connection))
//                {
//                    command.Parameters.AddWithValue("@StudentNumber", studentNumber);
//                    command.Parameters.AddWithValue("@StudentName", studentName);

//                    using (SqlDataReader reader = command.ExecuteReader())
//                    {
//                        while (reader.Read())
//                        {
//                            AttendanceRecord record = new AttendanceRecord
//                            {
//                                Student = new Student { StudentNumber = studentNumber, StudentName = studentName },
//                                Status = (AttendanceStatus)reader["Status"],
//                                DateTime = (DateTime)reader["Date"]
//                            };

//                            studentAttendance.Add(record);
//                        }
//                    }
//                }

//                // Update the specified attendance record and update it in the database
//                if (attendanceIndex >= 1 && attendanceIndex <= studentAttendance.Count)
//                {
//                    studentAttendance[attendanceIndex - 1].Status = newStatus;

//                    using (SqlCommand command = new SqlCommand("UPDATE [Attendance] SET [Status] = @Status WHERE [StudentNumber] = @StudentNumber AND [StudentName] = @StudentName AND [Date] = @Date", connection))
//                    {
//                        command.Parameters.AddWithValue("@Status", (int)newStatus);
//                        command.Parameters.AddWithValue("@StudentNumber", studentNumber);
//                        command.Parameters.AddWithValue("@StudentName", studentName);
//                        command.Parameters.AddWithValue("@Date", studentAttendance[attendanceIndex - 1].DateTime);

//                        command.ExecuteNonQuery();
//                    }
//                }
//            }
//        }

//        public List<AttendanceRecord> GetStudentAttendance(string studentNumber, string studentName)
//        {
//            List<AttendanceRecord> studentAttendance = new List<AttendanceRecord>();

//            using (SqlConnection connection = new SqlConnection(connectionString))
//            {
//                connection.Open();

//                // Check if the student exists in the database
//                using (SqlCommand command = new SqlCommand("SELECT * FROM [Students] WHERE [StudentNumber] = @StudentNumber AND [StudentName] = @StudentName", connection))
//                {
//                    command.Parameters.AddWithValue("@StudentNumber", studentNumber);
//                    command.Parameters.AddWithValue("@StudentName", studentName);

//                    using (SqlDataReader reader = command.ExecuteReader())
//                    {
//                        if (!reader.HasRows)
//                        {
//                            return null;
//                        }
//                    }
//                }

//                // Get the attendance records for the student from the database
//                using (SqlCommand command = new SqlCommand("SELECT * FROM [Attendance] WHERE [StudentNumber] = @StudentNumber AND [StudentName] = @StudentName", connection))
//                {
//                    command.Parameters.AddWithValue("@StudentNumber", studentNumber);
//                    command.Parameters.AddWithValue("@StudentName", studentName);

//                    using (SqlDataReader reader = command.ExecuteReader())
//                    {
//                        while (reader.Read())
//                        {
//                            AttendanceRecord record = new AttendanceRecord
//                            {
//                                Student = new Student { StudentNumber = studentNumber, StudentName = studentName },
//                                Status = (AttendanceStatus)reader["Status"],
//                                DateTime = (DateTime)reader["Date"]
//                            };

//                            studentAttendance.Add(record);
//                        }
//                    }
//                }
//            }

//            return studentAttendance;
//        }

//        public List<AttendanceRecord> GetAllStudentsAttendance()
//        {
//            List<AttendanceRecord> attendanceRecords = new List<AttendanceRecord>();

//            using (SqlConnection connection = new SqlConnection(connectionString))
//            {
//                connection.Open();

//                // Get all attendance records from the database
//                using (SqlCommand command = new SqlCommand("SELECT * FROM [Attendance]", connection))
//                {
//                    using (SqlDataReader reader = command.ExecuteReader())
//                    {
//                        while (reader.Read())
//                        {
//                            AttendanceRecord record = new AttendanceRecord
//                            {
//                                Student = new Student { StudentNumber = (string)reader["StudentNumber"], StudentName = (string)reader["StudentName"] },
//                                Status = (AttendanceStatus)reader["Status"],
//                                DateTime = (DateTime)reader["Date"]
//                            };

//                            attendanceRecords.Add(record);
//                        }
//                    }
//                }
//            }

//            return attendanceRecords;
//        }
//    }
//}
