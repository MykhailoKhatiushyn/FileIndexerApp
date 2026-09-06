using System;

namespace FileIndexerApp
{
    class Program
    {
        static void Main(string[] args)
        {
            FileReader fileReader = new FileReader();
            TextProcessor processor = new TextProcessor();
            WordCounter counter = new WordCounter();

            Console.WriteLine("==================================================");
            Console.WriteLine("     FILE INDEXER - VERSION 2 (EXTENDED)          ");
            Console.WriteLine("==================================================\n");

            Console.Write("Enter directory path containing .txt files: ");
            string dirPath = Console.ReadLine();

            Console.Write("Enable Version 2 length truncation (Y/N)? ");
            bool useVersion2 = Console.ReadLine()?.Trim().ToUpper() == "Y";

            int? n = null, m = null;
            if (useVersion2)
            {
                Console.Write("Enter N (word length threshold): ");
                n = int.Parse(Console.ReadLine() ?? "5");

                Console.Write("Enter M (characters to remove from end): ");
                m = int.Parse(Console.ReadLine() ?? "2");
            }

            try
            {
                var files = fileReader.GetTextFiles(dirPath);
                foreach (var file in files)
                {
                    Console.WriteLine($"Processing file: {System.IO.Path.GetFileName(file)}");
                    string content = fileReader.ReadFileContent(file);
                    var words = processor.ProcessText(content, n, m);
                    counter.AddWords(words);
                }

                counter.DisplayTopResults(25);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nError: {ex.Message}");
            }

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}