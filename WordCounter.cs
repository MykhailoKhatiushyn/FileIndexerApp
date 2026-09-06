using System;
using System.Collections.Generic;
using System.Linq;

namespace FileIndexerApp
{
    public class WordCounter
    {
        private readonly Dictionary<string, int> _frequencies = new Dictionary<string, int>();

        public void AddWords(IEnumerable<string> words)
        {
            foreach (var word in words)
            {
                if (_frequencies.ContainsKey(word))
                    _frequencies[word]++;
                else
                    _frequencies[word] = 1;
            }
        }

        public Dictionary<string, int> GetFrequencies() => _frequencies;

        public void DisplayTopResults(int limit = 25)
        {
            Console.WriteLine($"\n--- Top {limit} Word Frequencies (Total Unique Words: {_frequencies.Count}) ---");
            Console.WriteLine($"{"Word",-25} | {"Frequency",-10}");
            Console.WriteLine(new string('-', 40));

            var sorted = _frequencies.OrderByDescending(kvp => kvp.Value).Take(limit);
            foreach (var entry in sorted)
            {
                Console.WriteLine($"{entry.Key,-25} | {entry.Value,-10}");
            }
        }
    }
}