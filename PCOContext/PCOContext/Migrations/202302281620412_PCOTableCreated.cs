namespace PCOContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PCOTableCreated : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Price = c.Int(),
                        Qty = c.Int(nullable: false),
                        Cid = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.Cid, cascadeDelete: true)
                .Index(t => t.Cid);
            
            CreateTable(
                "dbo.OrderDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Qty = c.Int(nullable: false),
                        Price = c.Int(nullable: false),
                        PId = c.Int(nullable: false),
                        OId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Orders", t => t.OId, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.PId, cascadeDelete: true)
                .Index(t => t.PId)
                .Index(t => t.OId);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrderDate = c.DateTime(nullable: false),
                        Status = c.String(),
                        Amount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderDetails", "PId", "dbo.Products");
            DropForeignKey("dbo.OrderDetails", "OId", "dbo.Orders");
            DropForeignKey("dbo.Products", "Cid", "dbo.Categories");
            DropIndex("dbo.OrderDetails", new[] { "OId" });
            DropIndex("dbo.OrderDetails", new[] { "PId" });
            DropIndex("dbo.Products", new[] { "Cid" });
            DropTable("dbo.Orders");
            DropTable("dbo.OrderDetails");
            DropTable("dbo.Products");
            DropTable("dbo.Categories");
        }
    }
}
