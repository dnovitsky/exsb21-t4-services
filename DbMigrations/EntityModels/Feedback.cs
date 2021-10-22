using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbMigrations.EntityModels
{
    public class Feedback
    {
        public int Id { get; set; }
        public List<User> UserId { get; set; }
        public DateTime CreateDate { get; set; }
        public string UserReview { get; set; }
        public List<Rating> RatingId { get; set; }
    }
}
