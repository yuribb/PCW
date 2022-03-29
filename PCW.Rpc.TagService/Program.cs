using PCW.Rpc.TagService.Services;
using PCW.Rpc.TagService.Hosting;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDependencies();
var app = builder.Build();
app.MapGrpcService<TagRpcService>();
app.MapGet("/", () => $"{nameof(TagRpcService)} rpc");
app.Run();
