using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbMigrations.EntityModels
{
    public class Feedback
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public List<User> UserId { get; set; }
        [Required]
        public DateTime CreateDate { get; set; }
        [Required]
        public string UserReview { get; set; }
        public List<Rating> RatingId { get; set; }
    }
}
