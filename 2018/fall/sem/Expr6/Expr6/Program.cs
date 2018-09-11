using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expr6
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter coordinats of 3 points in format x;y :");
            Console.WriteLine("Points of line:");
            Console.Write("A=");
            var a = Console.ReadLine();
            Console.Write("B=");
            var b = Console.ReadLine();
            var a1 = a.Split(';');
            var b1 = b.Split(';');
            Console.WriteLine("Third point");
            Console.Write("C=");
            var с = Console.ReadLine();
            var с1 = с.Split(';');

            var x1 = int.Parse(a1[0]);
            var x2 = int.Parse(b1[0]);
            var x3 = int.Parse(с1[0]);
            var y1 = int.Parse(a1[1]);
            var y2 = int.Parse(b1[1]);
            var y3 = int.Parse(с1[1]);

            var l1 = Math.Sqrt((x3 - x1) * (x3 - x1) + (y3 - y1) * (y3 - y1));
            var l2 = Math.Sqrt((x3 - x2) * (x3 - x2) + (y3 - y2) * (y3 - y2));
            var l3 = Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1));
            var p = 0.5 * (l1 + l2 + l3);
            Console.WriteLine("Distance from point to line:");
            if (l3 == l1 + l2)
                Console.WriteLine("0");
            else
                Console.WriteLine(2 * Math.Sqrt(p * (p - l1) * (p - l2) * (p - l3)) / l3);
        }
    }
}
