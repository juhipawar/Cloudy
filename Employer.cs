using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CloudAssign4.Models
{
    public class Employer
    {
        public int BrokerId { get; set; }
        [Key]
        public int EmployeeId { get; set; }

        public string Employeeposition { get; set; }

        public int Employeeyear { get; set; }

        public int Employeesalary { get; set; }

        public int Employeename { get; set; }
    }
}
