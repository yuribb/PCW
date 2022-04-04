using AutoMapper;
using Google.Protobuf.Collections;
using PCW.Api.Commands;
using PCW.Rpc.PostCardService;

namespace PCW.Api.Mapping
{
    public class CommandToProtoMappingProfile : Profile
    {
        public CommandToProtoMappingProfile()
        {
            CreateMap(typeof(IReadOnlyCollection<>), typeof(RepeatedField<>)).ConvertUsing(typeof(EnumerableToRepeatedFieldTypeConverter<,>));

            CreateMap<AddPostCardCommand, AddPostCardRequest>();
            CreateMap<AddTagCommand, Rpc.TagService.AddTagRequest>();
            CreateMap<UpdateTagCommand, Rpc.TagService.UpdateTagRequest>();
        }

        private class EnumerableToRepeatedFieldTypeConverter<TITemSource, TITemDest> : ITypeConverter<IEnumerable<TITemSource>, RepeatedField<TITemDest>>
        {
            public RepeatedField<TITemDest> Convert(IEnumerable<TITemSource> source, RepeatedField<TITemDest> destination, ResolutionContext context)
            {
                foreach (var item in source)
                {
                    destination.Add(context.Mapper.Map<TITemDest>(item));
                }
                return destination;
            }
        }

    }
}
