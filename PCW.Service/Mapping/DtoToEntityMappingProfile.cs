using AutoMapper;
using PCW.Contracts;
using PCW.Data.Entities;

namespace PCW.Service.Mapping
{
    public class DtoToEntityMappingProfile : Profile
    {
        public DtoToEntityMappingProfile()
        {
            CreateMap<TagDto, Tag>();
            CreateMap<PostCardDto, PostCard>();
        }
    }
}
