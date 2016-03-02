using System.Collections.Generic;

namespace PoolsForAndroid.Models
{

    public partial class Place
    {
        public Place()
        {
            Comments = new HashSet<Comment>();
            Reviews = new HashSet<Review>();
            Visits = new HashSet<Visit>();
        }

        public int Id { get; set; }

        public string name { get; set; }

        public string address { get; set; }

        public string city { get; set; }

        public string state { get; set; }

        public int zip { get; set; }

        public string phone { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }

        public virtual ICollection<Review> Reviews { get; set; }

        public virtual ICollection<Visit> Visits { get; set; }
    }
}