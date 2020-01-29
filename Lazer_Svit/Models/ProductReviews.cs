using Lazer_Svit.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lazer_Svit.Models
{
    public class ProductReviews
    {
        DatabaseContext _db = new DatabaseContext();

        public IEnumerable<DbProductReview> GetReview(int id)
        {
            var data =
                (from entry in _db.ProductReviewsDB
                 where entry.ItemId == id
                 select entry).ToList();

            for(int i = 0; i < data.Count; i++)
            {
                data[i].ReviewPostDate = data[i].ReviewPostDate.Date;
            }

            return data;
        }

        public void AddReview(int id, string name, string email, int rate, string message)
        {
            _db.ProductReviewsDB.Add(
                new DbProductReview
                { 
                    ItemId = id,
                    UserName = name,
                    UserEmail = email,
                    UserRating = rate,
                    UserReview = message,
                    ReviewPostDate = DateTime.Now                    
                });

            _db.SaveChanges();
        }

        public void DeleteReview(int id)
        {
            var review = _db.ProductReviewsDB.Find(id);

            _db.ProductReviewsDB.Remove(review);

            _db.SaveChanges();
        }
    }
}