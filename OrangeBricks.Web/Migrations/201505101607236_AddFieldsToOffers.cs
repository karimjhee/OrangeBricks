namespace OrangeBricks.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFieldsToOffers : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Offers", "Status", c => c.Int(nullable: false));
            AddColumn("dbo.Offers", "Buyer_Id", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Offers", "Buyer_Id");
            AddForeignKey("dbo.Offers", "Buyer_Id", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddColumn("dbo.Offers", "CreatedAt", c => c.DateTime(nullable: false));
            AddColumn("dbo.Offers", "UpdatedAt", c => c.DateTime(nullable: false));
        }

        public override void Down()
        {
            DropForeignKey("dbo.Offers", "Buyer_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Offers", new[] { "Buyer_Id" });
            DropColumn("dbo.Offers", "Buyer_Id");
            DropColumn("dbo.Offers", "UpdatedAt");
            DropColumn("dbo.Offers", "CreatedAt");
            DropColumn("dbo.Offers", "Status");
        }
    }
}
