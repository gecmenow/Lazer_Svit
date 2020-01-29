namespace Lazer_Svit.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedadmindb : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DbAdmins", "uniqueNumber", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.DbAdmins", "uniqueNumber");
        }
    }
}
