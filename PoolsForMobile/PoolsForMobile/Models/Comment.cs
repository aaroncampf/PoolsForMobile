namespace PoolsForAndroid.Models
{
    public partial class Comment
    {
        public int Id { get; set; }

        public string text { get; set; }

        public System.DateTime Date { get; set; }

        public int? User_Id { get; set; }

        public int Place_Id { get; set; }

        public virtual Place Place { get; set; }

        public virtual User User { get; set; }
    }
}