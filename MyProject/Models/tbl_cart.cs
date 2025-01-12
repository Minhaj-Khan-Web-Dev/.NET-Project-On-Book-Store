using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyProject.Models
{
    public class tbl_cart
    {
        [Key]
        public int cartID
        {
            get; set;
        }
        public string cart_id
        {
            get; set;
        }
        public int fk_Productid
        {
            get; set;
        }

        public int qty
        {
            get; set;
        }
    }
}