namespace PCW.Data.Entities
{
    public class PostCard
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string EntireName { get; set; }
        public bool Deleted { get; set; }
        public ICollection<PostCardTag> Tags { get; set; } = new List<PostCardTag>();

    }
}
