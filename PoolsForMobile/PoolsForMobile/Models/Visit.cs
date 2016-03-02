using System.Collections.Generic;

namespace PoolsForAndroid.Models
{
    public partial class Visit
    {
        public Visit()
        {
            Places = new HashSet<Place>();
            Users = new HashSet<User>();
        }

        public int Id { get; set; }

        public System.DateTime Date { get; set; }

        public virtual ICollection<Place> Places { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}