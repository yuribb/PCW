using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCW.Contracts
{
    public record PostCardFullDto
    {
        public long Id { get; set; }
        public string Name { get; set; } = default!;
        public string ContentType { get; set; } = default!;
        public byte[] File { get; set; } = Array.Empty<byte>();
        public IReadOnlyCollection<TagDto> Tags { get; set; } = new List<TagDto>(5);
        public override string ToString()
        {
            return Name;
        }
    }
}
