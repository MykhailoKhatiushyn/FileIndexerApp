using System;
using System.Collections.Generic;

namespace FileIndexerApp
{
    public class TextProcessor
    {
        private static readonly char[] Delimiters = new[]
        {
            ' ', '\r', '\n', '\t', '.', ',', ';', ':', '!', '?', '"', '\'', '(', ')', '[', ']', '{', '}', '-', '_', '/'
        };

               public List<string> ProcessText(string text, int? n = null, int? m = null)
        {
            string[] rawWords = text.Split(Delimiters, StringSplitOptions.RemoveEmptyEntries);
            List<string> processedWords = new List<string>();

            foreach (var rawWord in rawWords)
            {
                string word = rawWord.ToLower().Trim();

                if (string.IsNullOrWhiteSpace(word))
                    continue;

                                if (n.HasValue && m.HasValue && word.Length > n.Value)
                {
                    int targetLength = word.Length - m.Value;
                    if (targetLength > 0)
                    {
                        word = word.Substring(0, targetLength);
                    }
                }

                processedWords.Add(word);
            }

            return processedWords;
        }
    }
}