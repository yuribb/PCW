namespace PCW.Api.Commands
{
    public class AddPostCardCommand
    {
        public string Name { get; set; } = default!;
        public string ContentType { get; set; } = default!;
        public IFormFile File { get; set; } = default!;
        public IReadOnlyCollection<long> TagIds { get; set; } = new List<long>(5);
    }
}
