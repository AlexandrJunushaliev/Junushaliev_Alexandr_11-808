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
            var value = new Random();//рандом для значения
            var sign = new Random();//рандом для знака
            string docPath =
                  Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Data");//путь до файлов данных
            for (var i = 1; i < 101; i++)//создает сто наборов файлов
            {
                using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, $"DataSet{i}.txt")))
                {
                    for (var j = 0; j < i * 100; j++)//от 100 до 10000 элементов в файле
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

