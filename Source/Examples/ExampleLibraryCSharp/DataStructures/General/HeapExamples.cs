/*  
  Copyright 2007-2010 The NGenerics Team
 (http://code.google.com/p/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/


using System;
using System.Diagnostics;
using NGenerics.DataStructures.General;
using NGenerics.Patterns.Visitor;
using NUnit.Framework;

namespace ExampleLibraryCSharp.DataStructures.General
{
    [TestFixture]
    public class HeapExamples
    {
        #region Accept

        [Test]
        public void AcceptVisitorExample()
        {
            var heap = new Heap<string>(HeapType.Minimum) {"cat", "dog", "canary"};

            // There should be 3 items in the heap.
            Assert.AreEqual(3, heap.Count);

            // Create a visitor that will simply count the items in the heap.
            var visitor = new CountingVisitor<string>();

            // Make heap call IVisitor<T>.Visit on all items contained.
            heap.AcceptVisitor(visitor);

            // The counting visitor would have visited 3 items.
            Assert.AreEqual(3, visitor.Count);
        }

        #endregion


        #region Add

        [Test]
        public void AddExample()
        {
            var heap = new Heap<string>(HeapType.Minimum);
            heap.Add("cat");
            heap.Add("dog");
            heap.Add("canary");

            // There should be 3 items in the heap.
            Assert.AreEqual(3, heap.Count);
        }

        #endregion


        #region Clear

        [Test]
        public void ClearExample()
        {
            var heap = new Heap<string>(HeapType.Minimum) {"cat", "dog", "canary"};

            // There should be 3 items in the heap.
            Assert.AreEqual(3, heap.Count);

            // Clear the heap
            heap.Clear();

            // The heap should be empty.
            Assert.AreEqual(0, heap.Count);

            // No cat here..
            Assert.IsFalse(heap.Contains("cat"));
        }

        #endregion


        #region Constructor

        [Test]
        public void ConstructorExample()
        {
            var heap = new Heap<string>(HeapType.Minimum) {"cat", "dog", "canary"};
        }

        #endregion


        #region ConstructorCapacity

        [Test]
        public void ConstructorCapacityExample()
        {
            // If you know how many items will initially be in the list it is 
            // more efficient to set the initial capacity
            var heap = new Heap<string>(HeapType.Minimum, 3) {"cat", "dog", "canary"};
        }

        #endregion


        #region ConstructorComparer

        [Test]
        public void ConstructorComparerExample()
        {
        	var heapIgnoreCase = new Heap<string>(HeapType.Minimum, StringComparer.OrdinalIgnoreCase)
        	                     	{
        	                     		"frog",
        	                     		"cat",
        	                     		"CAT",
        	                     		"dog"
        	                     	};
        	// "cat" will be the root because case is ignored
        	Assert.AreEqual("cat", heapIgnoreCase.Root);


        	var heapUseCase = new Heap<string>(HeapType.Minimum, StringComparer.Ordinal)
        	                  	{
        	                  		"frog",
        	                  		"cat",
        	                  		"CAT",
        	                  		"dog"
        	                  	};
        	// "CAT" will be the root because case is not ignored
        	Assert.AreEqual("CAT", heapUseCase.Root);
        }

    	#endregion


        #region Contains

        [Test]
        public void ContainsExample()
        {
            var heap = new Heap<string>(HeapType.Minimum) {"cat", "dog", "canary"};

            // heap does contain cat, dog and canary
            Assert.IsTrue(heap.Contains("cat"));
            Assert.IsTrue(heap.Contains("dog"));
            Assert.IsTrue(heap.Contains("canary"));
            // but not frog
            Assert.IsFalse(heap.Contains("frog"));
        }

        #endregion


        #region CopyTo

        [Test]
        public void CopyToExample()
        {
            var heap = new Heap<string>(HeapType.Minimum) {"cat", "dog", "canary", "canary"};

            // Create new string array - the count is 4 because "canary" will exists twice.
            var stringArray = new string[4];
            heap.CopyTo(stringArray, 0);
        }

        #endregion


        #region Count

        [Test]
        public void CountExample()
        {
            var heap = new Heap<string>(HeapType.Minimum) {"cat", "dog", "canary", "canary"};

            // Count is 4
            Assert.AreEqual(4, heap.Count);
        }

        #endregion

        #region GetEnumerator

        [Test]
        public void GetEnumeratorExample()
        {
            var heap = new Heap<string>(HeapType.Minimum) {"cat", "dog", "dog", "canary"};

            // Get the enumerator and iterate through it.
            var enumerator = heap.GetEnumerator();
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
            var heap = new Heap<string>(HeapType.Minimum);

            // Heap will be empty initially
            Assert.IsTrue(heap.IsEmpty);

            heap.Add("cat");

            // Heap will be not be empty when an item is added
            Assert.IsFalse(heap.IsEmpty);

            heap.Clear();

            // Heap will be empty when items are cleared
            Assert.IsTrue(heap.IsEmpty);
        }

        #endregion

        #region IsReadOnly

        [Test]
        public void IsReadOnlyExample()
        {
            var heap = new Heap<string>(HeapType.Minimum);
            // IsReadOnly is always false for a Heap
            Assert.IsFalse(heap.IsReadOnly);
            heap.Add("cat");
            heap.Add("dog");
            heap.Add("canary");
            Assert.IsFalse(heap.IsReadOnly);
        }

        #endregion

        #region RemoveRoot

        [Test]
        public void RemoveRootExample()
        {
            var heap = new Heap<string>(HeapType.Minimum) {"cat", "dog", "canary"};

            //because a heap is sorted the order will be "canary", "cat" and "dog"

            // Root is "canary"
            Assert.AreEqual("canary", heap.Root);

            // Remove Root
            heap.RemoveRoot();

            // Root is "cat"
            Assert.AreEqual("cat", heap.Root);

            // Remove Root
            heap.RemoveRoot();

            // Root is "dog"
            Assert.AreEqual("dog", heap.Root);

            // Remove Root
            heap.RemoveRoot();

            Assert.IsTrue(heap.IsEmpty);
        }

        #endregion

        #region Root

        [Test]
        public void RootExample()
        {
            var heap = new Heap<string>(HeapType.Minimum) {"cat", "dog", "canary"};

            //because a heap is sorted the order will be "canary", "cat" and "dog"

            // Root is "canary"
            Assert.AreEqual("canary", heap.Root);

            // Remove Root
            heap.RemoveRoot();

            // Root is "cat"
            Assert.AreEqual("cat", heap.Root);

            // Remove Root
            heap.RemoveRoot();

            // Root is "dog"
            Assert.AreEqual("dog", heap.Root);

            // Remove Root
            heap.RemoveRoot();

            Assert.IsTrue(heap.IsEmpty);
        }

        #endregion

        #region Type

        [Test]
        public void TypeExample()
        {
            var heap = new Heap<string>(HeapType.Minimum) {"cat", "dog", "canary"};

            Assert.AreEqual(HeapType.Minimum, heap.Type);
        }

        #endregion
     }
}