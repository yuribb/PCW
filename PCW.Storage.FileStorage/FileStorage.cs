using PCW.Contracts;
using PCW.Interfaces;

namespace PCW.Storage.FileStorage
{
    public class FileStorage : IPostCardStorage
    {
        public string AddPostCard(string contentType, byte[] content)
        {

            throw new NotImplementedException();
        }

        public bool DeletePostCard(string uniqueName)
        {
            throw new NotImplementedException();
        }
    }
}