using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace HospitalProject.Models
{
    public class Appointment
    {
        [Key]
        public int AID { get; set; }
        public DateTime Date { get; set; }
        public DateTime Time { get; set; }
        public string Reason { get; set; }
        [ForeignKey("Patient")]
         public int Id { get; set; }
        public virtual Patient Patient { get; set; }
        /*[ForeignKey("Staff")]
        public int SID { get; set;}

       public virtual staff staffs { get; set; }
       */
    }
    public class AppointmentDto
    {
        public int AID { get; set; }
        public DateTime Date { get; set; }
        public DateTime Time { get; set; }
        public string Reason { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
    }
}