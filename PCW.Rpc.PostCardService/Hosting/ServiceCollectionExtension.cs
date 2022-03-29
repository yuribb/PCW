using PCW.Rpc.PostCardService.Mapping;
using PCW.Service.Hosting;

namespace PCW.Rpc.PostCardService.Hosting
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddDependencies(this IServiceCollection services)
        {
            services.AddGrpc();
            return services.AddServices().AddProtoMappingProfiles().AddPostCardDbContext();
        }

        public static IServiceCollection AddServices(this IServiceCollection services) => services.AddPostCardService();

        public static IServiceCollection AddProtoMappingProfiles(this IServiceCollection services) =>
            services.AddAutoMapper(typeof(DtoToProtoMappingProfile), typeof(ProtoToDtoMappingProfile));
    }
}
