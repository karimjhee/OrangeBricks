namespace OrangeBricks.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBookViewingsFields : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BookViewings", "BuyerUserId", c => c.String(nullable: false));
            AddColumn("dbo.BookViewings", "Appointment", c => c.DateTime(nullable: false));
            AddColumn("dbo.BookViewings", "Status", c => c.Int(nullable: false));
            AddColumn("dbo.BookViewings", "CreatedAt", c => c.DateTime(nullable: false));
            AddColumn("dbo.BookViewings", "UpdatedAt", c => c.DateTime(nullable: false));
        }

        public override void Down()
        {
            DropColumn("dbo.BookViewings", "BuyerUserId");
            DropColumn("dbo.BookViewings", "Appointment");
            DropColumn("dbo.BookViewings", "Status");
            DropColumn("dbo.BookViewings", "CreatedAt");
            DropColumn("dbo.BookViewings", "UpdatedAt");
        }
    }
}
