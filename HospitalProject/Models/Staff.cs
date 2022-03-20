using System;
using System.ComponentModel.DataAnnotations;

namespace HospitalProject.Models
{
    public class Staff
    {
        [Key]
        public int SID { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public DateTime DOB { get; set; }
        public long Contact { get; set; }
        public string DID { get; set; }
    }
}