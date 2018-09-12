using System;

namespace Billiards
{
    public static class BilliardsTask
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="directionRadians">Угол направелния движения шара</param>
        /// <param name="wallInclinationRadians">Угол</param>
        /// <returns></returns>
        public static double TurnRadToDegrees(double ang)
        {
            return (ang * 180) / Math.PI;
        }
        public static double TurnDegreesToRad(double ang)
        {
            return (ang * Math.PI) / 180;
        }
        public static double BounceWall(double directionRadians, double wallInclinationRadians)
        {
            return TurnDegreesToRad(360.0 - TurnRadToDegrees(directionRadians) + 2.0 * TurnRadToDegrees(wallInclinationRadians));
        }
    }
}