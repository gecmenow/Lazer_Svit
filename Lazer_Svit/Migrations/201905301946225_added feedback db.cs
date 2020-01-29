namespace Lazer_Svit.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedfeedbackdb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DbFeedbacks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        UserEmail = c.String(),
                        UserRating = c.Int(nullable: false),
                        UserReview = c.String(),
                        ReviewPostDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.DbFeedbacks");
        }
    }
}
