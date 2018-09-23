using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cord1
{
    class Program
    {
        static void Main(string[] args)
        {
            var move = Console.ReadLine().Split(';');
            var from = move[0];
            var to = move[1];
            var dx = Math.Abs(from[0] - to[0]);
            var dy = Math.Abs(from[1] - to[1]);

            if (dx == dy && dx!=0 || dx == 0 && dy != 0 || dy == 0 && dx != 0) Console.WriteLine("{0};{1} queen {2}", from, to, true);
            else Console.WriteLine("{0};{1} queen {2}", from, to, false); //Ферзь\Королева

            if (dx == dy && dx!=0 ) Console.WriteLine("{0};{1} bishop {2}", from, to, true);
            else Console.WriteLine("{0};{1} bishop {2}", from, to, false);//Слон

            if (dy==2 && dx==1 || dx==2 && dy==1) Console.WriteLine("{0};{1} knight {2}", from, to, true);
            else Console.WriteLine("{0};{1} knight {2}", from, to, false);//Конь

            if (dx == 0 && dy != 0 || dy == 0 && dx != 0) Console.WriteLine("{0};{1} rook {2}", from, to, true);
            else Console.WriteLine("{0};{1} rook {2}", from, to, false);//Ладья

            if (dx == dy && dx == 1 || dx == 0 && dy == 1 || dy == 0 && dx == 1) Console.WriteLine("{0};{1} king {2}", from, to, true);
            else Console.WriteLine("{0};{1} king {2}", from, to, false);//Король
        }
    }
}
