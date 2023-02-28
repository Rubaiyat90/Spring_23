namespace EFCodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SDPTableCreated : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        Description = c.String(),
                        OfferedBy = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Departments", t => t.OfferedBy, cascadeDelete: true)
                .Index(t => t.OfferedBy);
            
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        Cgpa = c.Single(),
                        DepartmentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Departments", t => t.DepartmentId, cascadeDelete: true)
                .Index(t => t.DepartmentId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Courses", "OfferedBy", "dbo.Departments");
            DropForeignKey("dbo.Students", "DepartmentId", "dbo.Departments");
            DropIndex("dbo.Students", new[] { "DepartmentId" });
            DropIndex("dbo.Courses", new[] { "OfferedBy" });
            DropTable("dbo.Students");
            DropTable("dbo.Departments");
            DropTable("dbo.Courses");
        }
    }
}
