using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;

namespace ConsoleApp42
{
    class Program
    {

        static void Main(string[] args)
        {
            
        }
        static async Task<List<string>> Task1(string path)
        {
            var fileInfos = new List<string>();
            await Task.Run(() =>
            {
                
                var info = new DirectoryInfo(path);
                var dirs = info.GetDirectories();

                foreach (var dir in dirs)
                {
                    var files = dir.GetFiles();
                    foreach (var file in files)
                    {
                        fileInfos.Add(file.Name);
                    }
                }
            });
            return fileInfos;
        }
        static async void Task2(string path)
        {
            var answer = new StringBuilder();
            var dis = new DirectoryInfo(path);
            foreach (var file in dis.GetFiles())
            {
                var text = "";
                using (StreamReader sr = file.OpenText())
                {
                    text = sr.ReadToEnd();
                }
                var parts = text.Split(';');
                var className = parts[0];
                var methodName = parts[1];
                var argsNumber = (parts.Length - 2) / 2;
                var args = new object[argsNumber];
                for (var i=0;i<argsNumber;i++)
                {
                    var argStringType = parts[2 + i * 2];
                    var argType = Type.GetType(argStringType, false, true);
                    var argumentConstructor = argStringType
                }
            }

        }
    }
}
