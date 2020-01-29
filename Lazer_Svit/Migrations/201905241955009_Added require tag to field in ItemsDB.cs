namespace Lazer_Svit.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedrequiretagtofieldinItemsDB : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.DbItems", "Category", c => c.String(nullable: false));
            AlterColumn("dbo.DbItems", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.DbItems", "Image", c => c.String(nullable: true));
            AlterColumn("dbo.DbItems", "Description", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.DbItems", "Description", c => c.String());
            AlterColumn("dbo.DbItems", "Image", c => c.String());
            AlterColumn("dbo.DbItems", "Name", c => c.String());
            AlterColumn("dbo.DbItems", "Category", c => c.String());
        }
    }
}
