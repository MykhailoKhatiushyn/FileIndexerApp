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
            Console.WriteLine("     FILE INDEXER - VERSION 1 (BASE)             ");
            Console.WriteLine("==================================================\n");

            Console.Write("Enter directory path containing .txt files: ");
            string dirPath = Console.ReadLine();

            try
            {
                var files = fileReader.GetTextFiles(dirPath);
                foreach (var file in files)
                {
                    Console.WriteLine($"Processing file: {System.IO.Path.GetFileName(file)}");
                    string content = fileReader.ReadFileContent(file);
                    var words = processor.ProcessText(content);
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