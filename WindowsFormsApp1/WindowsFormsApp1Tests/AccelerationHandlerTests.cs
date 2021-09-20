using Microsoft.VisualStudio.TestTools.UnitTesting;
using WindowsFormsApp1;
using System;
using System.Collections.Generic;
using System.Text;

namespace WindowsFormsApp1.Tests
{
    [TestClass()]
    public class AccelerationHandlerTests
    {
        [TestMethod()]
        public void getGesture_forwardPunchReturned()
        {
            Assert.AreEqual(GestureState.SimplePunchX, AccelerationHandler.getGestureState(new Acceleration(200, 125, 125)));
        }

        [TestMethod()]
        public void getGesture_upperCutReturned()
        {
            Assert.AreEqual(GestureState.HighPunchZX, AccelerationHandler.getGestureState(new Acceleration(200, 125, 200)));

        }


        [TestMethod()]
        public void getGesture_righthookReturned()
        {

            Assert.AreEqual(GestureState.RightHookXYZ, AccelerationHandler.getGestureState(new Acceleration(200, 200, 200)));
        }

        [TestMethod()]
        public void getGesture()
        {

            FixedSizedQueue<Acceleration> accelerationsQueue = new FixedSizedQueue<Acceleration>(50);

            for (int i = 0; i < 50; i++) {
                accelerationsQueue.Enqueue(new Acceleration(126, 126, 126));
            }

            for (int i = 0; i < 30; i++)
            {
                accelerationsQueue.Enqueue(new Acceleration(200, 126, 126));
            }
            accelerationsQueue.Enqueue(new Acceleration(201, 126, 126));

            Assert.AreEqual(AccelerationHandler.getGestureStateQueue(accelerationsQueue), GestureState.SimplePunchX);
        }
    }
}