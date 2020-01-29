namespace Lazer_Svit.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedcountrytodb : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DbOrder", "Country", c => c.String());
            AlterColumn("dbo.DbOrder", "Items", c => c.String());
            AlterColumn("dbo.DbOrder", "Name", c => c.String());
            AlterColumn("dbo.DbOrder", "Tel", c => c.String());
            AlterColumn("dbo.DbOrder", "Email", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.DbOrder", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.DbOrder", "Tel", c => c.String(nullable: false));
            AlterColumn("dbo.DbOrder", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.DbOrder", "Items", c => c.String(nullable: false));
            DropColumn("dbo.DbOrder", "Country");
        }
    }
}
