/*  
  Copyright 2007-2017 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the MIT License.  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at https://opensource.org/licenses/MIT.
*/


using System;
using System.Collections.Generic;
using NGenerics.DataStructures.Queues;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Queues.CircularQueueTests
{
    [TestFixture]
    public class CircularQueueTest
    {


        [Test]
        public void RandomEnqueueDequeue()
        {
            var circularQueue = new CircularQueue<int>(66);

            var currentItems = new List<int>();
            var rand = new Random(Convert.ToInt32(DateTime.Now.Ticks % Int32.MaxValue));

            for (var i = 0; i < 513; i++)
            {
                var number = rand.Next(10000);

                if (number % 2 == 0)
                {
                    circularQueue.Enqueue(number);
                    currentItems.Add(number);
                }
                else
                {
                    if (circularQueue.Count > 0)
                    {
                        Assert.IsTrue(currentItems.Remove(circularQueue.Dequeue()));
                    }
                }

                foreach (var item in currentItems)
                {
                    Assert.IsTrue(circularQueue.Contains(item));
                }
            }
        }

        [Test]
        public void RandomEnqueueDequeueStartWithFullQueue()
        {
            var circularQueue = new CircularQueue<int>(50);
            var currentItems = new List<int>();

            for (var i = 0; i < 50; i++)
            {
                circularQueue.Enqueue(i);
                currentItems.Add(i);
            }

            var rand = new Random(Convert.ToInt32(DateTime.Now.Ticks % Int32.MaxValue));

            for (var i = 0; i < 500; i++)
            {
                var number = rand.Next(10000);

                if (number % 2 == 0)
                {
                    if (circularQueue.Count == circularQueue.Capacity)
                    {
                        currentItems.Remove(circularQueue.Peek());
                    }

                    circularQueue.Enqueue(number);
                    currentItems.Add(number);
                }
                else
                {
                    if (circularQueue.Count > 0)
                    {
                        var val = circularQueue.Dequeue();
                        Assert.IsTrue(currentItems.Remove(val));
                    }
                }

                foreach (var item in currentItems)
                {
                    Assert.IsTrue(circularQueue.Contains(item));
                }
            }
        }

        public static CircularQueue<int> GetFullTestQueue()
        {
            var circularQueue = new CircularQueue<int>(200);

            for (var i = 100; i < 200; i++)
            {
                circularQueue.Enqueue(i);
            }

            for (var i = 0; i < 100; i++)
            {
                circularQueue.Enqueue(i);
            }

            return circularQueue;
        }

        public static CircularQueue<int> GetHalfFullTestQueue()
        {
            var circularQueue = new CircularQueue<int>(400);

            for (var i = 100; i < 200; i++)
            {
                circularQueue.Enqueue(i);
            }

            for (var i = 0; i < 100; i++)
            {
                circularQueue.Enqueue(i);
            }

            return circularQueue;
        }

        public static CircularQueue<int> GetOverrunTestQueue()
        {
            var circularQueue = new CircularQueue<int>(40);

            for (var i = 100; i < 200; i++)
            {
                circularQueue.Enqueue(i);
            }

            for (var i = 0; i < 100; i++)
            {
                circularQueue.Enqueue(i);
            }

            return circularQueue;
        }

    }

    
}