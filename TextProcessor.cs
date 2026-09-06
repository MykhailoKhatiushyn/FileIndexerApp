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

        public List<string> ProcessText(string text)
        {
            string[] rawWords = text.Split(Delimiters, StringSplitOptions.RemoveEmptyEntries);
            List<string> processedWords = new List<string>();

            foreach (var rawWord in rawWords)
            {
                string word = rawWord.ToLower().Trim();

                if (!string.IsNullOrWhiteSpace(word))
                {
                    processedWords.Add(word);
                }
            }

            return processedWords;
        }
    }
}