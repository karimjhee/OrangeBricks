namespace OrangeBricks.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBookViewingsTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BookViewings",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Property_Id = c.Int(),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Properties", t => t.Property_Id)
                .Index(t => t.Property_Id);
        }
        
        public override void Down()
        {
            AddColumn("dbo.BookViewings", "PropertyId", c => c.Int(nullable: false));
            DropForeignKey("dbo.BookViewings", "Property_Id", "dbo.Properties");
            DropIndex("dbo.BookViewings", new[] { "Property_Id" });
            DropColumn("dbo.BookViewings", "Property_Id");
        }
    }
}
