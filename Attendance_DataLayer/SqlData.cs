using Attendance_Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Attendance_DataLayer;


namespace Attendance_DataLayer
{
    public class SqlData
    {
        static string connectionString
        = "Server = DESKTOP-PT80VE9\\SQLEXPRESS; Initial Catalog = PUPAttendance; Integrated Security = True;";
        //= "Server=tcp://,1433;Database=PUPAttendance;User Id=sa;Password=PUPAttendance@2023!;";
        //static string selectStatement = "SELECT TOP (1000) [StudentNumber]\r\n     ,[StudentName]\r\n      ,[Date]\r\n      ,[Status]\r\n  FROM [PUPAttendance].[dbo].[Attendance]";

        static SqlConnection sqlConnection;
        public SqlData()
        {
            sqlConnection = new SqlConnection(connectionString);
        }
    }
}