using PCW.Contracts;

namespace PCW.Interfaces
{
    public interface ITagService
    {
        Task<TagDto> GetTag(long id);
        Task<TagDto> AddTag(string name);
        Task<TagDto> UpdateTag(TagDto tag);
        Task<bool> DeleteTag(long id);
    }
}
