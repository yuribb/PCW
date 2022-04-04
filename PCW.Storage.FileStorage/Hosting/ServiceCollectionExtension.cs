using Microsoft.Extensions.DependencyInjection;
using PCW.Interfaces;

namespace PCW.Storage.FileStorage.Hosting
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddStorage(this IServiceCollection services, string storagePath) =>
            services.AddScoped<IPostCardStorage>(_ => new FileStorage(storagePath));
    }
}
