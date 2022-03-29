using AutoMapper;
using PCW.Api.Commands.Responses;
using PCW.Rpc.TagService;

namespace PCW.Api.Mapping
{
    public class ProtoToCommandMappingProfile : Profile
    {
        public ProtoToCommandMappingProfile()
        {
            CreateMap<GetTagReply, GetTagResponse>();
            CreateMap<AddTagReply, AddTagResponse>();
            CreateMap<UpdateTagReply, UpdateTagResponse>();
            CreateMap<DeleteTagReply, DeleteTagResponse>();
        }
    }
}
