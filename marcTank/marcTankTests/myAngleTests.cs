using Microsoft.VisualStudio.TestTools.UnitTesting;
using marcTank;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace marcTank.Tests
{
    [TestClass()]
    public class myAngleTests
    {
        [TestMethod()]
        public void DegreeTestZero()
        {
            //arrange
            myAngle testDeg = new myAngle();
            double expected = 0.0;
            // act
            Assert.AreEqual(testDeg.Degree(), expected);
            Assert.AreEqual(testDeg.Radain(), expected);
            //Assert.Fail();
        }

        [TestMethod()]
        public void DegreeTestPos()
        {
            myAngle testDeg = new myAngle();
            double expected = Math.PI;

            testDeg.SetDegree(180);

            Assert.AreEqual((int)testDeg.Radain(), (int)expected);
            expected = 180;
            Assert.AreEqual((int)testDeg.Degree(), (int)expected);
        }

        [TestMethod()]
        public void RadainTestPos()
        {
            myAngle testDeg = new myAngle();
            double expected = 0.0;

            testDeg.SetRadian(Math.PI);
            expected = 180;
            Assert.AreEqual(expected, (int)testDeg.Degree());
            expected = Math.PI;
            Assert.AreEqual((int)testDeg.Radain(), (int)expected);
        }

        [TestMethod()]
        public void RadianTestZero()
        {
            myAngle testDeg = new myAngle();
            double expected = 0.0;

            testDeg.SetRadian(0);

            Assert.AreEqual(testDeg.Radain(), expected);
            Assert.AreEqual(testDeg.Degree(), expected);

        }

        //[TestMethod()]
        //public void SetDegreeTest()
        //{
        //    Assert.Fail();
        //}

        //[TestMethod()]
        //public void SetRadianTest()
        //{
        //    Assert.Fail();
        //}

        //[TestMethod()]
        //public void DegreeToRadianTest()
        //{
        //    Assert.Fail();
        //}

        //[TestMethod()]
        //public void RadianToDegreeTest()
        //{
        //    Assert.Fail();
        //}
    }
}