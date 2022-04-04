namespace PCW.Interfaces
{
    public interface IPostCardStorage
    {
        public Task<string> AddPostCard(string contentType, byte[] content);
        public Task<bool> DeletePostCard(string uniqueName);
    }
}
