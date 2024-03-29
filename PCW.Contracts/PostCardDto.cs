﻿namespace PCW.Contracts
{
    public record PostCardDto
    {
        public long Id { get; set; }
        public string Name { get; set; } = default!;
        public string ContentType { get; set; } = default!;
        public byte[] File { get; set; } = Array.Empty<byte>();
        public IReadOnlyCollection<long> TagIds { get; set; } = new List<long>(5);
        public override string ToString()
        {
            return Name;
        }
    }
}
