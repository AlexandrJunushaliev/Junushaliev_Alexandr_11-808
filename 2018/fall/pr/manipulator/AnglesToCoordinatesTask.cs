using System;
using System.Drawing;
using NUnit.Framework;

namespace Manipulation
{
    public static class AnglesToCoordinatesTask
    {
        public static PointF[] GetJointPositions(double shoulder, double elbow, double wrist)
        {
            var forearmHorizontalAngle = elbow + Math.PI + shoulder;
            //получение угла между forearm и горизонталью
            var palmHorizontalAngle = forearmHorizontalAngle + wrist + Math.PI;
            //получение угла между palm и горизонталью
            var elbowX = Math.Cos(shoulder) * Manipulator.UpperArm;//координата х у elbow
            var elbowY = Math.Sin(shoulder) * Manipulator.UpperArm;//координата у у elbow
            var wristX = Math.Cos(forearmHorizontalAngle) * Manipulator.Forearm + elbowX;
            //координата х у wrist
            var wristY = Math.Sin(forearmHorizontalAngle) * Manipulator.Forearm + elbowY;
            //координата у у wrist
            var palmX = Math.Cos(palmHorizontalAngle) * Manipulator.Palm + wristX;
            //координата х у palm
            var palmY = Math.Sin(palmHorizontalAngle) * Manipulator.Palm + wristY;
            //координата у у palm
            var elbowPos = new PointF((float)elbowX, (float)elbowY);//создание соответствующих точек
            var wristPos = new PointF((float)wristX, (float)wristY);
            var palmEndPos = new PointF((float)palmX, (float)palmY);
            return new PointF[]
            {
                elbowPos,
                wristPos,
                palmEndPos
            };
        }
    }

    [TestFixture]   
    public class AnglesToCoordinatesTask_Tests
    {
        [TestCase(Math.PI / 2, Math.PI / 2, Math.PI, Manipulator.Forearm + Manipulator.Palm,
        Manipulator.UpperArm)]
        [TestCase(0, Math.PI, Math.PI, Manipulator.Forearm
        + Manipulator.Palm + Manipulator.UpperArm, 0) ]
        [TestCase(Math.PI / 2, Math.PI, Math.PI, 0, Manipulator.UpperArm
        + Manipulator.Forearm + Manipulator.Palm)]
        public void TestGetJointPositions(double shoulder, double elbow, double wrist, double palmEndX, double palmEndY)
        {
            var joints = AnglesToCoordinatesTask.GetJointPositions(shoulder, elbow, wrist);
            Assert.AreEqual(palmEndX, joints[2].X, 1e-5, "palm endX");
            Assert.AreEqual(palmEndY, joints[2].Y, 1e-5, "palm endY");
            Assert.AreEqual(Manipulator.UpperArm, GetDistance(0, 0, joints[0].X, joints[0].Y), 1e-5, "Upper Arm Length");
            Assert.AreEqual(Manipulator.Forearm, GetDistance(joints[0].X, joints[0].Y, joints[1].X, joints[1].Y), 1e-5, "Forearm Length");
            Assert.AreEqual(Manipulator.Palm, GetDistance(joints[1].X, joints[1].Y, joints[2].X, joints[2].Y), 1e-5, "Palm Length");
        }

        public static double GetDistance(float x1, float y1, float x2, float y2)
        {
            return Math.Sqrt((x1 - x2) * (x1 - x2) + (y1 - y2) * (y1 - y2));
        }
    }
}
