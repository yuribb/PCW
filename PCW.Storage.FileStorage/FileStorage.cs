using System.Diagnostics.CodeAnalysis;
using PCW.Contracts;
using PCW.Contracts.Exceptions;
using PCW.Interfaces;

namespace PCW.Storage.FileStorage
{
    public class FileStorage : IPostCardStorage
    {
        private readonly string _storagePath = default!;

        public FileStorage(string storagePath)
        {
            _storagePath = storagePath;
        }

        public async Task<string> AddPostCard(string contentType, byte[] content)
        {
            var filePath = GetFilePath(contentType);
            await File.WriteAllBytesAsync(filePath, content);
            return filePath;
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

        private string GetFilePath(string contentType)
        {
            var filePath = Path.Combine(_storagePath, UniqueNameGenerator.GetName(contentType));
            if (File.Exists(filePath))
            {
                throw new FileExistException(filePath);
            }
            return filePath;
        }
    }
}