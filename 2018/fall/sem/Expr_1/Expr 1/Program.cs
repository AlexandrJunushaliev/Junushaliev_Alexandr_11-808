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
            Console.Write("a=");
            var a = int.Parse(Console.ReadLine());
            Console.Write("b=");
            var b = int.Parse(Console.ReadLine());
            //Console.Write("a=");
            //var a = int.Parse(Console.ReadLine());
            //Console.Write("b=");
            //var b = int.Parse(Console.ReadLine());
            //var c = a;
            //a = b;
            //b = c;
            //Console.WriteLine("a=" + a);
            //Console.WriteLine("b=" + b);
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
            Console.WriteLine("a="+a);
            Console.WriteLine("b="+b);
        }
    }
}
