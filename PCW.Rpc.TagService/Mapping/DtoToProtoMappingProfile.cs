using AutoMapper;
using PCW.Contracts;

namespace PCW.Rpc.TagService.Mapping
{
    public class DtoToProtoMappingProfile : Profile
    {
        public DtoToProtoMappingProfile()
        {
            CreateMap<TagDto, GetTagReply>();
            CreateMap<TagDto, AddTagReply>();
            CreateMap<TagDto, UpdateTagReply>();
        }
    }
}
