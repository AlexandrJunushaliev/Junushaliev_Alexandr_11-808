// Вставьте сюда финальное содержимое файла VectorTask.cs
using System;

namespace GeometryTasks
{
    //все добавленные нестатические методы в классы 
    //полностью аналогичны методам из класса Geometry.
    //Изменяется только синтаксис
    public class Vector
    {
        public double X;
        public double Y;
        public double GetLength()
        {
            return Geometry.GetLength(new Vector { X = X, Y = Y });
        }

        public Vector Add(Vector vector)
        {
            return Geometry.Add(new Vector { X = X, Y = Y }, vector);
        }

        public bool Belongs(Segment segment)
        {
            var firstSide = Geometry.GetLength(new Segment
            {
                Begin = segment.Begin,
                End = new Vector { X = X, Y = Y }
            });
            var secondSide = Geometry.GetLength(new Segment
            {
                Begin = segment.End,
                End = new Vector { X = X, Y = Y }
            });
            var thirdSide = Geometry.GetLength(segment);
            return firstSide + secondSide == thirdSide;
        }
    }

    public class Geometry
    {
        public static double GetLength(Vector vector)
        {
            return Math.Sqrt(vector.X * vector.X + vector.Y * vector.Y);
        }

        public static Vector Add(Vector vector1, Vector vector2)
        {
            return new Vector { X = vector1.X + vector2.X, Y = vector1.Y + vector2.Y };
            //сложение соответствующих координат
        }

        public static double GetLength(Segment segment)
        {
            return Math.Sqrt(
                (segment.Begin.X - segment.End.X) * (segment.Begin.X - segment.End.X) +
                (segment.Begin.Y - segment.End.Y) * (segment.Begin.Y - segment.End.Y));
            //корень из суммы квадратов разностей соответствующих координат
        }

        public static bool IsVectorInSegment(Vector vector, Segment segment)
        {
            var firstSide = GetLength(new Segment
            {
                Begin = segment.Begin,
                End = new Vector { X = vector.X, Y = vector.Y }
            });
            var secondSide = GetLength(new Segment
            {
                Begin = segment.End,
                End = new Vector { X = vector.X, Y = vector.Y }
            });
            var thirdSide = GetLength(segment);
            return firstSide + secondSide == thirdSide;
            //находим три стороны треугольника с вершинами: начало сегмента, конец сегмента
            //точка, задаваемая вектором - и, если точка принадлежит сегменту,
            //то длина сегмента будет равна сумме длин остальных сторон
        }
    }

    public class Segment
    {
        public Vector Begin;    
        public Vector End;

        public double GetLength()
        {
            return Geometry.GetLength(new Segment { Begin = Begin, End = End });
        }

        public bool Contains(Vector vector)
        {
            var firstSide = Geometry.GetLength(new Segment
            {
                Begin = Begin,
                End = new Vector { X = vector.X, Y = vector.Y }
            });
            var secondSide = Geometry.GetLength(new Segment
            {
                Begin = End,
                End = new Vector { X = vector.X, Y = vector.Y }
            });
            var thirdSide = Geometry.GetLength(new Segment { Begin = Begin, End = End });
            return firstSide + secondSide == thirdSide;
        }
    }
}