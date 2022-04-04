using Microsoft.EntityFrameworkCore;
using PCW.Data.Entities;

namespace PCW.Interfaces
{
    public interface IPostCardDbContext
    {
        DbSet<PostCard> PostCards { get; set; }
        DbSet<Tag> Tags { get; set; }
        DbSet<PostCardTag> PostCardTag { get; set; }
        Task<int> Save(CancellationToken cancellationToken = default);
        bool CreateDbIfNotExist();

    }
}
