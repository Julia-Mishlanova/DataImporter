using DataAccess.Management;
using System;
using System.Drawing;

namespace DataImporter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var connectionString = ConnectionDB.ConnectionString();

            foreach (string arg in args)
            {
                var data = FileConverter.ConvertTSVFileToText(arg);
            }
        }
    }
}
