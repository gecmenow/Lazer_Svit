namespace Lazer_Svit.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedliqpayid : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DbOrder", "LiqPayId", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.DbOrder", "LiqPayId");
        }
    }
}
