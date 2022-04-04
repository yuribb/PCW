using AutoMapper;
using Google.Protobuf.Collections;

namespace PCW.Rpc.PostCardService.Mapping
{
    public class RepeatedFieldToListTypeConverter<TITemSource, TITemDest> : ITypeConverter<RepeatedField<TITemSource>, List<TITemDest>>
    {
        public List<TITemDest> Convert(RepeatedField<TITemSource> source, List<TITemDest> destination, ResolutionContext context)
        {
            destination.AddRange(source.Select(item => context.Mapper.Map<TITemDest>(item)));
            return destination;
        }
    }
}
