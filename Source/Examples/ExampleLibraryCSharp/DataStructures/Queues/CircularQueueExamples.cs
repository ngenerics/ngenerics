/*  
  Copyright 2007-2013 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/


using System.Diagnostics;
using NGenerics.DataStructures.Queues;
using NGenerics.Patterns.Visitor;
using NUnit.Framework;

namespace ExampleLibraryCSharp.DataStructures.Queues
{
    [TestFixture]
    public class CircularQueueExamples
    {
        #region Accept

        [Test]
        public void AcceptVisitorExample()
        {
            var circularQueue = new CircularQueue<string>(10);
            circularQueue.Enqueue("cat");
            circularQueue.Enqueue("dog");
            circularQueue.Enqueue("canary");

            // There should be 3 items in the circularQueue.
            Assert.AreEqual(3, circularQueue.Count);

            // Create a visitor that will simply count the items in the circularQueue.
            var visitor =
                new CountingVisitor<string>();

            // Make circularQueue call IVisitor<T>.Visit on all items contained.
            circularQueue.AcceptVisitor(visitor);

            // The counting visitor would have visited 3 items.
            Assert.AreEqual(3, visitor.Count);
        }

        #endregion


        #region Enqueue

        [Test]
        public void EnqueueExample()
        {
            var circularQueue = new CircularQueue<string>(10);
            circularQueue.Enqueue("cat");
            circularQueue.Enqueue("dog");
            circularQueue.Enqueue("canary");

            // There should be 3 items in the circularQueue.
            Assert.AreEqual(3, circularQueue.Count);
        }

        #endregion


        #region Dequeue

        [Test]
        public void DequeueExample()
        {

            var circularQueue = new CircularQueue<string>(10);
            circularQueue.Enqueue("dog");
            circularQueue.Enqueue("canary");
            circularQueue.Enqueue("cat");

            // Peek gives us "dog"
            Assert.AreEqual("dog", circularQueue.Dequeue());

            // Peek gives us "canary"
            Assert.AreEqual("canary", circularQueue.Dequeue());

            // Peek gives us "cat"
            Assert.AreEqual("cat", circularQueue.Dequeue());
        }

        #endregion


        #region Clear

        [Test]
        public void ClearExample()
        {
            var circularQueue = new CircularQueue<string>(10);
            circularQueue.Enqueue("cat");
            circularQueue.Enqueue("dog");
            circularQueue.Enqueue("canary");

            // There should be 3 items in the circularQueue.
            Assert.AreEqual(3, circularQueue.Count);

            // Clear the circularQueue
            circularQueue.Clear();

            // The circularQueue should be empty.
            Assert.AreEqual(0, circularQueue.Count);

            // No cat here..
            Assert.IsFalse(circularQueue.Contains("cat"));
        }

        #endregion


        #region Constructor

        [Test]
        public void ConstructorExample()
        {
            var circularQueue = new CircularQueue<string>(10);
            circularQueue.Enqueue("cat");
            circularQueue.Enqueue("dog");
            circularQueue.Enqueue("canary");
        }

        #endregion


        #region Capacity

        [Test]
        public void CapacityExample()
        {
            var circularQueue = new CircularQueue<string>(3);

            // Capacity is 3
            Assert.AreEqual(3, circularQueue.Capacity);

            // Since Capacity is 3 the maximum items existing in the CircularQueue will be 3
            circularQueue.Enqueue("cat");
            circularQueue.Enqueue("dog");
            circularQueue.Enqueue("canary");
            circularQueue.Enqueue("frog");
            circularQueue.Enqueue("snake");
            
            Assert.AreEqual(3, circularQueue.Count);
        }

        #endregion


 #region Contains

        [Test]
        public void ContainsExample()
        {
            var circularQueue = new CircularQueue<string>(10);
            circularQueue.Enqueue("cat");
            circularQueue.Enqueue("dog");
            circularQueue.Enqueue("canary");

            // circularQueue does contain cat, dog and canary
            Assert.IsTrue(circularQueue.Contains("cat"));
            Assert.IsTrue(circularQueue.Contains("dog"));
            Assert.IsTrue(circularQueue.Contains("canary"));
            // but not frog
            Assert.IsFalse(circularQueue.Contains("frog"));
        }

        #endregion


        #region CopyTo

        [Test]
        public void CopyToExample()
        {
            var circularQueue = new CircularQueue<string>(10);
            circularQueue.Enqueue("cat");
            circularQueue.Enqueue("dog");
            circularQueue.Enqueue("canary");
            circularQueue.Enqueue("canary");

            // create new string array 
            // note that the count is 4 because "canary" will exists twice.
            var stringArray = new string[4];
            circularQueue.CopyTo(stringArray, 0);
        }

        #endregion


        #region Count

        [Test]
        public void CountExample()
        {
            var circularQueue = new CircularQueue<string>(10);
            circularQueue.Enqueue("cat");
            circularQueue.Enqueue("dog");
            circularQueue.Enqueue("canary");
            circularQueue.Enqueue("canary");

            // Count is 4
            Assert.AreEqual(4, circularQueue.Count);
        }

        #endregion


        #region GetEnumerator

        [Test]
        public void GetEnumeratorExample()
        {
            var circularQueue = new CircularQueue<string>(10);
            circularQueue.Enqueue("cat");
            circularQueue.Enqueue("dog");
            circularQueue.Enqueue("dog");
            circularQueue.Enqueue("canary");

            // Get the enumerator and iterate through it.
            var enumerator = circularQueue.GetEnumerator();
            while (enumerator.MoveNext())
            {
                Debug.WriteLine(enumerator.Current);
            }
        }

        #endregion


        #region IsEmpty

        [Test]
        public void IsEmptyExample()
        {
            var circularQueue = new CircularQueue<string>(10);

            // CircularQueue will be empty initially
            Assert.IsTrue(circularQueue.IsEmpty);

            circularQueue.Enqueue("cat");

            // CircularQueue will be not be empty when an item is added
            Assert.IsFalse(circularQueue.IsEmpty);

            circularQueue.Clear();

            // CircularQueue will be empty when items are cleared
            Assert.IsTrue(circularQueue.IsEmpty);
        }

        #endregion




        #region IsFull

        [Test]
        public void IsFullExample()
        {

            var circularQueue = new CircularQueue<string>(3);

            // IsFull is false
            Assert.IsFalse(circularQueue.IsFull);

            // Enqueue 3 items
            circularQueue.Enqueue("cat");
            circularQueue.Enqueue("dog");
            circularQueue.Enqueue("canary");

            // IsFull is true
            Assert.IsTrue(circularQueue.IsFull);
        }

        #endregion


        #region IsReadOnly

        [Test]
        public void IsReadOnlyExample()
        {
            var circularQueue = new CircularQueue<string>(10);
            // IsReadOnly is always false for a CircularQueue
            Assert.IsFalse(circularQueue.IsReadOnly);
            circularQueue.Enqueue("cat");
            circularQueue.Enqueue("dog");
            circularQueue.Enqueue("canary");
            Assert.IsFalse(circularQueue.IsReadOnly);
        }

        #endregion


        #region Remove

        [Test]
        public void RemoveExample()
        {
            var circularQueue = new CircularQueue<string>(10);
            circularQueue.Enqueue("dog");
            circularQueue.Enqueue("canary");
            circularQueue.Enqueue("cat");

            // Does contain "canary"
            Assert.IsTrue(circularQueue.Contains("canary"));

            // Remove "canary". Not that this remove the first item it finds 
            circularQueue.Remove("canary");

            // Does contain not "canary"
            Assert.IsFalse(circularQueue.Contains("canary"));
        }

        #endregion


        #region Peek

        [Test]
        public void PeekExample()
        {
            var circularQueue = new CircularQueue<string>(10);

            circularQueue.Enqueue("cat");
            // Peek is "cat"
            Assert.AreEqual("cat", circularQueue.Peek());

            circularQueue.Enqueue("dog");
            // Peek gives us "cat" because it is still the first item
            Assert.AreEqual("cat", circularQueue.Peek());

            circularQueue.Enqueue("canary");
            // Peek gives us "cat" because it is still the first item
            Assert.AreEqual("cat", circularQueue.Peek());
        }

        #endregion


     }
}