using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cord6
{
    class Program
    {
        static void Main(string[] args)
        {      
            var a = Console.ReadLine();
            var b = Console.ReadLine();
            var c = Console.ReadLine();
            var data1 = a.Split(';');
            var data2 = b.Split(';');
            var data3 = c.Split(';');
            var x0 = double.Parse(data1[0]);
            var y0 = double.Parse(data1[1]);
            var x1 = double.Parse(data2[0]);
            var y1 = double.Parse(data2[1]);
            var x2 = double.Parse(data3[0]);
            var y2 = double.Parse(data3[1]);
            var l1 = Math.Sqrt((x1 - x0) * (x1 - x0) + (y1 - y0) * (y1 - y0));
            var l2 = Math.Sqrt((x1 - x2) * (x1 - x2) + (y1 - y2) * (y1 - y2));
            var d = Math.Sqrt((x2 - x0) * (x2 - x0) + (y2 - y0) * (y2 - y0));
            if (d*d-2*l1*l1<0.000001 && l1== l2)
            {
                Console.WriteLine("Entered points is the verticles of a square");
                var x3 = (x2 + x0) / 2;
                var y3 = (y2 + y0) / 2;
                Console.WriteLine("Coordinates of the 4th verticle of a square:");
                Console.WriteLine("X=" + (2 * x3 - x1) + " Y=" + (2 * y3 - y1));
            }
            else Console.WriteLine("Entered points isn't the verticles of a square");                        
        }
    }
}
