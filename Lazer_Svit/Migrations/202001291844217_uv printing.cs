namespace Lazer_Svit.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class uvprinting : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DBUVPrinting",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        cells1 = c.String(),
                        cells2 = c.String(),
                        cells3 = c.String(),
                        cells4 = c.String(),
                        cells5 = c.String(),
                        cells6 = c.String(),
                        cells7 = c.String(),
                        cells8 = c.String(),
                        cells9 = c.String(),
                        cells10 = c.String(),
                        cells11 = c.String(),
                        cells12 = c.String(),
                        cells13 = c.String(),
                        cells14 = c.String(),
                        cells15 = c.String(),
                        cells16 = c.String(),
                        cells17 = c.String(),
                        cells18 = c.String(),
                        cells19 = c.String(),
                        cells20 = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.DBUVPrinting");
        }
    }
}
