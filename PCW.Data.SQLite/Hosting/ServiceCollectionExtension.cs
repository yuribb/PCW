using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PCW.Interfaces;

namespace PCW.Data.SQLite.Hosting
{
    public static class ServiceCollectionExtension
    {
        private const string DB_NAME = "pcw.db";
        public static IServiceCollection AddPostCardDbContext(this IServiceCollection services)
        {
            var dbFolder = $"{Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)}\\PCW\\";
            if (!Directory.Exists(dbFolder))
            {
                Directory.CreateDirectory(dbFolder);
            }

            services.AddEntityFrameworkSqlite().AddDbContext<PostCardDbContext>(options =>
            {
                options.UseSqlite($"DataSource=\"{dbFolder}\\{DB_NAME}\"");
            });
            services.AddScoped<IPostCardDbContext, PostCardDbContext>();

            return services;
        }
    }
}
