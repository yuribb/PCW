using PCW.Contracts;
using PCW.Data.Entities;
using PCW.Interfaces;

namespace PCW.Service
{
    public class PostCardService : IPostCardService
    {
        private readonly IPostCardStorage _storage;
        private readonly IPostCardDbContext _db;

        public PostCardService(IPostCardStorage storage,
            IPostCardDbContext db)
        {
            _storage = storage;
            _db = db;
            _db.CreateDbIfNotExist();
        }

        public Task<PostCardDto> GetPostCard(long id)
        {
            throw new NotImplementedException();
        }

        public async Task<PostCardDto> AddPostCard(PostCardDto postCard)
        {
            var name = await _storage.AddPostCard(postCard.ContentType, postCard.File);
            var newPostCard = new PostCard {Name = postCard.Name, EntireName = name};
            _db.PostCards.Add(newPostCard);
            await _db.Save();
            postCard.Id = newPostCard.Id;

            if (postCard.TagIds.Any())
            {
                foreach (var tagId in postCard.TagIds)
                {
                    var pct = new PostCardTag { PostCardId = postCard.Id, TagId = tagId };
                    await _db.PostCardTag.AddAsync(pct);
                }
                await _db.Save();
            }
            return postCard;
        }

        public Task<PostCardDto> EditPostCard(PostCardDto postCard)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemovePostCard(long id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> AddTagToPostCard(PostCardDto postCard, TagDto tag)
        {

            throw new NotImplementedException();
        }

        public Task<bool> RemoveTagFromPostCard(PostCardDto postCard, TagDto tag)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyCollection<PostCardDto>> GetPostCards(IReadOnlyCollection<TagDto> tags)
        {
            throw new NotImplementedException();
        }
    }
}
