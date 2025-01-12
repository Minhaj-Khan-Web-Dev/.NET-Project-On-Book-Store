using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MyProject.Models
{
    public class Product
    {
       
        [Key]
        public int ProId { get; set; }
        public string Product_key { get; set; }
        public string ProName { get; set; }

        public int ProPrice { get; set; }

        public string ProDetails { get; set; }

        public int Pro_qty
        {
            get; set;
        }
        public string ProImage { get; set; }
        [ForeignKey("Categories")]
        public int Cid { get; set; }

        public virtual Category Categories { get; set; }

       
        
    }
}