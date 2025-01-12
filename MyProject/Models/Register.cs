using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;

namespace MyProject.Models
{
    public class Register
    {
        public Register()
        {
            Role_Tbls = new List<Role_tbl>();

        }
        [Key]
        public int reg_id { get; set; }
        [Display(Name = "Enter Your Username")]
        public string username  { get; set; }
        [Display(Name = "Enter Your Email")]
        public string user_email { get; set; }
        [DataType(DataType.Password)]
        [Required]
        [Display(Name = "Enter Your Password")]

        public string password { get; set; }
        [Display(Name = "Enter You Phone Number")]

        public string Phone { get; set; }
        public string User_img { get; set; }

        public List<Role_tbl> Role_Tbls
        {
            get; set;
        }

        
        


    }
}