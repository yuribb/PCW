using AutoMapper;
using Google.Protobuf.Collections;
using PCW.Contracts;

namespace PCW.Rpc.PostCardService.Mapping
{
    public class DtoToProtoMappingProfile : Profile
    {
        public DtoToProtoMappingProfile()
        {
            CreateMap(typeof(RepeatedField<>), typeof(List<>)).ConvertUsing(typeof(RepeatedFieldToListTypeConverter<,>));

            CreateMap<PostCardDto, AddPostCardReply>();
        }
    }
}
