using PCW.Api.Mapping;

namespace PCW.Api.Hosting
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddApiMappingProfiles(this IServiceCollection services) =>
            services.AddAutoMapper(typeof(CommandToProtoMappingProfile), typeof(ProtoToCommandMappingProfile));

        public static IServiceCollection AddRpcClient<TClient>(this IServiceCollection services, string clientUrl) where TClient : class
        {
            services.AddGrpcClient<TClient>(o =>
            {
                o.Address = new Uri(clientUrl);
            });
            return services;
        }
    }
}
