using DataAccess.Management;
using DataImporter.Seeders;
using System;
using System.Drawing;

namespace DataImporter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var connectionString = ConnectionDB.ConnectionString();

            if (args.Length == 0)
            {
                
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
