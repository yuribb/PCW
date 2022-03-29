using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PCW.Data.Entities;

namespace PCW.Interfaces
{
    public interface IPostCardDbContext
    {
        DbSet<PostCard> PostCards { get; set; }
        DbSet<Tag> Tags { get; set; }
        Task<int> Save(CancellationToken cancellationToken = default);
        bool CreateDbIfNotExist();

    }
}
