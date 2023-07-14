using Attendance_Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Attendance_DataLayer
{
    public class SqlData : InMemoryData
    {
        static string connectionString
        = "Data Source = localhost; Initial Catalog = PUPAttendance; Integrated Security = True;";
        //= "Server=tcp://,1433;Database=PUPAttendance;User Id=sa;Password=PUPAttendance@2023!;";

        static SqlConnection sqlConnection;

        public SqlData()
        {
            sqlConnection = new SqlConnection(connectionString);
        }
    }
}