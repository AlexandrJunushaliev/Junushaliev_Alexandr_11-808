using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expr8
{
    class Program
    {
        static double[] SearchOfLengthes(int x1, int x2, int x3, int y1, int y2, int y3)
        {
            var l1 = Math.Sqrt((x3 - x1) * (x3 - x1) + (y3 - y1) * (y3 - y1));
            var l2 = Math.Sqrt((x3 - x2) * (x3 - x2) + (y3 - y2) * (y3 - y2));
            var l3 = Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1));
            var lengthes = new double[3];
            lengthes[0] = l1;
            lengthes[1] = l2;
            lengthes[2] = l3;
            return lengthes; 
        }

        static double SearchOfDistance(double[] l)
        {
            var p = 0.5 * (l[1] + l[2] + l[0]);
            if (l[2] == l[1] + l[0])
                return 0;
            else
                return 2 * Math.Sqrt(p * (p - l[1]) * (p - l[2]) * (p - l[0])) / l[2];
        }
        
        static void Main(string[] args)
        {
            Console.WriteLine("Enter coordinats of 3 points in format x;y :");
            Console.WriteLine("Points of line:");
            Console.Write("C=");
            var c = Console.ReadLine();
            Console.Write("B=");
            var b = Console.ReadLine();
            var c1 = c.Split(';');
            var b1 = b.Split(';');
            Console.WriteLine("Third point");
            Console.Write("A=");
            var a = Console.ReadLine();
            var a1 = a.Split(';');
            var x1 = int.Parse(c1[0]);
            var x2 = int.Parse(b1[0]);
            var x3 = int.Parse(a1[0]);
            var y1 = int.Parse(c1[1]);
            var y2 = int.Parse(b1[1]);
            var y3 = int.Parse(a1[1]);
            var length = new double[3];
            length = SearchOfLengthes(x1, x2, x3, y1, y2, y3);
            var h = SearchOfDistance(length);
            var area = 0.5 * length[2] * h;
            var sinAlpha3 = 2 * area / (length[0] * length[1]);
            var sinAlpha2 = length[1] * sinAlpha3 / length[2];
            var sinAlpha1 = length[0] * sinAlpha3 / length[2];
            if (Math.Asin(sinAlpha1)>Math.PI/2 || Math.Asin(sinAlpha2)> Math.PI/2|| Math.Asin(sinAlpha3)> Math.PI/2)
            {
                var l = Math.Sqrt(Math.Min(length[1], length[0]) * Math.Min(length[1], length[0]) - h * h);
                var lambda = l / length[2];
                var needX = x2 * (1 + lambda) - (lambda * x1);
                var needY = y2 * (1 + lambda) - (lambda * y1);
                if (Math.Round(needX) - needX < double.Epsilon) needX = Math.Round(needX);
                if (Math.Round(needY) - needY < double.Epsilon) needY = Math.Round(needY);
                Console.WriteLine("x=" + needX + "y=" + needY);
            }
            else
            {
                var l = Math.Sqrt(length[1] * length[1] - h * h);
                var lambda = l / (length[2] - l);
                
                var needX = (x2 + lambda * x1) / (lambda + 1);
                var needY = (y2 + lambda * y1) / (lambda + 1);
                if (Math.Round(needX) - needX < double.Epsilon) needX = Math.Round(needX);
                if (Math.Round(needY) - needY < double.Epsilon) needY = Math.Round(needY);
                Console.WriteLine("x=" + needX + " y=" + needY);
            }
        }
    }
}
