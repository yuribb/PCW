using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using PCW.Interfaces;
using AutoMapper;
using PCW.Data.SQLite.Hosting;
using PCW.Service.Mapping;

namespace PCW.Service.Hosting
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddPostCardService(this IServiceCollection services) =>
            services.AddScoped<IPostCardService, PostCardService>()
                .AddServiceMappingProfiles();

        public static IServiceCollection AddTagService(this IServiceCollection services) =>
            services.AddScoped<ITagService, TagService>()
                .AddServiceMappingProfiles();

        public static IServiceCollection AddServiceMappingProfiles(this IServiceCollection services) =>
            services.AddAutoMapper(typeof(DtoToEntityMappingProfile), typeof(EntityToDtoMappingProfile));

        public static IServiceCollection AddPostCardDbContext(this IServiceCollection services) =>
            Data.SQLite.Hosting.ServiceCollectionExtension.AddPostCardDbContext(services);


    }
}
