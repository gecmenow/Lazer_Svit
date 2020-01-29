namespace Lazer_Svit.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedreviewdb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DbProductReviews",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ItemId = c.Int(nullable: false),
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
            DropTable("dbo.DbProductReviews");
        }
    }
}
