using System;
using System.Drawing;
using NUnit.Framework;

namespace Manipulation
{
    public static class ManipulatorTask
    {
        public static double[] MoveManipulatorTo(double x, double y, double angle)
        {
            var wristX = x - Manipulator.Palm * Math.Cos(angle);
            var wristY = y + Manipulator.Palm * Math.Sin(angle);
            var shoulderTowristSide = Math.Sqrt(wristX * wristX + wristY * wristY);

            var elbow = TriangleTask.GetABAngle(Manipulator.UpperArm, Manipulator.Forearm, shoulderTowristSide);

            var firstPartOfShoulder = TriangleTask.GetABAngle(shoulderTowristSide, Manipulator.UpperArm, Manipulator.Forearm);
            var secondPartOfShoulder = Math.Atan2(wristY, wristX);
            var shoulder = firstPartOfShoulder + secondPartOfShoulder;


            var wrist = -angle - elbow - shoulder;

            if (double.IsNaN(shoulder) || double.IsNaN(elbow) || double.IsNaN(wrist))
                return new[] { double.NaN, double.NaN, double.NaN };
            else
                return new[] { shoulder, elbow, wrist };
        }
    }

    [TestFixture]
    public class ManipulatorTask_Tests
    {
        [Test]
        public void TestMoveManipulatorTo()
        {
            for (var i = 0; i < 500; i++)
            {
                Random random = new Random();

                var x = (Manipulator.UpperArm + Manipulator.Forearm + Manipulator.Palm) * random.NextDouble();//получение х от 0 до максимума
                var y = (Manipulator.UpperArm + Manipulator.Forearm + Manipulator.Palm) * random.NextDouble();//аналогично с у
                var angle = 2 * Math.PI * random.NextDouble();//угол от 0 до pi/2
                var angles = ManipulatorTask.MoveManipulatorTo(x, y, angle);//получение массива углов
                var anglesCoordinates = AnglesToCoordinatesTask.GetJointPositions(angles[0], angles[1], angles[2]);
                if (double.IsNaN(anglesCoordinates[2].X) || double.IsNaN(anglesCoordinates[2].Y))
                {
                    continue;
                }
                Assert.AreEqual(x, anglesCoordinates[2].X, 1e-4);
                Assert.AreEqual(y, anglesCoordinates[2].Y, 1e-4);
            }
        }
    }
}