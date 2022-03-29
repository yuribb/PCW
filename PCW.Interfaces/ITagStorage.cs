using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PCW.Contracts;

namespace PCW.Interfaces
{
    public interface ITagStorage
    {
        public TagDto AddTag(string tag);
        public bool DeleteTag(TagDto tag);
    }
}
