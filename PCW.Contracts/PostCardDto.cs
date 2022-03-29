namespace PCW.Contracts
{
    public record PostCardDto
    {
        public long Id { get; set; }
        public string Name { get; set; } = default!;
        public override string ToString()
        {
            return Name;
        }
    }
}
