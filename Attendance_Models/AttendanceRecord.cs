using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attendance_Models
{
    public class AttendanceRecord
    {
        public int AttendanceID { get; set; }

        public Student Student { get; set; }
        public AttendanceStatus Status { get; set; }
        public DateTime DateTime { get; set; }
    }
}
