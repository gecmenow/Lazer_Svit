namespace Lazer_Svit.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class testdberror : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.DbAcrylics", newName: "DbAcrylic");
            RenameTable(name: "dbo.DbAdmins", newName: "DbAdmin");
            RenameTable(name: "dbo.DbCategories", newName: "DbCategory");
            RenameTable(name: "dbo.DbEngravings", newName: "DbEngraving");
            RenameTable(name: "dbo.DbFeedbacks", newName: "DbFeedback");
            RenameTable(name: "dbo.DbOrders", newName: "DbOrder");
            RenameTable(name: "dbo.DbProductReviews", newName: "DbProductReview");
            RenameTable(name: "dbo.DBUserWorks", newName: "DBUserWork");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.DBUserWork", newName: "DBUserWorks");
            RenameTable(name: "dbo.DbProductReview", newName: "DbProductReviews");
            RenameTable(name: "dbo.DbOrder", newName: "DbOrders");
            RenameTable(name: "dbo.DbFeedback", newName: "DbFeedbacks");
            RenameTable(name: "dbo.DbEngraving", newName: "DbEngravings");
            RenameTable(name: "dbo.DbCategory", newName: "DbCategories");
            RenameTable(name: "dbo.DbAdmin", newName: "DbAdmins");
            RenameTable(name: "dbo.DbAcrylic", newName: "DbAcrylics");
        }
    }
}
