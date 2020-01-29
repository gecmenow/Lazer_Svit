namespace Lazer_Svit.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedurlNameincategrydb : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DbCategories", "urlName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.DbCategories", "urlName");
        }
    }
}
