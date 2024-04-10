using Files;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnagramFinder
{
    public class AnagramBuilder : IAnagramBuilder
    {
        public List<string> BuildLargestAnagramSet(string filePath, IFileProvider fileProvider )
        {
            if (string.IsNullOrEmpty(filePath) || fileProvider == null)
                throw new ArgumentNullException();
            var wordsList = GetWordsList( filePath,  fileProvider);
            IAnagrams anagrams = new Anagrams(wordsList);
            return anagrams.GetAnagramList();
        }

        public List<string> GetWordsList(string filePath, IFileProvider fileProvider)
        {
            if (string.IsNullOrEmpty(filePath) || fileProvider == null)
                throw new ArgumentNullException();

            return fileProvider.LoadFile(filePath);            
        }

    }
}
