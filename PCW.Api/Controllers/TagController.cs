using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PCW.Api.Commands;
using PCW.Api.Commands.Responses;
using PCW.Rpc.TagService;

namespace PCW.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagController : ControllerBase
    {
        private readonly Tag.TagClient _client;
        private readonly IMapper _mapper;

        public TagController(IMapper mapper, Tag.TagClient client)
        {
            _client = client;
            _mapper = mapper;
        }

        [HttpGet("{id:long}")]
        public async Task<GetTagResponse> GetTag(long id)
        {
            var response = await _client.GetTagAsync(new GetTagRequest { Id = id });
            var result = _mapper.Map<GetTagResponse>(response);
            return result;
        }

        //[HttpGet]
        //public async Task<GetTagsResponse>([FromBody] PaginationCommand pagination, [FromBody] TagFilterCommand filter)
        //{
        //    v
        //}

        [HttpPost]
        public async Task<AddTagResponse> AddTag([FromBody] AddTagCommand command)
        {
            var request = _mapper.Map<AddTagRequest>(command);
            var response = await _client.AddTagAsync(request);
            var result = _mapper.Map<AddTagResponse>(response);
            return result;
        }

        [HttpPut]
        public async Task<UpdateTagResponse> UpdateTag([FromBody] UpdateTagCommand command)
        {
            var request = _mapper.Map<UpdateTagRequest>(command);
            var response = await _client.UpdateTagAsync(request);
            var result = _mapper.Map<UpdateTagResponse>(response);
            return result;
        }

        [HttpDelete("{id:long}")]
        public async Task<DeleteTagResponse> DeleteTag(long id)
        {
            var response = await _client.DeleteTagAsync(new DeleteTagRequest { Id = id });
            var result = _mapper.Map<DeleteTagResponse>(response);
            return result;
        }
    }
}
