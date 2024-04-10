using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Files
{
    public class FileProvider : IFileProvider
    {        

        public List<string> LoadFile(string filePath)
        {
            if (string.IsNullOrEmpty(filePath) || !File.Exists(filePath))
            {
                throw new FileNotFoundException (string.Format("The input file is not defined correctly {0}", filePath ?? ""));
            }

            return File.ReadAllLines(filePath).ToList<string>();
        }



    }
}
