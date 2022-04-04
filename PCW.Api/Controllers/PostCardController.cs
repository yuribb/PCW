using AutoMapper;
using Google.Protobuf;
using Microsoft.AspNetCore.Mvc;
using PCW.Api.Commands;
using PCW.Api.Commands.Responses;
using PCW.Rpc.PostCardService;

namespace PCW.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostCardController : ControllerBase
    {
        private readonly PostCard.PostCardClient _client;
        private readonly IMapper _mapper;

        public PostCardController(PostCard.PostCardClient client, IMapper mapper)
        {
            _client = client;
            _mapper = mapper;
        }

        [HttpGet("{id:long}")]
        public async Task<GetPostCardResponse> GetPostCard(long id)
        {
            var response = await _client.GetPostCardAsync(new GetPostCardRequest {Id =  id});
            var result = _mapper.Map<GetPostCardResponse>(response);
            return result;
        }

        [HttpPost]
        public async Task<AddPostCardResponse> AddPostCard([FromForm] AddPostCardCommand command)
        {
            var request = new AddPostCardRequest
            {
                File = new Rpc.Command.File
                {
                    Content = await ByteString.FromStreamAsync(command.File.OpenReadStream()),
                },
                Name = command.Name,
                ContentType = command.ContentType,
                TagIds = { command.TagIds }
            };

            var response = await _client.AddPostCardAsync(request);
            var result = _mapper.Map<AddPostCardResponse>(response);
            return result;
        }
    }
}
