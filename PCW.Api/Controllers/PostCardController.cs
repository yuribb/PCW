using AutoMapper;
using Google.Protobuf;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PCW.Api.Commands;
using PCW.Api.Commands.Responses;
using PCW.Rpc.Command;
using PCW.Rpc.PostCardService;

namespace PCW.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostCardController : ControllerBase
    {
        private readonly IWebHostEnvironment _environment;
        private readonly PostCard.PostCardClient _client;
        private readonly IMapper _mapper;

        public PostCardController(IWebHostEnvironment environment, PostCard.PostCardClient client, IMapper mapper)
        {
            _environment = environment;
            _client = client;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<AddPostCardResponse> AddPostCard([FromForm] AddPostCardCommand command)
        {
            var request = new AddPostCardRequest
            {
                File = new Rpc.Command.File
                {
                    Content = await ByteString.FromStreamAsync(command.Files.OpenReadStream()),
                },
                Name = command.Name,
                TagIds = { command.TagIds }
            };

            var response = await _client.AddPostCardAsync(request);
            var result = _mapper.Map<AddPostCardResponse>(response);
            return result;
        }
    }
}
