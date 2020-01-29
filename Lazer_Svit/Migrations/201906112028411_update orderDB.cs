namespace Lazer_Svit.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateorderDB : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DbOrders", "OrderTime", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.DbOrders", "OrderTime");
        }
    }
}
