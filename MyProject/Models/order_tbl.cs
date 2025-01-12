using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyProject.Models
{
    public class order_tbl
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

        public string fk_tbl_u
        {
            get; set;
        }
        public string Order_Status { get; set; }

    }
}