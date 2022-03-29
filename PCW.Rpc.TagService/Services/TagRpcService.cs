using AutoMapper;
using Grpc.Core;
using PCW.Contracts;
using PCW.Interfaces;
using PCW.Rpc.TagService;

namespace PCW.Rpc.TagService.Services
{
    public class TagRpcService : Tag.TagBase
    {
        private readonly ILogger<TagRpcService> _logger;
        private readonly IMapper _mapper;
        private readonly ITagService _service;
        public TagRpcService(ILogger<TagRpcService> logger,
            IMapper mapper,
            ITagService service)
        {
            _logger = logger;
            _mapper = mapper;
            _service = service;
        }

        public override async Task<GetTagReply> GetTag(GetTagRequest request, ServerCallContext context)
        {
            var response = await _service.GetTag(request.Id);
            var result = _mapper.Map<GetTagReply>(response);
            return result;
        }

        public override async Task<AddTagReply> AddTag(AddTagRequest request, ServerCallContext context)
        {
            var response = await _service.AddTag(request.Name);
            var result = _mapper.Map<AddTagReply>(response);
            return result;
        }

        public override async Task<UpdateTagReply> UpdateTag(UpdateTagRequest request, ServerCallContext context)
        {
            var dto = _mapper.Map<TagDto>(request);
            var response = await _service.UpdateTag(dto);
            var result = _mapper.Map<UpdateTagReply>(response);
            return result;
        }

        public override async Task<DeleteTagReply> DeleteTag(DeleteTagRequest request, ServerCallContext context)
        {
            var response = await _service.DeleteTag(request.Id);
            var result = new DeleteTagReply {Id = request.Id, Deleted = response};
            return result;
        }
    }
}