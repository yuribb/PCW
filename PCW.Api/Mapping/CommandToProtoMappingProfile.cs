using AutoMapper;

namespace PCW.Api.Mapping
{
    public class CommandToProtoMappingProfile : Profile
    {
        public CommandToProtoMappingProfile()
        {
            CreateMap<Commands.AddTagCommand, Rpc.TagService.AddTagRequest>();
            CreateMap<Commands.UpdateTagCommand, Rpc.TagService.UpdateTagRequest>();
        }
    }
}
