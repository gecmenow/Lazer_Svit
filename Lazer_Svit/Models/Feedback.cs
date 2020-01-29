using Lazer_Svit.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lazer_Svit.Models
{
    public class Feedback
    {
        DatabaseContext _db = new DatabaseContext();

        public IEnumerable<DbFeedback> GetFeedbacks()
        {
            var data =
                (from entry in _db.FeedbackDB
                 select entry).ToList();

            for (int i = 0; i < data.Count; i++)
            {
                data[i].ReviewPostDate = data[i].ReviewPostDate.Date;
            }

            return data;
        }

        public void AddFeedback(string name, string email, int rate, string message)
        {
            _db.FeedbackDB.Add(
                new DbFeedback
                {
                    UserName = name,
                    UserEmail = email,
                    UserRating = rate,
                    UserReview = message,
                    ReviewPostDate = DateTime.Now
                });

            _db.SaveChanges();
        }

        public void DeleteFeedback(int id)
        {
            var data = _db.FeedbackDB.Find(id);

            _db.FeedbackDB.Remove(data);

            _db.SaveChanges();
        }
    }
}