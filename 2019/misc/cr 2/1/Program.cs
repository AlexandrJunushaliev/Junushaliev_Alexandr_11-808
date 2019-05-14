using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;
using System.Reflection;

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
        static void Task2(string path, string[] names)
        {
            var answer = new StringBuilder();
            var res = new List<object>();
            var dis = new DirectoryInfo(path);
            foreach (var file in dis.GetFiles())
            {
                var text = "";
                using (StreamReader sr = file.OpenText())
                {
                    text = sr.ReadToEnd();
                }
                var parts = text.Split(';');
                //для название класса;название метода;тип аргумента1;строковое представление аргумента1;тип аргумента2;...
                var className = parts[0];
                var methodName = parts[1];
                var argsNumber = (parts.Length - 2) / 2;
                var args = new object[argsNumber];
                for (var i = 0; i < argsNumber; i++)
                {
                    var argStringType = parts[2 + i * 2];
                    var argType = Type.GetType(argStringType, false, true);
                    var argConstructor = argType.GetConstructor(new Type[] { typeof(string) });
                    string argConstructorArg = parts[2 + i * 2 + 1];
                    var argObj = argConstructor.Invoke(new object[] { argConstructorArg });
                    args[i] = argObj;
                }
                var classType = Type.GetType(className, false, true);
                var constructor = classType.GetConstructor(new Type[] { });
                dynamic obj = constructor.Invoke(new object[] { });
                var method = classType.GetMethod(methodName);
                dynamic result = classType.InvokeMember(method.Name, BindingFlags.InvokeMethod, null, obj, args);
                res.Add(result);
            }
            Task3(path, names, res);
        }
        static void Task3(string path, string[] names, List<object> res)
        {
            foreach (var name in names)
            {
                var newPath = path + "\\name";
                if (Directory.Exists(newPath))
                {
                    var i = 0;
                    var right = 0;
                    var dis = new DirectoryInfo(path);
                    foreach (var file in dis.GetFiles())
                    {
                        string text;
                        using (StreamReader sr = new StreamReader(file.DirectoryName))
                        {
                            text = sr.ReadToEnd();
                        }

                        if (text == res[i].ToString())
                        {
                            right++;
                        }
                        i++;
                    }
                    Console.WriteLine($"{name} - {right}");
                }
            }
        }
    }
}
