using DataAccess.Management;
using System;
using System.Drawing;

namespace DataImporter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            args = new string[] { "C:\\Users\\User\\Downloads\\jobtitle.tsv" };

            if (args.Length == 0)
            {
                DatabaseConsoleManager.OutputCurrentDataStructure();
                return;
            }

            foreach (string arg in args)
            {
                var data = FileConverter.ConvertTSVFileToText(arg);

                using (ApplicationContext db = new ApplicationContext(connectionString))
                {
                    Seeder.SeedData(data, arg);
                }
            }
        }
    }
}
