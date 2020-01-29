namespace Lazer_Svit.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class orderdb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DbOrders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Items = c.String(nullable: false),
                        Name = c.String(nullable: false),
                        Tel = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Region = c.String(),
                        City = c.String(),
                        PostOffice = c.String(),
                        Delivery = c.String(),
                        Payment = c.String(),
                        PaymentStatus = c.String(),
                        OrderStatus = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.DbOrders");
        }
    }
}
