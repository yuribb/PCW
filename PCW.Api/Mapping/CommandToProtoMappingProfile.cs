using AutoMapper;
using Google.Protobuf;
using Google.Protobuf.Collections;
using PCW.Api.Commands;
using PCW.Rpc.PostCardService;

namespace PCW.Api.Mapping
{
    public class CommandToProtoMappingProfile : Profile
    {
        public CommandToProtoMappingProfile()
        {
            //CreateMap<IFormFile, Rpc.Command.File>()
            //    .ForMember(x => x, cd => cd.MapFrom(map => ByteString.FromStream(map.OpenReadStream())));

            //CreateMap<IFormFile, Rpc.Command.File>()
            //    .
            //    .ForMember(d => d.UserName,
            //        opt => opt.MapFrom(src => userName)
            //    );

            CreateMap(typeof(IReadOnlyCollection<>), typeof(RepeatedField<>)).ConvertUsing(typeof(EnumerableToRepeatedFieldTypeConverter<,>));

            CreateMap<AddPostCardCommand, AddPostCardRequest>()
                .ForMember(x => x.Name, cd => cd.MapFrom(map => map.Name))
                .ForMember(x => x.TagIds, cd => cd.MapFrom(map => map.TagIds))
                .ForMember(x => x.File, cd => cd.MapFrom(map => map.Files));

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
