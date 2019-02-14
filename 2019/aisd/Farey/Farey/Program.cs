using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Farey
{
    class Program
    {
        public static List<int> list = new List<int>();
        public static void FareiRecc(int n)
        {
            list.Add(1);
            FareiRecc(n, 0, 1, 1, 1);
            list.Add(1);
        }

        private static void FareiRecc(int n, int x, int y, int z, int t)
        {
            int a = x + z, b = y + t;
            if (b <= n)
            {
                FareiRecc(n, x, y, a, b);
                list.Add(1);
                FareiRecc(n, a, b, z, t);
            }
        }
        static public void FareyList(int n)
        {
            var linkedList = new MyLinkedList<Fraction>();
            linkedList.AddFirst(new Fraction(0, 1));
            linkedList.AddFirst(new Fraction(1, 1));
            var currentFraction = linkedList.Last;
            while (currentFraction.Next != null)
            {
                var a = currentFraction.Value.Numerator + currentFraction.Next.Value.Numerator;
                var b = currentFraction.Value.Denominator + currentFraction.Next.Value.Denominator;
                if (b <= n)
                {
                    var temp = currentFraction.Next;
                    currentFraction.Next = new MyLinkedListNode<Fraction>(new Fraction(a, b));
                    currentFraction.Next.Next = temp;
                    currentFraction.Next.Previous = currentFraction;
                    temp.Previous = currentFraction.Next;
                }
                else currentFraction = currentFraction.Next;
            }
        }
        static void Main(string[] args)
        {
            var list = new Series();
            var recc = new Series();
            for (var i = 3; i < 1000; i++)
            {
                MeasureTime(i, FareyList, list);
                MeasureTime(i, FareiRecc, recc);
            }
            var chart = new Chart();
            chart.ChartAreas.Add(new ChartArea());

            list.ChartType = SeriesChartType.FastLine;
            list.Color = Color.Red;
            list.MarkerBorderWidth = 3;

            recc.ChartType = SeriesChartType.FastLine;
            recc.Color = Color.Blue;
            recc.BorderWidth = 3;

            chart.Series.Add(list);
            chart.Series.Add(recc);
            chart.Dock = System.Windows.Forms.DockStyle.Fill;
            var form = new Form();
            form.Controls.Add(chart);
            Application.Run(form);
        }

        static void MeasureTime(int n, Action<int> Farey, Series ser)
        {
            var watch = new Stopwatch();
            watch.Start();
                Farey(n);
            watch.Stop();
            ser.Points.Add(new DataPoint(n, watch.ElapsedTicks));
            GC.Collect();
        }
    }
}
