using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCN
{
    class Program
    {
        static void Main(string[] args)
        {
            var x = long.Parse(Console.ReadLine());
            var y = long.Parse(Console.ReadLine());
            while (x!=0 && y!=0)
            { if (x >= y) x = x % y; else y = y % x; }
            Console.WriteLine(x+y);
        }
    }
}
