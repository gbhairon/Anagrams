using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqQueries
{
    public class DistinctWords
    {
        // NB if there is a tie with a number of words having the same char count being the max count the first is returned
        // I would ideally like to understand what would be required in this scenario
        public string GetLongestDistinctWord(List<string> wordsList)
        {
            if (wordsList == null || wordsList.Count == 0)
                throw new ArgumentException(nameof(wordsList));
            var largestDistinctCharsWord = wordsList?.OrderByDescending(word => word.Distinct().Count())
                        .FirstOrDefault();
            return largestDistinctCharsWord;

        }
    }
}
