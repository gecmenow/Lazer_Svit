using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lazer_Svit.Models.Database
{
    public class DbProductReview
    {
        public int Id { get; set; }
        public int ItemId { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public int UserRating { get; set; }
        public string UserReview { get; set; }
        public DateTime ReviewPostDate { get; set; }
    }
}