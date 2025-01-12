using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyProject.Models
{
    public class Review
    {

        [Key]
        public int rev_id { get; set; }
       
        
       
        public string userName { get; set; }

        public string u_email
        {
            get; set;
        }

        public string Date
        {
            get; set;
        }
        public string rev_details
        {
            get; set;
        }
        public string rev_star
        {
            get; set;
        }

        public int Productid
        {
            get; set;
        }
    }
}