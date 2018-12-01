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
        public override void Run()
        {
            while(true)
            {
                TurnGunRight(360);
            }
        }
        
        //This will be called when an enemy is detected, you can access enemy's attributes throught evnt eg. evnt.Name
        public override void OnScannedRobot(ScannedRobotEvent evnt)
        {
            TurnRight(evnt.Bearing);
            Fire(1);
        }
    }
}
