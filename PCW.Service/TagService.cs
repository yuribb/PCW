using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PCW.Contracts;
using PCW.Contracts.Exceptions;
using PCW.Data.Entities;
using PCW.Interfaces;

namespace PCW.Service
{
    public class TagService : ITagService
    {
        private readonly IPostCardDbContext _db;
        private readonly IMapper _mapper;
        public TagService(IPostCardDbContext db, IMapper mapper)
        {
            _db = db;
            _db.CreateDbIfNotExist();
            _mapper = mapper;
        }

        public async Task<TagDto> GetTag(long id)
        {
            var tag = await GetTagEntity(id, true);
            var result = _mapper.Map<TagDto>(tag);
            return result;
        }

        public async Task<TagDto> AddTag(string name)
        {
            var loverName = name.ToLowerInvariant();
            var tag = await _db.Tags.FirstOrDefaultAsync(t => t.Name == loverName);
            if (tag == null)
            {
                tag = new Tag { Name = name };
                await _db.Tags.AddAsync(tag);
                await _db.Save();
            }
            var result = _mapper.Map<TagDto>(tag);
            return result;
        }

        public async Task<TagDto> UpdateTag(TagDto tag)
        {
            var currentTag = await GetTagEntity(tag.Id);
            var loverName = tag.Name.ToLowerInvariant();

            if (currentTag.Name != loverName)
            {
                currentTag.Name = loverName;
                await _db.Save();
            }
            var result = _mapper.Map<TagDto>(currentTag);
            return result;
        }

        public async Task<bool> DeleteTag(long id)
        {
            var tag = await GetTagEntity(id);
            if (!tag.Deleted)
            {
                tag.Deleted = true;
                await _db.Save();
            }
            return true;
        }

        private async Task<Tag> GetTagEntity(long id, bool asNoTracking = false)
        {
            var query = _db.Tags.Where(t => !t.Deleted);
            if (asNoTracking)
            {
                query = query.AsNoTracking();
            }
            var tag = await query.FirstOrDefaultAsync(t => t.Id == id);
            if (tag == null)
            {
                throw new DataNotFoundException(typeof(Tag), id);
            }
            return tag;
        }
    }
}
