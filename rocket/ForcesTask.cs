using System;
using System.Drawing;
using System.Linq;

namespace func_rocket
{
	public class ForcesTask
	{
		/// <summary>
		/// Создает делегат, возвращающий по ракете вектор силы тяги двигателей этой ракеты.
		/// Сила тяги направлена вдоль ракеты и равна по модулю forceValue.
		/// </summary>
		public static RocketForce GetThrustForce(double forceValue)
		{
            return r => new Vector(Math.Abs(forceValue), 0).Rotate(r.Direction);
        }

		/// <summary>
		/// Преобразует делегат силы гравитации, в делегат силы, действующей на ракету
		/// </summary>
		public static RocketForce ConvertGravityToForce(Gravity gravity, Size spaceSize)
		{
            return r => new Vector(gravity(spaceSize, r.Location).X, gravity(spaceSize, r.Location).Y);
        }

		/// <summary>
		/// Суммирует все переданные силы, действующие на ракету, и возвращает суммарную силу.
		/// </summary>
		public static RocketForce Sum(params RocketForce[] forces)
		{
            return r =>
            {
                Vector sum = Vector.Zero;
                foreach (var force in forces)
                {
                    sum += force(r);
                }
                return sum;
            };
            
		}
	}
}