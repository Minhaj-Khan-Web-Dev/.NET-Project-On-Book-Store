namespace MyProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class minhaj : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CatId = c.Int(nullable: false, identity: true),
                        CatName = c.String(),
                        CatImage = c.String(),
                    })
                .PrimaryKey(t => t.CatId);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProId = c.Int(nullable: false, identity: true),
                        Product_key = c.String(),
                        ProName = c.String(),
                        ProPrice = c.Int(nullable: false),
                        ProDetails = c.String(),
                        Pro_qty = c.Int(nullable: false),
                        ProImage = c.String(),
                        Cid = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProId)
                .ForeignKey("dbo.Categories", t => t.Cid, cascadeDelete: true)
                .Index(t => t.Cid);
            
            CreateTable(
                "dbo.FAQs",
                c => new
                    {
                        f_id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        f_qus = c.String(),
                        f_ans = c.String(),
                    })
                .PrimaryKey(t => t.f_id);
            
            CreateTable(
                "dbo.order_tbl",
                c => new
                    {
                        oid = c.Int(nullable: false, identity: true),
                        fk_cart = c.String(),
                        order_no = c.String(),
                        total_price = c.String(),
                        fk_tbl_u = c.String(),
                        Order_Status = c.String(),
                    })
                .PrimaryKey(t => t.oid);
            
            CreateTable(
                "dbo.Registers",
                c => new
                    {
                        reg_id = c.Int(nullable: false, identity: true),
                        username = c.String(),
                        user_email = c.String(),
                        password = c.String(nullable: false),
                        Phone = c.String(),
                        User_img = c.String(),
                    })
                .PrimaryKey(t => t.reg_id);
            
            CreateTable(
                "dbo.Role_tbl",
                c => new
                    {
                        Role_id = c.Int(nullable: false, identity: true),
                        Role_Title = c.String(),
                        Register_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Role_id)
                .ForeignKey("dbo.Registers", t => t.Register_id, cascadeDelete: true)
                .Index(t => t.Register_id);
            
            CreateTable(
                "dbo.Reviews",
                c => new
                    {
                        rev_id = c.Int(nullable: false, identity: true),
                        userName = c.String(),
                        u_email = c.String(),
                        Date = c.String(),
                        rev_details = c.String(),
                        rev_star = c.String(),
                        Productid = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.rev_id);
            
            CreateTable(
                "dbo.tbl_cart",
                c => new
                    {
                        cartID = c.Int(nullable: false, identity: true),
                        cart_id = c.String(),
                        fk_Productid = c.Int(nullable: false),
                        qty = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.cartID);
            
            CreateTable(
                "dbo.tbl_user_info",
                c => new
                    {
                        uiid = c.Int(nullable: false, identity: true),
                        firstname = c.String(),
                        lastname = c.String(),
                        phonenumber = c.String(),
                        country = c.String(),
                        province = c.String(),
                        city = c.String(),
                        town = c.String(),
                        street = c.String(),
                        houseno = c.String(),
                        UserOrdered = c.String(),
                    })
                .PrimaryKey(t => t.uiid);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Role_tbl", "Register_id", "dbo.Registers");
            DropForeignKey("dbo.Products", "Cid", "dbo.Categories");
            DropIndex("dbo.Role_tbl", new[] { "Register_id" });
            DropIndex("dbo.Products", new[] { "Cid" });
            DropTable("dbo.tbl_user_info");
            DropTable("dbo.tbl_cart");
            DropTable("dbo.Reviews");
            DropTable("dbo.Role_tbl");
            DropTable("dbo.Registers");
            DropTable("dbo.order_tbl");
            DropTable("dbo.FAQs");
            DropTable("dbo.Products");
            DropTable("dbo.Categories");
        }
    }
}
