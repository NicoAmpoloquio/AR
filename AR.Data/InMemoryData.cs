using System;
using System.Collections.Generic;

namespace AR.Data
{
    public class InMemoryData
    {
        public static List<InMemoryData> studentList = new List<InMemoryData>();
        public static void InMemoryDataStudents()
        {
            studentList.Add(new InMemoryData("Nico Ampoloquio"));
            studentList.Add(new InMemoryData("Joanvic Vargas"));
            studentList.Add(new InMemoryData("Mekaila Aguila"));
        }
    }
}
