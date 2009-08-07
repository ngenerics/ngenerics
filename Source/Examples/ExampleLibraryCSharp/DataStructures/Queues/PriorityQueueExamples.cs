/*  
 Copyright 2009 The NGenerics Team
 (http://www.codeplex.com/NGenerics/Wiki/View.aspx?title=Team)

 This program is licensed under the Microsoft Permissive License (Ms-PL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.codeplex.com/NGenerics/Project/License.aspx.
*/

using System.Diagnostics;
using NGenerics.DataStructures.Queues;
using NGenerics.Patterns.Visitor;
using NUnit.Framework;

namespace ExampleLibraryCSharp.DataStructures.Queues
{
    [TestFixture]
    public class PriorityQueueExamples
    {
        #region Accept

        [Test]
        public void AcceptVisitorExample()
        {
            var priorityQueue = new PriorityQueue<string, int>(PriorityQueueType.Minimum);
            priorityQueue.Enqueue("cat");
            priorityQueue.Enqueue("dog");
            priorityQueue.Enqueue("canary");

            // There should be 3 items in the priorityQueue.
            Assert.AreEqual(3, priorityQueue.Count);

            // Create a visitor that will simply count the items in the priorityQueue.
            var visitor =
                new CountingVisitor<string>();

            // Make priorityQueue call IVisitor<T>.Visit on all items contained.
            priorityQueue.AcceptVisitor(visitor);

            // The counting visitor would have visited 3 items.
            Assert.AreEqual(3, visitor.Count);
        }

        #endregion
        
        #region Add

        [Test]
        public void AddExample()
        {
            var priorityQueue = new PriorityQueue<string, int>(PriorityQueueType.Minimum);
            priorityQueue.Add("cat");
            priorityQueue.Add("dog");
            priorityQueue.Add("canary");

            // There will be 3 items in the priorityQueue.
            Assert.AreEqual(3, priorityQueue.Count);
        }

        #endregion
        
        #region AddPriority

        [Test]
        public void AddPriorityExample()
        {
            var priorityQueue = new PriorityQueue<string, int>(PriorityQueueType.Minimum);
            priorityQueue.Add("cat", 2);
            priorityQueue.Add("canary", 1);
            priorityQueue.Add("dog", 3);

            // There will be 3 items in the priorityQueue.
            Assert.AreEqual(3, priorityQueue.Count);

            // "canary" will be at the top as it has the highest priority
            Assert.AreEqual("canary", priorityQueue.Peek());
        }

        #endregion
        
        #region EnqueuePriority

        [Test]
        public void EnqueuePriorityExample()
        {
            var priorityQueue = new PriorityQueue<string, int>(PriorityQueueType.Minimum);
            priorityQueue.Enqueue("cat", 2);
            priorityQueue.Enqueue("canary", 1);
            priorityQueue.Enqueue("dog", 3);

            // There will be 3 items in the priorityQueue.
            Assert.AreEqual(3, priorityQueue.Count);

            // "canary" will be at the top as it has the highest priority
            Assert.AreEqual("canary", priorityQueue.Peek());
        }

        #endregion
        
        #region Enqueue

        [Test]
        public void EnqueueExample()
        {
            var priorityQueue = new PriorityQueue<string, int>(PriorityQueueType.Minimum);
            priorityQueue.Enqueue("cat");
            priorityQueue.Enqueue("dog");
            priorityQueue.Enqueue("canary");

            // There should be 3 items in the priorityQueue.
            Assert.AreEqual(3, priorityQueue.Count);
        }

        #endregion
        
        #region Dequeue

        [Test]
        public void DequeueExample()
        {

            var priorityQueue = new PriorityQueue<string, int>(PriorityQueueType.Minimum);
            priorityQueue.Enqueue("dog",2);
            priorityQueue.Enqueue("canary",1);
            priorityQueue.Enqueue("cat",3);

            // Peek gives us "canary"
            Assert.AreEqual("canary", priorityQueue.Dequeue());

            // Peek gives us "dog"
            Assert.AreEqual("dog", priorityQueue.Dequeue());

            // Peek gives us "cat"
            Assert.AreEqual("cat", priorityQueue.Dequeue());
        }

        #endregion

        #region DequeueWithPriority

        [Test]
        public void DequeueWithPriorityExample()
        {
            var priorityQueue = new PriorityQueue<string, int>(PriorityQueueType.Minimum);
            priorityQueue.Enqueue("dog",2);
            priorityQueue.Enqueue("canary",1);
            priorityQueue.Enqueue("cat",3);

            int priority;

            // Peek gives us "canary"
            Assert.AreEqual("canary", priorityQueue.Dequeue(out priority));

            // With priority 1
            Assert.AreEqual(priority, 1);

            // Peek gives us "dog"
            Assert.AreEqual("dog", priorityQueue.Dequeue(out priority));

            // With priority 2
            Assert.AreEqual(priority, 2);

            // Peek gives us "cat"
            Assert.AreEqual("cat", priorityQueue.Dequeue(out priority));

            // With priority 3
            Assert.AreEqual(priority, 3);
        }

        #endregion
        
        #region Clear

        [Test]
        public void ClearExample()
        {
            var priorityQueue = new PriorityQueue<string, int>(PriorityQueueType.Minimum);
            priorityQueue.Enqueue("cat");
            priorityQueue.Enqueue("dog");
            priorityQueue.Enqueue("canary");

            // There should be 3 items in the priorityQueue.
            Assert.AreEqual(3, priorityQueue.Count);

            // Clear the priorityQueue
            priorityQueue.Clear();

            // The priorityQueue should be empty.
            Assert.AreEqual(0, priorityQueue.Count);

            // No cat here..
            Assert.IsFalse(priorityQueue.Contains("cat"));
        }

        #endregion
        
        #region Constructor

        [Test]
        public void ConstructorExample()
        {
            var priorityQueue = new PriorityQueue<string, int>(PriorityQueueType.Minimum);
            priorityQueue.Enqueue("cat");
            priorityQueue.Enqueue("dog");
            priorityQueue.Enqueue("canary");
        }

        #endregion
                
        #region Contains

        [Test]
        public void ContainsExample()
        {
            var priorityQueue = new PriorityQueue<string, int>(PriorityQueueType.Minimum);
            priorityQueue.Enqueue("cat");
            priorityQueue.Enqueue("dog");
            priorityQueue.Enqueue("canary");

            // priorityQueue does contain cat, dog and canary
            Assert.IsTrue(priorityQueue.Contains("cat"));
            Assert.IsTrue(priorityQueue.Contains("dog"));
            Assert.IsTrue(priorityQueue.Contains("canary"));
            // but not frog
            Assert.IsFalse(priorityQueue.Contains("frog"));
        }

        #endregion
        
        #region CopyTo

        [Test]
        public void CopyToExample()
        {
            var priorityQueue = new PriorityQueue<string, int>(PriorityQueueType.Minimum);
            priorityQueue.Enqueue("cat");
            priorityQueue.Enqueue("dog");
            priorityQueue.Enqueue("canary");
            priorityQueue.Enqueue("canary");

            // create new string array 
            // note that the count is 4 because "canary" will exists twice.
            var stringArray = new string[4];
            priorityQueue.CopyTo(stringArray, 0);
        }

        #endregion
        
        #region Count

        [Test]
        public void CountExample()
        {
            var priorityQueue = new PriorityQueue<string, int>(PriorityQueueType.Minimum);
            priorityQueue.Enqueue("cat");
            priorityQueue.Enqueue("dog");
            priorityQueue.Enqueue("canary");
            priorityQueue.Enqueue("canary");

            // Count is 4
            Assert.AreEqual(4, priorityQueue.Count);
        }

        #endregion
        
        #region GetEnumerator

        [Test]
        public void GetEnumeratorExample()
        {
            var priorityQueue = new PriorityQueue<string, int>(PriorityQueueType.Minimum);
            priorityQueue.Enqueue("cat");
            priorityQueue.Enqueue("dog");
            priorityQueue.Enqueue("dog");
            priorityQueue.Enqueue("canary");

            // Get the enumerator and iterate through it.
            var enumerator = priorityQueue.GetEnumerator();
            while (enumerator.MoveNext())
            {
                Debug.WriteLine(enumerator.Current);
            }
        }

        #endregion
        
        #region GetKeyEnumerator

        [Test]
        public void GetKeyEnumeratorExample()
        {
            var priorityQueue = new PriorityQueue<string, int>(PriorityQueueType.Minimum);
            priorityQueue.Enqueue("cat");
            priorityQueue.Enqueue("dog");
            priorityQueue.Enqueue("dog");
            priorityQueue.Enqueue("canary");

            // Get the enumerator and iterate through it.
            var enumerator = priorityQueue.GetKeyEnumerator();
            while (enumerator.MoveNext())
            {
                Debug.WriteLine(enumerator.Current.Key);
                Debug.WriteLine(enumerator.Current.Value);
            }
        }

        #endregion
        
        #region IsReadOnly

        [Test]
        public void IsReadOnlyExample()
        {
            var priorityQueue = new PriorityQueue<string, int>(PriorityQueueType.Minimum);

            // IsReadOnly is always false for a PriorityQueue
            Assert.IsFalse(priorityQueue.IsReadOnly);
            priorityQueue.Enqueue("cat");
            priorityQueue.Enqueue("dog");
            priorityQueue.Enqueue("canary");
            Assert.IsFalse(priorityQueue.IsReadOnly);
        }

        #endregion
        
        #region Remove

        [Test]
        public void RemoveExample()
        {
            var priorityQueue = new PriorityQueue<string, int>(PriorityQueueType.Minimum);

            // Does not contain "canary"
            Assert.IsFalse(priorityQueue.Contains("canary"));

            priorityQueue.Enqueue("canary");

            // Does contain "canary"
            Assert.IsTrue(priorityQueue.Contains("canary"));
        }

        #endregion
        
        #region Peek

        [Test]
        public void PeekExample()
        {
            var priorityQueue = new PriorityQueue<string, int>(PriorityQueueType.Minimum);

            priorityQueue.Enqueue("cat");
            // Peek is "cat"
            Assert.AreEqual("cat", priorityQueue.Peek());

            priorityQueue.Enqueue("dog");
            // Peek gives us "cat" because it is still the first item
            Assert.AreEqual("cat", priorityQueue.Peek());

            priorityQueue.Enqueue("canary");
            // Peek gives us "cat" because it is still the first item
            Assert.AreEqual("cat", priorityQueue.Peek());
        }

        #endregion

        #region PeekPriority

        [Test]
        public void PeekPriorityExample() {
            var priorityQueue = new PriorityQueue<string, int>(PriorityQueueType.Minimum);

            int priority;

            priorityQueue.Enqueue("cat", 3);
            
            // Peek is "cat", priority is 3
            var nextItem = priorityQueue.Peek(out priority);
            Assert.AreEqual("cat", nextItem);
            Assert.AreEqual(priority, 3);

            priorityQueue.Enqueue("dog", 4);

            // Peek gives us "cat" because it is still the first item
            nextItem = priorityQueue.Peek(out priority);
            Assert.AreEqual("cat", nextItem);
            Assert.AreEqual(priority, 3);

            priorityQueue.Enqueue("canary", 2);
            
            // Peek gives us "canary" since the priority is less than that of cat
            nextItem = priorityQueue.Peek(out priority);
            Assert.AreEqual("canary", nextItem);
            Assert.AreEqual(priority, 2);
        }

        #endregion
    }
}