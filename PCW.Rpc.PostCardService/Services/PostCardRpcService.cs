using AutoMapper;
using Grpc.Core;
using PCW.Contracts;
using PCW.Interfaces;

namespace PCW.Rpc.PostCardService.Services
{
    public class PostCardRpcService : PostCard.PostCardBase
    {
        private readonly IMapper _mapper;
        private readonly IPostCardService _service;

        public PostCardRpcService(IMapper mapper, IPostCardService service)
        {
            _mapper = mapper;
            _service = service;
        }

        public override async Task<GetPostCardReply> GetPostCard(GetPostCardRequest request, ServerCallContext context)
        {
            var dto = await _service.GetPostCard(request.Id);
            var reply = _mapper.Map<GetPostCardReply>(dto);
            return reply;
        }

        public override async Task<AddPostCardReply> AddPostCard(AddPostCardRequest request, ServerCallContext context)
        {
            var dto = _mapper.Map<PostCardDto>(request);
            dto = await _service.AddPostCard(dto);
            var reply = _mapper.Map<AddPostCardReply>(dto);
            return reply;
        }
    }
}
