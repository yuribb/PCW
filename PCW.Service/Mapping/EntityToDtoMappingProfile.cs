using AutoMapper;
using PCW.Contracts;
using PCW.Data.Entities;

namespace PCW.Service.Mapping
{
    public class EntityToDtoMappingProfile : Profile
    {
        public EntityToDtoMappingProfile()
        {
            CreateMap<Tag, TagDto>();
            CreateMap<PostCard, PostCardDto>();
        }
    }
}
