using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Employee
    {
        [Key]
        public int EmployeeID { get; set; }
        public string EmployeeFirstName { get; set; }
        public string EmployeeLastName { get; set; }
        public string EmployeeGender { get; set; }
        public int EmployeeAge { get; set; }

        public int ProjectID { get; set; }
        public Project Project { get; set; }

        public ICollection<TimReport> TimReport { get; set; }
    }
}
