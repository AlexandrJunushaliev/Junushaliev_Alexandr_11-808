using System;

namespace DistanceTask
{
	public static class DistanceTask
	{
		// Расстояние от точки (x, y) до отрезка AB с координатами A(ax, ay), B(bx, by)
		public static double GetDistanceToSegment(double ax, double ay, double bx, double by, double x, double y)
		{
            var l1 = Math.Sqrt((ax - bx) * (ax - bx) + (ay - by) * (ay - by));
            var l2 = Math.Sqrt((x - bx) * (x - bx) + (y - by) * (y - by));
            var l3 = Math.Sqrt((ax - x) * (ax - x) + (ay - y) * (ay - y));
            var p = (l1 + l2 + l3) / 2;
            var h = (2 * Math.Sqrt(p * (p - l1) * (p - l2) * (p - l3))) / l1;
            if (ax == bx && ay == by) return l2;
            else
            if (l2 * l2 > l3 * l3 + l1 * l1 || l3 * l3 > l2 * l2 + l1 * l1)
                return Math.Min(l2, l3);
            else return h;
        }
	}
}