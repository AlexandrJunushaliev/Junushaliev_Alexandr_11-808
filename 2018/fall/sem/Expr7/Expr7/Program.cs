using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expr7
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter k and b:");
            Console.Write("k=");
            var k = int.Parse(Console.ReadLine());
            Console.Write("b=");
            var b = int.Parse(Console.ReadLine());
            var y1 = k * 1 + b+1;
            var y2 = k * 2 + b+1;
            var vector = new int[2];
            vector[0] = 1;
            vector[1] = y2 - y1;
            Console.WriteLine("vector = ("+vector[0].ToString() + ';' + vector[1].ToString()+')');           
        }
    }
}
