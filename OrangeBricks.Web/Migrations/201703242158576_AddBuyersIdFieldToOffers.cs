namespace OrangeBricks.Web.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class AddBuyersIdFieldToOffers : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Offers", "Buyer_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Offers", new[] { "Buyer_Id" });
            DropColumn("dbo.Offers", "Buyer_Id");
        }

        public override void Down()
        {
            DropForeignKey("dbo.Offers", "Buyer_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Offers", new[] { "Buyer_Id" });
            DropColumn("dbo.Offers", "Buyer_Id");
        }
    }
}
