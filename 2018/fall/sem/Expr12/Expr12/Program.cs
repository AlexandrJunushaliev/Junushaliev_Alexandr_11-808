using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expr12
{
    class Program
    {
        static void Main(string[] args)
        {
            var data = Console.ReadLine();
            var data1 = data.Split(' ');            
            var h = double.Parse(data1[0]); //height
            var t = double.Parse(data1[1]); //time
            var v = double.Parse(data1[2]); //limit speed
            var x = double.Parse(data1[3]); //speed of ears
            var neededSpeed = h / t;
            double maxTime;
            double minTime;
            if (neededSpeed < x)
            {
                maxTime = h / x; //all time on speed x+EPS 
                minTime = 0;
            }
            else
            {
                maxTime = t;
                minTime = (h / x - t) / (v / x - 1);
            }
            Console.WriteLine("{0:0.000000}", minTime);
            Console.WriteLine("{0:0.000000}", maxTime);
        }
    }
}
