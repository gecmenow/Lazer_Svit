namespace Lazer_Svit.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddimagefieldinItemsDB : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DbItems", "Image", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.DbItems", "Image");
        }
    }
}
