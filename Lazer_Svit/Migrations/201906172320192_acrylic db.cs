namespace Lazer_Svit.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class acrylicdb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DbAcrylics",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        materialThickness = c.String(),
                        lowCost = c.String(),
                        midCost = c.String(),
                        highCost = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.DbAcrylics");
        }
    }
}
