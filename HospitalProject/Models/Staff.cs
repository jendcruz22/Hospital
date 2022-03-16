using System;
using System.ComponentModel.DataAnnotations;

namespace HospitalProject.Models
{
    public class Staff
    {
        public int Id { get; set; }
        [Required]
        public string FName { get; set; }
        public string LName { get; set; }
        public DateTime DOB { get; set; }
        public long Contact { get; set; }
        public string DID { get; set; }
    }
}