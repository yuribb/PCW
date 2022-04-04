using PCW.Contracts;

namespace PCW.Interfaces
{
    public interface ITagStorage
    {
        public TagDto AddTag(string tag);
        public bool DeleteTag(TagDto tag);
    }
}
