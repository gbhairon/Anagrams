using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqQueries
{
    public  class CountingWords
    {
        public Dictionary<char, int> GetWordCountAtoZ(List<string> wordsList)

        {
            if (wordsList == null || wordsList.Count == 0)
                throw new ArgumentException(nameof(wordsList));

            char[] az = Enumerable.Range('a', 'z' - 'a' + 1).Select(i => (char)i).ToArray();
            var charCounts = az.ToDictionary(
                letter => letter,
                letter => wordsList.Count(word => word.StartsWith(letter.ToString(), StringComparison.OrdinalIgnoreCase))
            );

            return charCounts;
        }
    }
}
