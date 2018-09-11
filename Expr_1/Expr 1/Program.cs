using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expr_1
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = int.Parse(Console.ReadLine());
            var b = int.Parse(Console.ReadLine());
            //var c = a;
            //a = b;
            //b = c;
            if (a>b)
            {
                a = a - b;
                b = b + a;
                a = b - a;
            }
            else
            {
                b = b - a;
                a = b + a;
                b = a - b;
            }
            Console.WriteLine(a);
            Console.WriteLine(b);
        }
    }
}
