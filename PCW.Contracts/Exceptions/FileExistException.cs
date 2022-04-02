namespace PCW.Contracts.Exceptions
{
    public class FileExistException : ApplicationException
    {
        public string Path { get; }
        public override string Message => $"File \"{Path}\" already exists";

        public FileExistException(string path)
        {
            Path = path;
        }
    }
}
