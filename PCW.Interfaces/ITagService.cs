using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PCW.Contracts;

namespace PCW.Interfaces
{
    public interface ITagService
    {
        Task<TagDto> GetTag(long id);
        Task<TagDto> AddTag(string name);
        Task<TagDto> UpdateTag(TagDto tag);
        Task<bool> DeleteTag(long id);
    }
}
