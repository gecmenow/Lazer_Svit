namespace Lazer_Svit.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateditemsdb : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DbItems", "orderCount", c => c.Int(nullable: true));
        }
        
        public override void Down()
        {
            DropColumn("dbo.DbItems", "orderCount");
        }
    }
}
