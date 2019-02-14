using System;
using System.Collections.Generic;

namespace func_rocket
{
    public class LevelsTask
    {
        static readonly Physics standardPhysics = new Physics();

        public static IEnumerable<Level> CreateLevels()
        {
            yield return new Level("Zero",
                new Rocket(new Vector(200, 500), Vector.Zero, -0.5 * Math.PI),
                new Vector(600, 200),
                (size, v) => Vector.Zero, standardPhysics);
            yield return new Level("Heavy",
                new Rocket(new Vector(200, 500), Vector.Zero, -0.5 * Math.PI),
                new Vector(600, 200),
                (size, v) => new Vector(0.0, 0.9), standardPhysics);
            yield return new Level("Up",
                new Rocket(new Vector(200, 500), Vector.Zero, -0.5 * Math.PI),
                new Vector(700, 500),
                (size, v) => new Vector(0.0, -300 / (size.Height - v.Y + 300.0)), standardPhysics);
            yield return new Level("WhiteHole",
                new Rocket(new Vector(200, 500), Vector.Zero, -0.5 * Math.PI),
                new Vector(600, 200),
                (size, v) => WhiteHole(v), standardPhysics);
        }
        private static Vector WhiteHole(Vector v)
        {
            return (new Vector(600, 200) - v).Normalize() * 140 * GravityVector(v, new Vector(600, 200));
        }
        private static double GravityVector(Vector v, Vector target)
        {
            return (target-v).Length / (Math.Pow((target - v).Length, 2)+ 1);
        }
    }
}