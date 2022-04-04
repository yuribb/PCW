using PCW.Contracts.Exceptions;
using PCW.Interfaces;

namespace PCW.Storage.FileStorage
{
    public class FileStorage : IPostCardStorage
    {
        private readonly string _storagePath;

        public FileStorage(string storagePath)
        {
            _storagePath = storagePath;
            if (!Directory.Exists(_storagePath))
            {
                Directory.CreateDirectory(_storagePath);
            }
        }

        public async Task<string> AddPostCard(string contentType, byte[] content)
        {
            var fileUniqueName = UniqueNameGenerator.GetName(contentType);
            var filePath = GetFilePath(contentType, fileUniqueName);
            await File.WriteAllBytesAsync(filePath, content);
            return fileUniqueName;
        }

        public async Task<bool> DeletePostCard(string uniqueName)
        {
            await Task.Run(() =>
            {
                var filePath = GetExistingFilePath(uniqueName, false);
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }
            });
            return true;
        }

        public string UpdatePostCard(string uniqueName, string contentType, byte[] content)
        {
            throw new NotImplementedException();
        }

        private string GetExistingFilePath(string uniqueName, bool throwException = true)
        {
            var filePath = Path.Combine(_storagePath, uniqueName);
            if (!File.Exists(filePath) && throwException)
            {
                throw new FileNotFoundException(filePath);
            }
            return filePath;
        }

        private string GetFilePath(string contentType, string? name = null)
        {
            var filePath = Path.Combine(_storagePath, name ?? UniqueNameGenerator.GetName(contentType));
            if (File.Exists(filePath))
            {
                throw new FileExistException(filePath);
            }
            return filePath;
        }
    }
}