using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyProject.Models
{
    public class tbl_user_info
    {
        [Key]
        public int uiid
        {
            get; set;
        }

        public string firstname
        {
            get; set;
        }

        public string lastname
        {
            get; set;
        }

        public string phonenumber
        {
            get; set;
        }
        public string country
        {
            get; set;
        }

        public string province
        {
            get; set;
        }
        public string city
        {
            get; set;
        }

        public string town
        {
            get; set;
        }

        public string street
        {
            get; set;
        }

        public string houseno
        {
            get; set;
        }
       

        public string UserOrdered
        {
            get; set;
        }

    }
}