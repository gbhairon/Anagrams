using System.Linq;
using Files;
using AnagramFinder;
using LinqQueries;

// Displaying the largest Anagrams for a word in the file 

// would set this in the config to read, change this to point to your file
var filePath = "C:\\Gurjits\\Gurjits\\VS\\Citi Bank\\Anagrams\\Files\\words.txt";
IFileProvider fileProvider = new FileProvider();
IAnagramBuilder anagramBuilder = new AnagramBuilder();
var maxAnamgramsList = anagramBuilder.BuildLargestAnagramSet(filePath, fileProvider);
Console.WriteLine("largest set of Anagrams:");
foreach (var word in maxAnamgramsList) 
    Console.WriteLine(word);


// word count
var wordsList = anagramBuilder.GetWordsList(filePath, fileProvider);
CountingWords countWords = new CountingWords();
var charCounts = countWords.GetWordCountAtoZ(wordsList);
Console.WriteLine("Word counts by starting letter:");
foreach (var kvp in charCounts)
{
    Console.WriteLine($"{kvp.Key}: {kvp.Value}");
}

// largest distinct word
DistinctWords distinctWords = new DistinctWords();
var largestDistinctCharsWord = distinctWords.GetLongestDistinctWord(wordsList);
Console.WriteLine("The first word with the largest distinct set of characters in the word:");
Console.WriteLine(largestDistinctCharsWord);
Console.ReadLine();