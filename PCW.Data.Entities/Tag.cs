namespace PCW.Data.Entities
{
    public class Tag
    {
        public long Id { get; set; }
        public string Name { get; set; } = default!;
        public bool Deleted { get; set; }
        public ICollection<PostCardTag> PostCards { get; set; } = new List<PostCardTag>();
    }
}
