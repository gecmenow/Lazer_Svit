namespace Lazer_Svit.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addordertimeforuserwork : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DBUserWorks", "FileTime", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.DBUserWorks", "FileTime");
        }
    }
}
