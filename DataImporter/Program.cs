using DataAccess.Management;
using DataImporter.Seeders;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Drawing;
using System.IO;

namespace DataImporter
{
    public class Program
    {
        static void Main(string[] args)
        {
            //args = new string[] { "C:\\Users\\User\\Downloads\\jobtitle.tsv" };

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
