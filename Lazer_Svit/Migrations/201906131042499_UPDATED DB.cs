namespace Lazer_Svit.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UPDATEDDB : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DbOrders", "TotalCost", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.DbOrders", "TotalCost");
        }
    }
}
