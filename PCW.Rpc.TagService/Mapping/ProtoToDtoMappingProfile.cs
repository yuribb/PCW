using AutoMapper;
using PCW.Contracts;

namespace PCW.Rpc.TagService.Mapping
{
    public class ProtoToDtoMappingProfile : Profile
    {
        public ProtoToDtoMappingProfile()
        {
            CreateProjection<UpdateTagRequest, TagDto>();
        }
    }
}
