using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PCW.Contracts;
using PCW.Data;
using PCW.Interfaces;

namespace PCW.Service
{
    public class PostCardService : IPostCardService
    {
        //private readonly IPostCardStorage _storage;
        private readonly IPostCardDbContext _db;

        public PostCardService(/*IPostCardStorage storage,*/
            IPostCardDbContext db)
        {
            //_storage = storage;
            _db = db;
            _db.CreateDbIfNotExist();
        }

        public Task<PostCardDto> GetPostCard(long id)
        {
            throw new NotImplementedException();
        }

        public Task<PostCardDto> AddPostCard(PostCardDto postCard)
        {
            throw new NotImplementedException();
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
