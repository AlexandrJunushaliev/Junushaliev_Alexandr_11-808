using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cond5
{
    class Program
    {
        static void Main(string[] args)
        {
            var data = Console.ReadLine();
            var data1 = data.Split(' ');
            var l = int.Parse(data1[0]);
            var k = int.Parse(data1[1]);
            var h = int.Parse(data1[2]);
            var min = (l / k) * h;
            var max = min + h;
            if (l % k == 0) max = min;
            Console.WriteLine(min+" "+max);
        }
    }
}
