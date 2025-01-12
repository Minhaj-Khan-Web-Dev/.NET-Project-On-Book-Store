using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MyProject.Models
{
    public class MyDbContext : DbContext
    {
        public MyDbContext() : base("MyCon")
        {

        }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Role_tbl> Role_Tbls { get; set; }


        public DbSet<Review> Reviews { get; set; }

        public DbSet<Register> Registers { get; set; }

        public DbSet<FAQ> FAQs { get; set; }

        public DbSet<order_tbl> order_Tbls
        {
            get; set;
        }

        public DbSet<tbl_cart> tbl_Carts
        {
            get; set;
        }

        public DbSet<tbl_user_info> tbl_User_Infos
        {
            get;set;
        }
    }
}