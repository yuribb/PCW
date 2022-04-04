using PCW.Contracts.Configuration;
using PCW.Rpc.PostCardService.Mapping;
using PCW.Service.Hosting;
using PCW.Storage.FileStorage.Hosting;

namespace PCW.Rpc.PostCardService.Hosting
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddDependencies(this IServiceCollection services, StorageSettings storageSettings)
        {
            services.AddGrpc();
            return services.AddServices().AddProtoMappingProfiles().AddPostCardDbContext().AddStorage(storageSettings.Path);
        }

        public static IServiceCollection AddServices(this IServiceCollection services) => services.AddPostCardService();

        public static IServiceCollection AddProtoMappingProfiles(this IServiceCollection services) =>
            services.AddAutoMapper(typeof(DtoToProtoMappingProfile), typeof(ProtoToDtoMappingProfile));

        public static T GetSettings<T>(this WebApplicationBuilder builder, string? sectionName = null) where T : class
        {
            return builder.Configuration.GetSection(sectionName ?? typeof(T).Name).Get<T>();
        }
    }
}
