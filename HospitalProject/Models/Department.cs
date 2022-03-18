using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HospitalProject.Models
{
    public class Department
    { 
        [Key]
        public int DID { get; set; }
        public string DName { get; set; }
    }

    // transfer data
    public class DepartmentDto {
        public int DID { get; set; }
        public string DName { get; set; }
    }
}