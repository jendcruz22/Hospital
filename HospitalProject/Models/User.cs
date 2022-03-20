using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace HospitalProject.Models
{
    public class User
    {
        [Key]
        public int UID { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }

        public string Email { get; set; }
        // need to check the type of the pwd
        public string PWD { get; set; }


    }
}