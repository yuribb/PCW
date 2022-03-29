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
                .ForMember(d => d.TagIds, cd => cd.MapFrom(s => s.TagIds))
                .ForMember(d => d.File, cd => cd.MapFrom(s => s.File.Content.ToByteArray()));
        }

        private class RepeatedFieldToListTypeConverter<TITemSource, TITemDest> : ITypeConverter<RepeatedField<TITemSource>, List<TITemDest>>
        {
            public List<TITemDest> Convert(RepeatedField<TITemSource> source, List<TITemDest> destination, ResolutionContext context)
            {
                destination.AddRange(source.Select(item => context.Mapper.Map<TITemDest>(item)));
                return destination;
            }
        }
    }
}
