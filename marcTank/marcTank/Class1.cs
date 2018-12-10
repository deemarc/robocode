using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Robocode;
using System.Drawing;

namespace marcTank
{
    public class Class1 : AdvancedRobot
    {
        private int moveDirection = 1;
        private int turnDirection = 1;
        //private EnemyBot enemy = new EnemyBot();
        private AdvancedEnemyBot enemy = new AdvancedEnemyBot();
        Random rndmizer = new Random();
        public override void Run()
        {
            this.IsAdjustRadarForRobotTurn = true;// true;
            this.IsAdjustGunForRobotTurn = true; // true;
            this.IsAdjustRadarForGunTurn = true;
            enemy.Reset();
            while(true)
            {
                //TurnGunRight(360);
                //Move();
                DoMove();
                TurnRadarRight(360);
                

            }
        }
        public override void OnRobotDeath(RobotDeathEvent evnt)
        {
            if (evnt.Name.Equals(enemy.GetName()))
            {
                enemy.Reset();
            }
        }
        // normalizes a bearing to between +180 and -180
        double NormalizeBearing(double angle)
        {
            while (angle > 180) angle -= 360;
            while (angle < -180) angle += 360;
            return angle;
        }
        // computes the absolute bearing between two points
        double AbsoluteBearing(double x1, double y1, double x2, double y2)
        {
            double xo = x2 - x1;
            double yo = y2 - y1;
            double absDist = Math.Sqrt(Math.Pow(xo, 2) + Math.Pow(yo, 2));// sqrt of(x^2 + y^2)
            myAngle arcSin = new myAngle();
            arcSin.SetRadian(Math.Asin(xo / absDist));
            double bearing = 0;

            if (xo > 0 && yo > 0)
            { // both pos: lower-Left
                bearing = arcSin.Degree();
            }
            else if (xo < 0 && yo > 0)
            { // x neg, y pos: lower-right
                bearing = 360 + arcSin.Degree(); // arcsin is negative here, actuall 360 - ang
            }
            else if (xo > 0 && yo < 0)
            { // x pos, y neg: upper-left
                bearing = 180 - arcSin.Degree();
            }
            else if (xo < 0 && yo < 0)
            { // both neg: upper-right
                bearing = 180 - arcSin.Degree(); // arcsin is negative here, actually 180 + ang
            }

            return bearing;
        }
        double AimShot(double firePwr)
        {
            double bulletSpeed = 20 - firePwr * 3;
            long time = (long)(enemy.GetDistance() / bulletSpeed);

            // calculate gun turn to predicted x,y location
            double futureX = enemy.GetFutureX(time);
            double futureY = enemy.GetFutureY(time);
            double absDeg = AbsoluteBearing(this.X, this.Y, futureX, futureY);
            return NormalizeBearing(absDeg - this.GunHeading);
        }

        ////We woundn't want to hit the wall!
        //public override void OnHitWall(HitWallEvent evnt)
        //{
        //    moveDirection *= -1;
        //}

        //This will be called when an enemy is detected, you can access enemy's attributes throught evnt eg. evnt.Name
        public override void OnScannedRobot(ScannedRobotEvent evnt)
        {
            double firePwr = 0.0;
            if(//we have no enemy or
                enemy.GetName() == "" ||
                //the one we just spotted is closer 0r
                enemy.GetDistance() > evnt.Distance ||
                //its the same enemy
                enemy.GetName() == evnt.Name)
            {
                enemy.UpdateA(evnt,this);
                firePwr = Math.Min(400 / enemy.GetDistance(), 3);
                // turn the gun to the predicted x,y location
                double bearing = AimShot(firePwr);
                //this.SetTurnGunRight(bearing);
                //scanDirection *= -1;
                //SetTurnGunRight(this.Heading - this.GunHeading + bearing);
                //TurnRight(bearing);
                //DoMove();
                //SetTurnRadarRight(scanDirection * 360);
                //SetTurnRadarRight(this.Heading - this.RadarHeading);
                double gunAim = NormalizeBearing(bearing);
                SetTurnGunRight(gunAim);
                //this.SetTurnGunRight(bearing);
                //this.TurnRight(bearing);
                Console.WriteLine("Firing power: {0}", firePwr);
                // if the gun is cool and we're pointed at the target, shoot!
                if (this.GunHeat == 0 && Math.Abs(this.GunTurnRemaining) < 10)
                {
                    this.SetFire(firePwr);
                }
                {
                    Console.WriteLine("cannot shoot");
                }
                   
            }
   
            
            
        }

        void DoMove()
        {
            // switch directions if we've stopped
            if (this.Velocity == 0)
                moveDirection *= -1;

            // circle our enemy
            this.SetTurnRight(enemy.GetBearing() + 45* turnDirection);
            this.SetAhead(50 * moveDirection);
            turnDirection *= -1;
            //int direction = rndmizer.Next(0, 360);
            //TurnRight(direction);
            //Ahead(rndmizer.Next(100));
        }

        
        
    }
}
