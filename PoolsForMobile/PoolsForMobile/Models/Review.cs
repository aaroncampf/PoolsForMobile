namespace PoolsForAndroid.Models
{
    public partial class Review
    {
        public int Id { get; set; }

        public string review { get; set; }

        public short rating { get; set; }

        public int Place_Id { get; set; }

        public int? User_Id { get; set; }

        public virtual Place Place { get; set; }

        public virtual User User { get; set; }
    }
}