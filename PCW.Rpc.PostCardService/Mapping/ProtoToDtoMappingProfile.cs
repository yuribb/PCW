using AutoMapper;
using Google.Protobuf.Collections;
using PCW.Contracts;

namespace PCW.Rpc.PostCardService.Mapping
{
    public class ProtoToDtoMappingProfile : Profile
    {
        public ProtoToDtoMappingProfile()
        {
            CreateMap(typeof(RepeatedField<>), typeof(List<>)).ConvertUsing(typeof(RepeatedFieldToListTypeConverter<,>));

            CreateMap<AddPostCardRequest, PostCardDto>()
                .ForMember(d => d.Id, cd => cd.Ignore())
                .ForMember(d => d.Name, cd => cd.MapFrom(s => s.Name))
                .ForMember(d => d.ContentType, cd => cd.MapFrom(s => s.ContentType))
                .ForMember(d => d.TagIds, cd => cd.MapFrom(s => s.TagIds))
                .ForMember(d => d.File, cd => cd.MapFrom(s => s.File.Content.ToByteArray()));
        }
    }
}
