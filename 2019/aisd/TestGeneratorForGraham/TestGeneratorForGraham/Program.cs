using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TestGeneratorForGraham
{
    class Program
    {
        static void Main(string[] args)
        {
            var dataSetstsNumber = new Random();
            var amountOfData = new Random();
            var value = new Random();
            var sign = new Random();
            string docPath =
                  Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Data");
            for (var i = 1; i < 101; i++)
            {
                using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, $"DataSet{i}.txt")))
                {
                    for (var j = 0; j < i * 100; j++)
                    {
                        var currentSignForX = Math.Pow(-1, sign.Next(0, 2));
                        var X = value.Next(0, 256);
                        var currentSignForY = Math.Pow(-1, sign.Next(0, 2));
                        var Y = value.Next(0, 256);
                        var line = $"({ X * currentSignForX},{Y * currentSignForY})";
                        outputFile.WriteLine(line);
                    }
                }
            }

        }
    }
}

