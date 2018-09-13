using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expr10
{
    class Program
    {
        static void Main(string[] args)
        {
            var k = 0;
            for (var i = 1; i < 1000; i++) if (i % 5 == 0 || i % 3 == 0) k=k+i;
            Console.WriteLine(k);
        }
    }
}
