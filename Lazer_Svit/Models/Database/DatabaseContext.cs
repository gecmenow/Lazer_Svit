using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Threading;
using System.Web;

namespace Lazer_Svit.Models.Database
{
    public class DatabaseContext: DbContext
    {
        public DatabaseContext() : base("Lazer_Svit_Connection")
        {
        }
        public DbSet<DbItems> ItemsDB { get; set; }
        public DbSet<DbCategory> CategoryDB { get; set; }
        public DbSet<DbProductReview> ProductReviewsDB { get; set; }
        public DbSet<DbFeedback> FeedbackDB { get; set; }
        public DbSet<DbOrder> OrderDB { get; set; }
        public DbSet<DbAdmin> AdminDB { get; set; }
        public DbSet<DBUserWork> UserWorkDB { get; set; }
        public DbSet<DbAcrylic> AcrylicDB { get; set; }
        public DbSet<DbWoods> WoodsDB { get; set; }
        public DbSet<DbEngraving> EngravingDB { get; set; }
        public DbSet<DBUVPrinting> UVPrintingDB { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}