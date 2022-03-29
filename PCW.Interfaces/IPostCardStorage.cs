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
        public string AddPostCard(string contentType, byte[] content);
        public bool DeletePostCard(string uniqueName);
    }
}
