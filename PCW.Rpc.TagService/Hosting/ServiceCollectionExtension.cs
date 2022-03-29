using PCW.Interfaces;
using PCW.Rpc.TagService.Mapping;
using PCW.Service;
using PCW.Service.Hosting;
using PCW.Service.Mapping;

namespace PCW.Rpc.TagService.Hosting
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddDependencies(this IServiceCollection services)
        {

            services.AddGrpc();
            return services.AddServices().AddProtoMappingProfiles().AddPostCardDbContext();
        }

        public static IServiceCollection AddServices(this IServiceCollection services) => services.AddTagService();

        public static IServiceCollection AddProtoMappingProfiles(this IServiceCollection services) =>
            services.AddAutoMapper(typeof(DtoToProtoMappingProfile), typeof(ProtoToDtoMappingProfile));
    }
}
