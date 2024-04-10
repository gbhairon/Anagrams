using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnagramFinder
{
    public class Anagrams : IAnagrams
    {
        List<string> _wordList { get; set; }
        ConcurrentDictionary<string,string> _anagramsSorted ;
        public Anagrams(List<string> wordlist)
        {
            if (wordlist == null || wordlist.Count == 0)
            {
                throw new ArgumentException("The wordlist paramter is null or not defined.");
            }
            _wordList = wordlist;
            _anagramsSorted = new ConcurrentDictionary<string, string>();
        }

        public List<string> GetAnagramList()
        {
            Parallel.ForEach(_wordList, x => SetSortedValueForWord(x));

            var groupedValues = _anagramsSorted
            .GroupBy(pair => pair.Value)
            .Where(group => group.Count() > 1)
            .ToList();

            // now get the word with the max anagrams
            int maxCount = 0;
            List<string> wordWithMaxAnagrams = new List<string>();

            foreach (var group in groupedValues)
            {
                if (group.Count() > maxCount)
                {
                    maxCount = group.Count();
                    wordWithMaxAnagrams.Clear();
                    wordWithMaxAnagrams.AddRange(group.Select(pair => pair.Key));
                }
            }

            return wordWithMaxAnagrams.OrderBy(x=>x).ToList();
        }


        public string SetSortedValueForWord(string word)
        {
            if (!string.IsNullOrEmpty(word) && _wordList != null)
            {
                char[] wordArray = word.ToCharArray();
                Array.Sort(wordArray);
                string key = new string(wordArray);
                _anagramsSorted.TryAdd(word, key);
                return key;
            }
            else
                return "";
        }

    }
}
