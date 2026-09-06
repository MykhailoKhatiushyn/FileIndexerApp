using System;
using System.Collections.Generic;
using System.IO;

namespace FileIndexerApp
{
    public class FileReader
    {
        public IEnumerable<string> GetTextFiles(string directoryPath)
        {
            if (!Directory.Exists(directoryPath))
            {
                throw new DirectoryNotFoundException($"Directory not found: {directoryPath}");
            }

            return Directory.GetFiles(directoryPath, "*.txt");
        }

        public string ReadFileContent(string filePath)
        {
            return File.ReadAllText(filePath);
        }
    }
}