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

        public PostCardController(IWebHostEnvironment environment, PostCard.PostCardClient client)
        {
            _environment = environment;
            _client = client;
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

            return new AddPostCardResponse();
        }
    }
}
