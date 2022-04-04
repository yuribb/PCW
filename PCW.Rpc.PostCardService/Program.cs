using PCW.Contracts.Configuration;
using PCW.Rpc.PostCardService.Hosting;
using PCW.Rpc.PostCardService.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDependencies(builder.GetSettings<StorageSettings>());
var app = builder.Build();
app.MapGrpcService<PostCardRpcService>();
app.MapGet("/", () => $"{nameof(PostCardRpcService)} rpc");
app.Run();