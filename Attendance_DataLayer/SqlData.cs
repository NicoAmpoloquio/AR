using Attendance_Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attendance_DataLayer
{
    public class SqlData
    {
        static string connectionString
        = "Data Source =localhost; Initial Catalog = PUPAttendance; Integrated Security = True;";
        //= "Server=tcp://,1433;Database=PUPAttendance;User Id=sa;Password=PUPAttendance@2023!;";

        static SqlConnection sqlConnection;

        public SqlData()
        {
            sqlConnection = new SqlConnection(connectionString);
        }
        public List<StudentAttendanceRecord> ViewAttendanceRecordsForAllStudents()
        {
            var selectStatement = "SELECT * Attendance";
            SqlCommand selectCommand = new SqlCommand(selectStatement, sqlConnection);
            sqlConnection.Open();
            SqlDataReader reader = selectCommand.ExecuteReader();

            var studentList = new List<StudentAttendanceRecord>();

            while (reader.Read())
            {
                {
                    string column1 = reader.GetString(0);
                    string column2 = reader.GetString(1);

                    Console.WriteLine($"Column 1: {column1}, Column 2: {column2}");
                }
                reader.Close();
            }
            sqlConnection.Close();
            return studentList;
        }
    }
}