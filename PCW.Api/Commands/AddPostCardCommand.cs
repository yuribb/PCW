namespace PCW.Api.Commands
{
    public class AddPostCardCommand
    {
        public string Name { get; set; }
        public IFormFile Files { get; set; }
        public IReadOnlyCollection<long> TagIds { get; set; }
    }
}
