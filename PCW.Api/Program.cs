using PCW.Api.Hosting;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddApiMappingProfiles();
builder.Services.AddRpcClient<PCW.Rpc.PostCardService.PostCard.PostCardClient>(
    builder.Configuration["RpcServers:PostCardServer"]);
builder.Services.AddRpcClient<PCW.Rpc.TagService.Tag.TagClient>(
    builder.Configuration["RpcServers:TagServer"]);

var app = builder.Build();

if (builder.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseSwagger();
app.MapGet("/", () => "PCW API");
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();