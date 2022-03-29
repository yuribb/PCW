using Microsoft.EntityFrameworkCore;
using PCW.Data.Entities;
using PCW.Interfaces;

namespace PCW.Data.SQLite
{
    public class PostCardDbContext : DbContext, IPostCardDbContext
    {
        public DbSet<PostCard> PostCards { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public Task<int> Save(CancellationToken cancellationToken = default)
        {
            return this.SaveChangesAsync(cancellationToken);
        }

        public bool CreateDbIfNotExist()
        {
            var ec = Database.EnsureCreated();
            Database.Migrate();
            return ec;
        }

        public PostCardDbContext(DbContextOptions<PostCardDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<PostCardTag>().HasKey(i => new { i.PostCardId, i.TagId });
        }
    }
}
