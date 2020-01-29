namespace Lazer_Svit.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class langueageincluded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DbCategories", "NameRU", c => c.String(nullable: false));
            AddColumn("dbo.DbCategories", "NameUA", c => c.String(nullable: false));
            AddColumn("dbo.DbCategories", "NameEN", c => c.String(nullable: false));
            AddColumn("dbo.DbItems", "CategoryUA", c => c.String(nullable: false));
            AddColumn("dbo.DbItems", "CategoryRU", c => c.String(nullable: false));
            AddColumn("dbo.DbItems", "CategoryEN", c => c.String(nullable: false));
            AddColumn("dbo.DbItems", "NameUA", c => c.String(nullable: false));
            AddColumn("dbo.DbItems", "NameRU", c => c.String(nullable: false));
            AddColumn("dbo.DbItems", "NameEN", c => c.String(nullable: false));
            AddColumn("dbo.DbItems", "Image2", c => c.String(nullable: false));
            AddColumn("dbo.DbItems", "Image3", c => c.String(nullable: false));
            AddColumn("dbo.DbItems", "Image4", c => c.String(nullable: false));
            AddColumn("dbo.DbItems", "DescriptionUA", c => c.String(nullable: false));
            AddColumn("dbo.DbItems", "DescriptionRU", c => c.String(nullable: false));
            AddColumn("dbo.DbItems", "DescriptionEN", c => c.String(nullable: false));
            DropColumn("dbo.DbCategories", "Name");
            DropColumn("dbo.DbItems", "Category");
            DropColumn("dbo.DbItems", "Name");
            DropColumn("dbo.DbItems", "Description");
        }
        
        public override void Down()
        {
            AddColumn("dbo.DbItems", "Description", c => c.String(nullable: false));
            AddColumn("dbo.DbItems", "Name", c => c.String(nullable: false));
            AddColumn("dbo.DbItems", "Category", c => c.String(nullable: false));
            AddColumn("dbo.DbCategories", "Name", c => c.String(nullable: false));
            DropColumn("dbo.DbItems", "DescriptionEN");
            DropColumn("dbo.DbItems", "DescriptionRU");
            DropColumn("dbo.DbItems", "DescriptionUA");
            DropColumn("dbo.DbItems", "Image4");
            DropColumn("dbo.DbItems", "Image3");
            DropColumn("dbo.DbItems", "Image2");
            DropColumn("dbo.DbItems", "NameEN");
            DropColumn("dbo.DbItems", "NameRU");
            DropColumn("dbo.DbItems", "NameUA");
            DropColumn("dbo.DbItems", "CategoryEN");
            DropColumn("dbo.DbItems", "CategoryRU");
            DropColumn("dbo.DbItems", "CategoryUA");
            DropColumn("dbo.DbCategories", "NameEN");
            DropColumn("dbo.DbCategories", "NameUA");
            DropColumn("dbo.DbCategories", "NameRU");
        }
    }
}
