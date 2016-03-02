using System.Collections.Generic;
namespace PoolsForAndroid.Models
{
    public partial class User
    {
        public User()
        {
            Comments = new HashSet<Comment>();
            Reviews = new HashSet<Review>();
            Badges = new HashSet<Badge>();
            Visits = new HashSet<Visit>();
        }

        public int Id { get; set; }

        public string name { get; set; }

        public string email { get; set; }

        public string password { get; set; }

        public string Avatar { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }

        public virtual ICollection<Review> Reviews { get; set; }

        public virtual ICollection<Badge> Badges { get; set; }

        public virtual ICollection<Visit> Visits { get; set; }
    }
}