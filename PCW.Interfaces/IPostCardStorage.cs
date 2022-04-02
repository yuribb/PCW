using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PCW.Contracts;

namespace PCW.Interfaces
{
    public interface IPostCardStorage
    {
        public Task<string> AddPostCard(string contentType, byte[] content);
        public Task<bool> DeletePostCard(string uniqueName);
    }
}
