using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CloudAssign4.Models
{
    public class MBR
    {
        [Key]
        public int Applicationid { get; set; }

        public string Custname { get; set;}

        public string Custaddress { get; set; }

        public int Custphone { get; set; }

        public string EmployerName { get; set; }

        public int EmployeeId { get; set; }

        public string LifeInsuranceName { get; set; }

        public int InsurancePolicyNumber { get; set; }

        public string Employeeposition { get; set; }

        public int Employeeyear { get; set; }

        public int Employeesalary { get; set; }

        public int Insurancevalue { get; set; }
        

        public Boolean Applicationstatus { get; set; }

        public int Employeename { get; set; }

        public int Insuranceid { get; set; }



    }
}
