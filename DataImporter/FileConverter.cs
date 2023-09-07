using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataImporter
{
    internal class FileConverter
    {
        public static List<List<string>> ConvertTSVFileToText(string filePath)
        {
            string[] lines = File.ReadAllLines(filePath);

            string[] headers = lines[0].Split('\t');
            List<List<string>> data = headers.Select(_ => new List<string>()).ToList();

            foreach (string line in lines.Skip(1))
            {
                var values = line.Split('\t');

                if (values.All(s => s == ""))
                {
                    continue;
                }

                for (int j = 0; j < values.Length; j++)
                {
                    string result = String.Join(" ", values[j].Split(' ', StringSplitOptions.RemoveEmptyEntries));
                    data[j].Add(result.ToLower().Trim());
                }
            }
            return data;
        }
    }
}
