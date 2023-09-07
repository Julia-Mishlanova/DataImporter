using DataAccess.Management;
using DataImporter.Seeders;
using System;
using System.Drawing;

namespace DataImporter
{
    public class Program
    {
        static void Main(string[] args)
        {
            //args = new string[] { "C:\\Users\\User\\Downloads\\jobtitle.tsv" };
            using (ApplicationDbContext db = new ApplicationDbContext(ConnectionDB.ConnectionString())) { }

            if (args.Length == 0)
            {
                DatabaseConsoleManager.OutputCurrentDataStructure();
                return;
            }

            foreach (string arg in args)
            {
                var data = FileConverter.ConvertTSVFileToText(arg);

                Seeder.SeedData(data, arg);
            }
        }
    }
}
