using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HeyRed.Mime;

namespace PCW.Storage.FileStorage
{
    public static class UniqueNameGenerator
    {

        public static string GetName(string contentType)
        {
            return $"{Path.GetRandomFileName()}.{MimeTypesMap.GetExtension(contentType)}";
        }
    }
}
