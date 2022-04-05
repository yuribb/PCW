using Microsoft.EntityFrameworkCore;
using PCW.Data.Entities;
using PCW.Interfaces;

namespace PCW.Data.SQLite
{
    public class PostCardDbContext : DbContext, IPostCardDbContext
    {
        public DbSet<PostCard> PostCards { get; set; } = default!;
        public DbSet<PostCardTag> PostCardTag { get; set; } = default!;
        public DbSet<Tag> Tags { get; set; } = default!;
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

        public PostCardDbContext(DbContextOptions<PostCardDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<PostCardTag>().HasKey(c => new { c.PostCardId, c.TagId });

            builder.Entity<Tag>()
                .HasMany(c => c.PostCards);

            builder.Entity<PostCard>()
                .HasMany(c => c.Tags);
        }
    }
}
