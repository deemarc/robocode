using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace marcTank
{
    public class myAngle
    {
        private double _radian = 0.0;
        private double _degree = 0.0;

        public double Degree()
        {
            return _degree;
        }
        public double Radain()
        {
            return _radian;
        }
        public void SetDegree(double angle)
        {
            _degree = angle;
            _radian = DegreeToRadian(_degree);
        }
        public void SetRadian(double angle)
        {
            _radian = angle;
            _degree = RadianToDegree(_radian);
        }
        public double DegreeToRadian(double angle)
        {
            return (Math.PI / 180) * angle;
        }

        public double RadianToDegree(double angle)
        {
            return angle * (180.0 / Math.PI);
        }


    }
}
