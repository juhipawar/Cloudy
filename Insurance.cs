using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CloudAssign4.Models
{
    public class Insurance

    {
        public int BrokerId { get; set; }
        [Key]
        public int Insuranceid { get; set; }

        public int InsurancePolicyNumber { get; set; }

        public int Insurancevalue { get; set; }


    }
}
