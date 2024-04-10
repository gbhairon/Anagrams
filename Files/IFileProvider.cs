using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Files
{
    public interface  IFileProvider
    {
        public List<string> LoadFile(string filePath);
    }
}
