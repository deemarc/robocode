using Robocode;
namespace marcTank
{
    internal class EnemyBot 
    {
        private double bearing = 0.0;
        private double distance = 0.0;
        private double energy = 0.0;
        private double heading = 0.0;
        private double velocity = 0.0;

        private string name = "";

        public EnemyBot()
        {
            this.Reset();
        }
        public double GetBearing()
        {
            return this.bearing;
        }
        public double GetDistance()
        {
            return this.distance;
        }
        public double GetEnergy()
        {
            return this.energy;
        }
        public double GetHeading()
        {
            return this.heading;
        }
        public double GetVelociy()
        {
            return this.velocity;
        }

        public string GetName()
        {
            return this.name;
        }
        public void Updata(ScannedRobotEvent evnt)
        {
            bearing     = evnt.Bearing;
            distance    = evnt.Distance;
            energy      = evnt.Energy;
            heading     = evnt.Heading;
            velocity    = evnt.Velocity;

            name = evnt.Name;
        }
        public void Reset()
        {
            bearing = 0.0;
            distance = 0.0;
            energy = 0.0;
            heading = 0.0;
            velocity = 0.0;

            name = "";
        }
    }
}