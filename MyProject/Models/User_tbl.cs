using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyProject.Models
{
    public class User_tbl
    {
        public User_tbl()
        {
            Role_Tbls = new List<Role_tbl>();
        }
        [Key]
        public int User_id { get; set; }
        [Display (Name = "Username")]
        public string User_Name { get; set; }
        [Display(Name = "User Email")]
        public string User_Email { get; set; }
        [Display(Name = "User Password")]
        
        public string User_Passowrd { get; set; }

        public List<Role_tbl> Role_Tbls { get; set; }
    }
}