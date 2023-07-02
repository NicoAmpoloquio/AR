using System;
using System.Data.SqlClient;
using System.IO;

class StudentDAta
{
    static void StudentD()
    {
        string StudentData = "Student Data"; 
        string sqlFilePath = @"G:\AttendanceSQL"; 

        Student executor = new SqlFileExecutor(connectionString);
        executor.ExecuteSqlFile(G:\AttendanceSQL);
    }
}
//natatnga nako nico 
