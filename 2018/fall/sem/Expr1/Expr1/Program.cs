using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp10
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Еnter a three-digit number");
            //var a = Console.ReadLine();
            //string b = null;
            //for (var i = a.Length - 1; i >= 0; i--)
            //{ b = b + a[i]; }
            //Console.WriteLine(int.Parse(b));
            var a = int.Parse(Console.ReadLine());
            var x1 = a / 100;
            var x3 = a % 10;
            var x2 = a - x1 * 100 - x3;
            Console.WriteLine("Reverse number:");
            Console.WriteLine(x3*100+x2+x1);
        }
    }
}
