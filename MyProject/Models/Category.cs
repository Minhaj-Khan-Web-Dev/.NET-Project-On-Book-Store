using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MyProject.Models
{
    public class Category
    {
        public Category()
        {
            Products = new List<Product>();
        }
        [Key]

        public int CatId { get; set; }

        public string CatName { get; set; }

        public string CatImage { get; set; }

        
        public List<Product> Products { get; set; }
    }
}