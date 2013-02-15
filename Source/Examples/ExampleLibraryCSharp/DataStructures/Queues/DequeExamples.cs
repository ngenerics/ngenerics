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
    public class DequeExamples
    {
        #region Accept

        [Test]
        public void AcceptVisitorExample()
        {
            var deque = new Deque<string>();
            deque.EnqueueHead("cat");
            deque.EnqueueHead("dog");
            deque.EnqueueHead("canary");

            // There should be 3 items in the deque.
            Assert.AreEqual(3, deque.Count);

            // Create a visitor that will simply count the items in the deque.
            var visitor =
                new CountingVisitor<string>();

            // Make deque call IVisitor<T>.Visit on all items contained.
            deque.AcceptVisitor(visitor);

            // The counting visitor would have visited 3 items.
            Assert.AreEqual(3, visitor.Count);
        }

        #endregion
        
        #region Clear

        [Test]
        public void ClearExample()
        {
            var deque = new Deque<string>();
            deque.EnqueueHead("cat");
            deque.EnqueueHead("dog");
            deque.EnqueueHead("canary");

            // There should be 3 items in the deque.
            Assert.AreEqual(3, deque.Count);

            // Clear the deque
            deque.Clear();

            // The deque should be empty.
            Assert.AreEqual(0, deque.Count);

            // No cat here..
            Assert.IsFalse(deque.Contains("cat"));
        }

        #endregion

        #region Constructor

        [Test]
        public void ConstructorExample()
        {
            var deque = new Deque<string>();
            deque.EnqueueHead("cat");
            deque.EnqueueHead("dog");
            deque.EnqueueHead("canary");
            Assert.AreEqual(3, deque.Count);
        }

        #endregion
        
        #region ConstructorCollection

        [Test]
        public void ConstructorCollectionExample()
        {
            var array = new[]{"cat", "dog", "canary"};
            var deque = new Deque<string>(array);
            Assert.AreEqual(3, deque.Count);
        }

        #endregion
           
        #region Contains

        [Test]
        public void ContainsExample()
        {
            var deque = new Deque<string>();
            deque.EnqueueHead("cat");
            deque.EnqueueHead("dog");
            deque.EnqueueHead("canary");

            // deque does contain cat, dog and canary
            Assert.IsTrue(deque.Contains("cat"));
            Assert.IsTrue(deque.Contains("dog"));
            Assert.IsTrue(deque.Contains("canary"));
            // but not frog
            Assert.IsFalse(deque.Contains("frog"));
        }

        #endregion
        
        #region CopyTo

        [Test]
        public void CopyToExample()
        {
            var deque = new Deque<string>();
            deque.EnqueueHead("cat");
            deque.EnqueueHead("dog");
            deque.EnqueueHead("canary");
            deque.EnqueueHead("canary");

            // create new string array 
            // note that the count is 4 because "canary" will exists twice.
            var stringArray = new string[4];
            deque.CopyTo(stringArray, 0);
        }

        #endregion
        
        #region Count

        [Test]
        public void CountExample()
        {
            var deque = new Deque<string>();
            deque.EnqueueHead("cat");
            deque.EnqueueHead("dog");
            deque.EnqueueHead("canary");
            deque.EnqueueHead("canary");

            // Count is 4
            Assert.AreEqual(4, deque.Count);
        }

        #endregion
        
        #region DequeueHead

        [Test]
        public void DequeueHeadExample()
        {

            var deque = new Deque<string>();
            deque.EnqueueHead("dog");
            deque.EnqueueHead("canary");
            deque.EnqueueHead("cat");

            // DequeueHead gives us "cat"
            Assert.AreEqual("cat", deque.DequeueHead());

            // DequeueHead gives us "canary"
            Assert.AreEqual("canary", deque.DequeueHead());

            // DequeueHead gives us "dog"
            Assert.AreEqual("dog", deque.DequeueHead());
        }

           #endregion
        
        #region DequeueTail

        [Test]
        public void DequeueTailExample()
        {

            var deque = new Deque<string>();
            deque.EnqueueHead("dog");
            deque.EnqueueHead("canary");
            deque.EnqueueHead("cat");

            // DequeueTail gives us "dog"
            Assert.AreEqual("dog", deque.DequeueTail());

            // DequeueTail gives us "canary"
            Assert.AreEqual("canary", deque.DequeueTail());

            // DequeueTail gives us "cat"
            Assert.AreEqual("cat", deque.DequeueTail());

        }

        #endregion
        
        #region EnqueueHead

        [Test]
        public void EnqueueHeadExample()
        {
            var deque = new Deque<string>();
            deque.EnqueueHead("cat");
            Assert.AreEqual("cat", deque.Head);
            Assert.AreEqual("cat", deque.Tail);

            deque.EnqueueHead("dog");
            Assert.AreEqual("dog", deque.Head);
            Assert.AreEqual("cat", deque.Tail);

            deque.EnqueueHead("canary");
            Assert.AreEqual("canary", deque.Head);
            Assert.AreEqual("cat", deque.Tail);
            
            // There should be 3 items in the deque.
            Assert.AreEqual(3, deque.Count);
        }

        #endregion
        
        #region EnqueueTail

        [Test]
        public void EnqueueTailExample()
        {
            var deque = new Deque<string>();
            deque.EnqueueTail("cat");
            Assert.AreEqual("cat", deque.Head);
            Assert.AreEqual("cat", deque.Tail);

            deque.EnqueueTail("dog");
            Assert.AreEqual("cat", deque.Head);
            Assert.AreEqual("dog", deque.Tail);

            deque.EnqueueTail("canary");
            Assert.AreEqual("cat", deque.Head);
            Assert.AreEqual("canary", deque.Tail);

            // There should be 3 items in the deque.
            Assert.AreEqual(3, deque.Count);
        }

        #endregion
        
        #region GetEnumerator

        [Test]
        public void GetEnumeratorExample()
        {
            var deque = new Deque<string>();
            deque.EnqueueHead("cat");
            deque.EnqueueHead("dog");
            deque.EnqueueHead("dog");
            deque.EnqueueHead("canary");

            // Get the enumerator and iterate through it.
            var enumerator = deque.GetEnumerator();
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
            var deque = new Deque<string>();

            // Deque will be empty initially
            Assert.IsTrue(deque.IsEmpty);

            deque.EnqueueHead("cat");

            // Deque will be not be empty when an item is added
            Assert.IsFalse(deque.IsEmpty);

            deque.Clear();

            // Deque will be empty when items are cleared
            Assert.IsTrue(deque.IsEmpty);
        }

        #endregion

       
        #region IsReadOnly

        [Test]
        public void IsReadOnlyExample()
        {
            var deque = new Deque<string>();
            // IsReadOnly is always false for a Deque
            Assert.IsFalse(deque.IsReadOnly);
            deque.EnqueueHead("cat");
            deque.EnqueueHead("dog");
            deque.EnqueueHead("canary");
            Assert.IsFalse(deque.IsReadOnly);
        }

        #endregion
        
        #region Head

        [Test]
        public void HeadExample()
        {
            var deque = new Deque<string>();

            deque.EnqueueHead("cat");
            // Head is "cat"
            Assert.AreEqual("cat", deque.Head);

            deque.EnqueueHead("dog");
            // Head gives us "dog" because it has been put on the Head
            Assert.AreEqual("dog", deque.Head);

            deque.EnqueueTail("canary");
            // Head gives us "dog" because "canary" has been put on the Tail
            Assert.AreEqual("dog", deque.Head);
        }

        #endregion
        
        #region Tail

        [Test]
        public void TailExample()
        {
            var deque = new Deque<string>();

            deque.EnqueueHead("cat");
            // Tail is "cat"
            Assert.AreEqual("cat", deque.Tail);

            deque.EnqueueHead("dog");
            // Tail gives "cat" because it is still the Head
            Assert.AreEqual("cat", deque.Tail);

            deque.EnqueueTail("canary");
            // Tail gives us "cat" because it has been Enqueued to to the Tail
            Assert.AreEqual("canary", deque.Tail);
        }

        #endregion

     }
}