using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography;
using System.Web;

namespace MyProject.Models
{
    public class tbl_order
    {
        [Key]
        public int oid
        {
            get; set;
        }

        public string fk_cart
        {
            get; set;
        }
        public string order_no
        {
            get; set;
        }

        public string total_price
        {
            get; set;
        }
    }
}