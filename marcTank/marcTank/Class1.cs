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
        //private int scanDirection = 1;
        private EnemyBot enemy = new EnemyBot();
        Random rndmizer = new Random();
        public override void Run()
        {
            this.IsAdjustRadarForRobotTurn = true;
            this.IsAdjustGunForRobotTurn = true;
            enemy.Reset();
            while(true)
            {
                //TurnGunRight(360);
                Move();
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
                enemy.Updata(evnt);
                //scanDirection *= -1;
                TurnRight(evnt.Bearing);
                //SetTurnRadarRight(scanDirection * 360);
                SetTurnRadarRight(this.Heading - this.RadarHeading);
                SetTurnGunRight(this.Heading - this.GunHeading);
                firePwr = 400 / enemy.GetDistance();
                Fire(firePwr);
            }
   
            
            
        }

        void Move()
        {
            int direction = rndmizer.Next(0, 360);
            TurnRight(direction);
            Ahead(rndmizer.Next(50, 200));
        }
    }
}
