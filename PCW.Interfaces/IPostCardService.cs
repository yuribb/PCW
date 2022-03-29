using PCW.Contracts;

namespace PCW.Interfaces
{
    public interface IPostCardService
    {
        Task<PostCardDto> GetPostCard(long id);
        Task<PostCardDto> AddPostCard(PostCardDto postCard);
        Task<PostCardDto> EditPostCard(PostCardDto postCard);
        Task<bool> RemovePostCard(long id);

        Task<bool> AddTagToPostCard(PostCardDto postCard, TagDto tag);
        Task<bool> RemoveTagFromPostCard(PostCardDto postCard, TagDto tag);
        Task<IReadOnlyCollection<PostCardDto>> GetPostCards(IReadOnlyCollection<TagDto> tags);
    }
}
