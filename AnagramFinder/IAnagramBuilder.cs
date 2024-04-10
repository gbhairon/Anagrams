using Files;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnagramFinder
{
    public interface IAnagramBuilder
    {
        public List<string> BuildLargestAnagramSet(string filePath, IFileProvider fileProvider);
        public List<string> GetWordsList(string filePath, IFileProvider fileProvider);

    }
}
