using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pecents
{
    class Program
    {
        static void Main(string[] args)
        {
            var enterData = Console.ReadLine();
            var enterData1 = enterData.Split('.');
            var sum = double.Parse(enterData1[0]);
            var rate = double.Parse(enterData1[1]);
            var time = double.Parse(enterData1[2]);
            var answer = sum * Math.Pow((1 + rate / (12 * 100.00)), time);
        }
    }
}
