using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models
{
    public class TimReport
    {
        [Key]
        public int TimReportID { get; set; }
        public int TimReportWeek { get; set; }
        public double TimReportWorkingHours { get; set; }

        public int EmployeeID { get; set; }
        public Employee Employee { get; set; }
    }
}
