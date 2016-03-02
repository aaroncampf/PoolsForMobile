using System.Collections.Generic;

namespace PoolsForAndroid.Models
{
    public partial class Badge
    {
        public Badge()
        {
            Users = new HashSet<User>();
        }

        public int Id { get; set; }

        public string image { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}