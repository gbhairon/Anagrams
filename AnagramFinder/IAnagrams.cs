using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnagramFinder
{
    public interface  IAnagrams
    {
        public List<string> GetAnagramList();
        public string SetSortedValueForWord(string word);
    }
}
