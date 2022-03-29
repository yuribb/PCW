namespace PCW.Api.Commands
{
    public class UpdateTagCommand
    {
        public long Id { get; set; }
        public string Name { get; set; } = default!;
    }
}
