using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expr4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("N=");
            var n = int.Parse(Console.ReadLine());
            Console.Write("X=");
            var x = int.Parse(Console.ReadLine());
            Console.Write("Y=");
            var y = int.Parse(Console.ReadLine());
            n--;
            Console.WriteLine("Number of numbers less than N, which have simple divisors X or Y:");
            Console.WriteLine(n / x + n / y - n / (x * y));
        }
    }
}
