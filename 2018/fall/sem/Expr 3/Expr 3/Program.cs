using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expr_3
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = Console.ReadLine();
            var b = a.Split(':');
            var minutes = int.Parse(b[1]);
            var hours = int.Parse(b[0]);
            if (hours > 12) hours = hours - 12;
            var angleOfHourArrow = hours * 30 + minutes * 0.5;
            var angleOfMinuteArrow = minutes * 6;
            var angleBetween = Math.Abs(angleOfHourArrow - angleOfMinuteArrow);
            if (angleBetween > 180) angleBetween = 360 - angleBetween;
            Console.WriteLine(angleBetween);
        }
    }
}
