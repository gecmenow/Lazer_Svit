namespace Lazer_Svit.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedfieldinItemsDB : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.DbItems", "Image");
        }
        
        public override void Down()
        {
            AddColumn("dbo.DbItems", "Image", c => c.String(nullable: false));
        }
    }
}
