using System;

namespace Rectangles
{
	public static class RectanglesTask
	{
        // Пересекаются ли два прямоугольника (пересечение только по границе также считается пересечением)
        public static bool AreIntersected(Rectangle r1, Rectangle r2)
        {
            // так можно обратиться к координатам левого верхнего угла первого прямоугольника: r1.Left, r1.Top
            return !(r1.Left > r2.Right || r1.Right < r2.Left || r1.Top > r2.Bottom || r1.Bottom < r2.Top); // Все случаи, когда прямоугольники не пересекаются        
        }
        // Площадь пересечения прямоугольников
        public static int IntersectionSquare(Rectangle r1, Rectangle r2)
		{
            if (!AreIntersected(r1,r2))
                return 0;
            else
            {
                var x1 = 0;
                var x2 = 0;
                var y1 = 0;
                var y2 = 0;
                if (r1.Left >= r2.Left && r1.Right <= r2.Right) //стенки, параллельные оси oy, первого между аналогичными стенками второго
                {
                    x1 = r1.Left;
                    x2 = r1.Right;
                }
                else if (r2.Left >= r1.Left && r2.Right <= r1.Right) //стенки, параллельные оси oy, второго между аналогичными стенками первого
                {
                    x1 = r2.Left;
                    x2 = r2.Right;
                }
                else if (r1.Left<=r2.Right && r2.Left<=r1.Left) //левая стенка первого между левой и правой стенками второго
                {
                    x1 = r2.Right;
                    x2 = r1.Left;
                }
                else  //правая стенка первого между левой и правой стенками второго
                {
                    x1 = r1.Right;
                    x2 = r2.Left;
                }
                if (r1.Top >= r2.Top && r1.Bottom <= r2.Bottom)  //стенки, параллельные оси oх, первого между аналогичными стенками второго
                {
                    y1 = r1.Top;
                    y2 = r1.Bottom;
                }
                else if (r2.Top >= r1.Top && r2.Bottom <= r1.Bottom) //стенки, параллельные оси oy, второго между аналогичными стенками первого
                {
                    y1 = r2.Top;
                    y2 = r2.Bottom;
                }
                else if (r1.Top <= r2.Bottom && r2.Top<=r1.Top) // верхняя стенка первого между верхней и нижней стенками второго
                {
                    y1 = r1.Top;
                    y2 = r2.Bottom;
                }
                else // нижняя стенка первого между верхней и нижней стенками второго
                {
                    y1 = r2.Top;
                    y2 = r1.Bottom;
                }
                return Math.Abs(y2 - y1) * Math.Abs(x2 - x1);
            }
		}
		// Если один из прямоугольников целиком находится внутри другого — вернуть номер (с нуля) внутреннего.
		// Иначе вернуть -1
		// Если прямоугольники совпадают, можно вернуть номер любого из них.
		public static int IndexOfInnerRectangle(Rectangle r1, Rectangle r2)
		{
            if (r1.Left >= r2.Left && r1.Right <= r2.Right && r1.Top >= r2.Top && r1.Bottom <= r2.Bottom) //Проверка на то, лежат ли границы первого прямоугольника внутри границ/на границах второго
                return 0;   
            else if (r2.Left >= r1.Left && r2.Right <= r1.Right && r2.Top >= r1.Top && r2.Bottom <= r1.Bottom) //Проверка на то, лежат ли границы второго прямоугольника внутри границ/на границах первого
                return 1; 
            else
                return -1;
        }
	}
}