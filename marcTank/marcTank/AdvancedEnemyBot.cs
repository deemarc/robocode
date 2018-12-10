using Robocode;
using System;

namespace marcTank
{
    internal class AdvancedEnemyBot : EnemyBot
    {
        private double pos_x = 0.0;
        private double pos_y = 0.0;

        public double GetX()
        {
            return pos_x;
        }
        public double GetY()
        {
            return pos_y;
        }

        override public void Reset()
        {
            base.Reset();
            pos_x = 0.0;
            pos_y = 0.0;
        }
        
        public void UpdateA(ScannedRobotEvent evnt, AdvancedRobot robot)
        {
            base.Updata(evnt);
            myAngle absBearingAng = new myAngle();
            absBearingAng.SetDegree(robot.Heading + evnt.Bearing);
            //if (absBearingDeg < 0) absBearingDeg += 360;
            if (absBearingAng.Degree() <0)
            {
                absBearingAng.SetDegree(absBearingAng.Degree() + 360);
            }
            // yes, you use the _sine_ to get the X value because 0 deg is North
            pos_x = robot.X + Math.Sin(absBearingAng.Radain()) * evnt.Distance;
            
            // yes, you use the _cosine_ to get the Y value because 0 deg is North
            pos_y = robot.Y + Math.Cos(absBearingAng.Radain()) * evnt.Distance;

        }

        public double GetFutureX(long when)
        {
            myAngle robotAng = new myAngle();
            robotAng.SetDegree(this.GetHeading());
            return pos_x + Math.Sin(robotAng.Radain()) * this.GetVelociy() * when;
        }

        public double GetFutureY(long when)
        {
            myAngle robotAng = new myAngle();
            robotAng.SetDegree(this.GetHeading());
            return pos_y + Math.Cos(robotAng.Radain()) * this.GetVelociy() * when;
        }

    }
}