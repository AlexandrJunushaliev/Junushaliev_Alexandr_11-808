using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expr5
{
    class Program
    {
        static void Main(string[] args)
        {

            var a = int.Parse(Console.ReadLine());
            var b = int.Parse(Console.ReadLine());
            int countA = a / 4 + a / 400 - a / 100;
            int countB = b / 4 + b / 400 - b / 100;
            if (((a % 4 == 0) && (a % 100 != 0)) || (a % 400 == 0)) countB++;
            Console.WriteLine(countB - countA);


        }
    }
}
