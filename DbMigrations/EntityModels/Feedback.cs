using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbMigrations.Models
{
    public class Feedback
    {
        public int Id { get; set; }
        public User UserId { get; set; }
        public string UserReview { get; set; }
        public Rating RatingId { get; set; }
    }
}
