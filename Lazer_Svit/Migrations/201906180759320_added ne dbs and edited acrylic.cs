namespace Lazer_Svit.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addednedbsandeditedacrylic : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DbEngravings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                        Price = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DbWoods",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MaterialThickness = c.String(),
                        lowCost = c.String(),
                        midCost = c.String(),
                        highCost = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.DbWoods");
            DropTable("dbo.DbEngravings");
        }
    }
}
