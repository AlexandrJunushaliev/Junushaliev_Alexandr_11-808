using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Graham
{
    class Point : IComparable
    {
        public readonly double X;
        public readonly double Y;

        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }
        public Point(string point)
        {
            var a = point.Split(',');
            X = int.Parse(a[0].Split('(')[1]);
            Y = int.Parse(a[1].Split(')')[0]);
        }
        public double LengthToPoint(Point point)
        {
            return Math.Pow((X - point.X) * (X - point.X) + (Y - point.Y) * (Y - point.Y), 0.5);
        }

        public int CompareTo(object obj)
        {
            Point point = (Point)obj;
            if (Y < point.Y || Y == point.Y && X < point.X) return -1;
            if (Y == point.Y && X == point.X) return 0;
            return 1;
        }
    }
    class QuickSorter
    {
        int partition(Point[] m, int a, int b, Point mainPoint)
        {
            int i = a;
            for (int j = a; j <= b; j++)
            {
                if (Math.Atan2((m[j].Y - mainPoint.Y), (m[j].X - mainPoint.X)) < Math.Atan2((m[b].Y - mainPoint.Y), (m[b].X - mainPoint.X)) ||
                    (Math.Atan2((m[j].Y - mainPoint.Y), (m[j].X - mainPoint.X)) == Math.Atan2((m[b].Y - mainPoint.Y), (m[b].X - mainPoint.X)) &&
                    mainPoint.LengthToPoint(m[j]) <= mainPoint.LengthToPoint(m[b])))
                {
                    Point t = m[i];
                    m[i] = m[j];
                    m[j] = t;
                    i++;
                }
            }
            return i - 1;
        }

        public void Quicksort(Point[] m, int a, int b, Point mainPoint)
        {
            if (a >= b) return;
            int c = partition(m, a, b, mainPoint);
            Quicksort(m, a, c - 1, mainPoint);
            Quicksort(m, c + 1, b, mainPoint);
        }
    }
    class Program
    {
        static MyStack<Point> GrahamArray(Point[] sortedPoints)
        {
            var stack = new MyStack<Point>();
            stack.Push(sortedPoints[0]);
            stack.Push(sortedPoints[1]);
            for (var i = 2; i < sortedPoints.Length; i++)
            {
                while (stack.NextToTop() != null && IsNonLeftTurn(stack.NextToTop(), stack.Peek(), sortedPoints[i]))
                {
                    stack.Pop();
                }

                stack.Push(sortedPoints[i]);
            }
            return stack;
        }

        static MyStack<Point> GrahamLinkedList(MyLinkedList<Point> sortedPoints)
        {
            var stack = new MyStack<Point>();
            var k = 0;
            foreach (var point in sortedPoints)
            {
                if (k < 2)
                {
                    stack.Push(point.Value);
                    k++;
                }
                else
                {
                    while (stack.NextToTop() != null && IsNonLeftTurn(stack.NextToTop(), stack.Peek(), point.Value))
                    {
                        stack.Pop();
                    }
                    stack.Push(point.Value);
                }
            }
            return stack;
        }

        static bool IsNonLeftTurn(Point a, Point b, Point c)
        {
            return !((b.X - a.X) * (c.Y - b.Y) - (b.Y - a.Y) * (c.X - b.X) >= 0);
        }

        static void Main(string[] args)
        {
            var array = new Series();
            var linkedList = new Series();
            var arrayWithSort = new Series();
            var linkedListWithSort = new Series();    
            var watch1 = new Stopwatch();
            var watch2 = new Stopwatch();
            for (var i = 1; i < 101; i++)
            {
                var arr = GetListData(i);
                watch1.Start();
                Array.Sort(arr);
                var Q = new QuickSorter();
                Q.Quicksort(arr, 1, arr.Length - 1, arr[0]);
                MeasureTimeForArr(arr, GrahamArray, array);
                watch1.Stop();
                arrayWithSort.Points.Add(new DataPoint(i * 100, watch1.ElapsedTicks));

                var linkList = GetLinkedListData(i);
                watch2.Start();
                var sort = LinkedListSort(linkList);
                MeasureTimeForLinkedList(i, linkList, GrahamLinkedList, linkedList);
                watch2.Stop();
                linkedListWithSort.Points.Add(new DataPoint(i * 100, watch2.ElapsedTicks));
            }

            var chart = new Chart();
            chart.ChartAreas.Add(new ChartArea());

            array.ChartType = SeriesChartType.FastLine;
            array.Color = Color.Red;
            array.MarkerBorderWidth = 3;

            
            linkedList.ChartType = SeriesChartType.FastLine;
            linkedList.Color = Color.Blue;
            linkedList.BorderWidth = 3;

            linkedListWithSort.ChartType = SeriesChartType.FastLine;
            linkedListWithSort.Color = Color.Green;
            linkedListWithSort.BorderWidth = 3;

            arrayWithSort.ChartType = SeriesChartType.FastLine;
            arrayWithSort.Color = Color.Orange;
            arrayWithSort.MarkerBorderWidth = 3;



            chart.Series.Add(array);
            chart.Series.Add(linkedList);
            //chart.Series.Add(linkedListWithSort);
            //chart.Series.Add(arrayWithSort);
            chart.Dock = System.Windows.Forms.DockStyle.Fill;
            var form = new Form();
            form.Controls.Add(chart);
            Application.Run(form);
        }

        static void MeasureTimeForArr(Point[] points, Func<Point[], MyStack<Point>> Graham, Series ser)
        {
            var watch = new Stopwatch();
            watch.Start();
            Graham(points);
            watch.Stop();
            ser.Points.Add(new DataPoint(points.Length, watch.ElapsedTicks));
            GC.Collect();
        }
        static void MeasureTimeForLinkedList(int i, MyLinkedList<Point> points, Func<MyLinkedList<Point>, MyStack<Point>> Graham, Series ser)
        {
            var watch = new Stopwatch();
            watch.Start();
            Graham(points);
            watch.Stop();
            ser.Points.Add(new DataPoint(i * 100, watch.ElapsedTicks));
            GC.Collect();
        }
        #region
        static Point[] GetListData(int i)
        {
            var points = new List<Point>();
            string docPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Data");
            StreamReader file = new StreamReader(Path.Combine(docPath, $"DataSet{i}.txt"));
            string line;
            while ((line = file.ReadLine()) != null)
            {
                points.Add(new Point(line));
            }
            return points.ToArray();
        }

        static MyLinkedList<Point> GetLinkedListData(int i)
        {
            var points = new MyLinkedList<Point>();
            string docPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Data");
            StreamReader file = new StreamReader(Path.Combine(docPath, $"DataSet{i}.txt"));
            string line;
            while ((line = file.ReadLine()) != null)
            {
                points.AddLast(new Point(line));
            }
            return points;
        }
        #endregion
        
        static MyLinkedList<Point> LinkedListSort(MyLinkedList<Point> points)
        {
            var min = new Point(256, 256);
            foreach (var pointNode in points)
            {
                if (pointNode.Value.Y < min.Y)
                {
                    min = pointNode.Value;
                }
                else if (pointNode.Value.Y == min.Y && pointNode.Value.X > min.X)
                {
                    min = pointNode.Value;
                }
            }
            points.Remove(min);
            var result = new MyLinkedList<Point>();
            result.AddFirst(points.First().Value);
            points.RemoveFirst();
            foreach (var pointNode in points)
            {
                foreach (var curPointNode in result)
                {
                    if (Math.Atan2((curPointNode.Value.Y - min.Y), (curPointNode.Value.X - min.X)) >
                       Math.Atan2((pointNode.Value.Y - min.Y), (pointNode.Value.X - min.X)) && curPointNode.Previous == null)
                    {

                        result.AddFirst(pointNode.Value);
                        break;
                    }
                    else
                    if (Math.Atan2((curPointNode.Value.Y - min.Y), (curPointNode.Value.X - min.X)) ==
                       Math.Atan2((pointNode.Value.Y - min.Y), (pointNode.Value.X - min.X)) && curPointNode.Previous == null)
                    {
                        if (min.LengthToPoint(curPointNode.Value) > min.LengthToPoint(pointNode.Value))
                        {
                            result.AddFirst(pointNode.Value);
                            break;
                        }
                        else
                        {
                            var t = curPointNode.Next;
                            curPointNode.Next = new MyLinkedListNode<Point>(pointNode.Value);
                            curPointNode.Next.Previous = curPointNode;
                            curPointNode.Next.Next = t;
                            t.Previous = curPointNode.Next;
                            break;
                        }
                    }
                    else
                    if (Math.Atan2((curPointNode.Value.Y - min.Y), (curPointNode.Value.X - min.X)) <
                        Math.Atan2((pointNode.Value.Y - min.Y), (pointNode.Value.X - min.X)) && curPointNode.Next == null)
                    {
                        result.AddLast(pointNode.Value);
                        break;
                    }
                    if (Math.Atan2((curPointNode.Value.Y - min.Y), (curPointNode.Value.X - min.X)) ==
                        Math.Atan2((pointNode.Value.Y - min.Y), (pointNode.Value.X - min.X)) && curPointNode.Next == null)
                    {

                        if (min.LengthToPoint(curPointNode.Value) > min.LengthToPoint(pointNode.Value))
                        {
                            var t = curPointNode.Previous;
                            curPointNode.Previous = new MyLinkedListNode<Point>(pointNode.Value);
                            curPointNode.Previous.Next = curPointNode;
                            curPointNode.Previous.Previous = t;
                            t.Next = curPointNode.Previous;
                            break;

                        }
                        else
                        {
                            result.AddLast(pointNode.Value);
                            break;
                        }

                    }
                    else
                    if (Math.Atan2((curPointNode.Value.Y - min.Y), (curPointNode.Value.X - min.X)) <
                        Math.Atan2((pointNode.Value.Y - min.Y), (pointNode.Value.X - min.X)) && curPointNode.Next != null
                        && Math.Atan2((curPointNode.Next.Value.Y - min.Y), (curPointNode.Next.Value.X - min.X)) >
                        Math.Atan2((pointNode.Value.Y - min.Y), (pointNode.Value.X - min.X)))
                    {
                        var t = curPointNode.Next;
                        curPointNode.Next = new MyLinkedListNode<Point>(pointNode.Value);
                        curPointNode.Next.Previous = curPointNode;
                        curPointNode.Next.Next = t;
                        t.Previous = curPointNode.Next;
                        break;
                    }
                    if (Math.Atan2((curPointNode.Value.Y - min.Y), (curPointNode.Value.X - min.X)) ==
                        Math.Atan2((pointNode.Value.Y - min.Y), (pointNode.Value.X - min.X)) && curPointNode.Next != null
                        && Math.Atan2((curPointNode.Next.Value.Y - min.Y), (curPointNode.Next.Value.X - min.X)) >
                        Math.Atan2((pointNode.Value.Y - min.Y), (pointNode.Value.X - min.X)))
                    {
                        if (min.LengthToPoint(curPointNode.Value) > min.LengthToPoint(pointNode.Value))
                        {
                            var t = curPointNode.Previous;
                            curPointNode.Previous = new MyLinkedListNode<Point>(pointNode.Value);
                            curPointNode.Previous.Next = curPointNode;
                            curPointNode.Previous.Previous = t;
                            t.Next = curPointNode.Previous;
                            break;
                        }
                        else
                        {
                            var t = curPointNode.Next;
                            t.Previous = new MyLinkedListNode<Point>(pointNode.Value);
                            t.Previous.Next = t;
                            t.Previous.Previous = curPointNode;
                            curPointNode.Next = t.Previous;
                            break;
                        }

                    }
                    if (Math.Atan2((curPointNode.Value.Y - min.Y), (curPointNode.Value.X - min.X)) ==
                        Math.Atan2((pointNode.Value.Y - min.Y), (pointNode.Value.X - min.X)) && curPointNode.Next != null
                        && Math.Atan2((curPointNode.Next.Value.Y - min.Y), (curPointNode.Next.Value.X - min.X)) ==
                        Math.Atan2((pointNode.Value.Y - min.Y), (pointNode.Value.X - min.X)))
                    {
                        if (min.LengthToPoint(curPointNode.Value) > min.LengthToPoint(pointNode.Value) && min.LengthToPoint(curPointNode.Next.Value) < min.LengthToPoint(pointNode.Value))
                        {
                            var t = curPointNode.Next;
                            curPointNode.Next = new MyLinkedListNode<Point>(pointNode.Value);
                            curPointNode.Next.Previous = curPointNode;
                            curPointNode.Next.Next = t;
                            t.Previous = curPointNode.Next;
                            break;
                        }
                    }
                }
            }
            result.AddFirst(min);
            return result;

        }
    }
}
