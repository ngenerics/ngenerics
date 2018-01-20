/*  
  Copyright 2007-2017 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the MIT License.  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at https://opensource.org/licenses/MIT.
*/


using System;
using System.Diagnostics;
using NGenerics.DataStructures.General;
using NGenerics.Patterns.Visitor;
using NUnit.Framework;

namespace ExampleLibraryCSharp.DataStructures.General
{
    [TestFixture]
    public class SortedListExamples
    {
        #region Accept

        [Test]
        public void AcceptVisitorExample()
        {
            var sortedList = new SortedList<string> {"cat", "dog", "canary"};

            // There should be 3 items in the sortedList.
            Assert.AreEqual(3, sortedList.Count);

            // Create a visitor that will simply count the items in the sortedList.
            var visitor =new CountingVisitor<string>();

            // Make sortedList tree call IVisitor<T>.Visit on all items contained.
            sortedList.AcceptVisitor(visitor);

            // The counting visitor would have visited 3 items.
            Assert.AreEqual(3, visitor.Count);
        }

        #endregion


        #region Add

        [Test]
        public void AddExample()
        {
            var sortedList = new SortedList<string>();
            sortedList.Add("cat");
            sortedList.Add("dog");
            sortedList.Add("canary");

            // There should be 3 items in the sortedList.
            Assert.AreEqual(3, sortedList.Count);
        }

        #endregion


        #region Clear

        [Test]
        public void ClearExample()
        {
            var sortedList = new SortedList<string> {"cat", "dog", "canary"};

            // There should be 3 items in the sortedList.
            Assert.AreEqual(3, sortedList.Count);

            // Clear the tree
            sortedList.Clear();

            // The sortedList should be empty.
            Assert.AreEqual(0, sortedList.Count);

            // No cat here..
            Assert.IsFalse(sortedList.Contains("cat"));
        }

        #endregion


        #region Constructor

        [Test]
        public void ConstructorExample()
        {
            var sortedList = new SortedList<string> {"cat", "dog", "canary"};
        }

        #endregion


        #region ConstructorCapacity

        [Test]
        public void ConstructorCapacityExample()
        {
            // If you know how many items will initially be in the list it is 
            // more efficient to set the initial capacity
            var sortedList = new SortedList<string>(3) {"cat", "dog", "canary"};
        }

        #endregion


        #region ConstructorCollection

        [Test]
        public void ConstructorCollectionExample()
        {
            var array = new[] {"cat", "dog", "canary"};

            var sortedList = new SortedList<string>(array);

            // sortedList contains all the elements of the array
            Assert.IsTrue(sortedList.Contains("cat"));
            Assert.IsTrue(sortedList.Contains("canary"));
            Assert.IsTrue(sortedList.Contains("dog"));
        }

        #endregion


        #region ConstructorComparer

        [Test]
        public void ConstructorComparerExample()
        {
        	var sortedListIgnoreCase = new SortedList<string>(StringComparer.OrdinalIgnoreCase)
        	                           	{
        	                           		"cat",
        	                           		"dog",
        	                           		"CAT"
        	                           	};
        	//"CAT" will be at the start because case is ignored
        	Assert.AreEqual(0, sortedListIgnoreCase.IndexOf("CAT"));


        	var sortedListUseCase = new SortedList<string>
        	                        	{
        	                        		"cat",
        	                        		"dog",
        	                        		"CAT"
        	                        	};
        	//"CAT" will in the second position because case is not ignored
        	Assert.AreEqual(1, sortedListUseCase.IndexOf("CAT"));
        }

    	#endregion


        #region Contains

        [Test]
        public void ContainsExample()
        {
            var sortedList = new SortedList<string> {"cat", "dog", "canary"};

            // sortedList does contain cat, dog and canary
            Assert.IsTrue(sortedList.Contains("cat"));
            Assert.IsTrue(sortedList.Contains("dog"));
            Assert.IsTrue(sortedList.Contains("canary"));
            // but not frog
            Assert.IsFalse(sortedList.Contains("frog"));
        }

        #endregion


        #region CopyTo

        [Test]
        public void CopyToExample()
        {
            var sortedList = new SortedList<string> {"cat", "dog", "canary"};

            // create new string array with the same length
            var stringArray = new string[sortedList.Count];
            sortedList.CopyTo(stringArray, 0);

            // stringArray contains cat, dog and canary (note canary is in the 0 position)
            Assert.AreEqual("canary", stringArray[0]);
            Assert.AreEqual("cat", stringArray[1]);
            Assert.AreEqual("dog", stringArray[2]);
        }

        #endregion


        #region Count

        [Test]
        public void CountExample()
        {
            var sortedList = new SortedList<string> {"cat", "dog", "canary"};

            // Count is 3
            Assert.AreEqual(3, sortedList.Count);
        }

        #endregion


        #region GetEnumerator

        [Test]
        public void GetEnumeratorExample()
        {
            var sortedList = new SortedList<string> {"cat", "dog", "canary"};

            // Get the enumerator and iterate through it.
            var enumerator = sortedList.GetEnumerator();
            while (enumerator.MoveNext())
            {
                Debug.WriteLine(enumerator.Current);
            }
        }

        #endregion


        #region IndexOf

        [Test]
        public void IndexOfExample()
        {
            var sortedList = new SortedList<string> {"canary", "cat", "dog"};

            // "dog" is in position 2
            Assert.AreEqual(2, sortedList.IndexOf("dog"));
        }

        #endregion


        #region IsEmpty

        [Test]
        public void IsEmptyExample()
        {
            var sortedList = new SortedList<string>();

            // SortedList will be empty initially
            Assert.IsTrue(sortedList.IsEmpty);

            sortedList.Add("cat");

            // SortedList will be not be empty when an item is added
            Assert.IsFalse(sortedList.IsEmpty);

            sortedList.Clear();

            // SortedList will be empty when items are cleared
            Assert.IsTrue(sortedList.IsEmpty);
        }

        #endregion


        #region IsReadOnly

        [Test]
        public void IsReadOnlyExample()
        {
            var sortedList = new SortedList<string>();
            // IsReadOnly is always false for a SortedList
            Assert.IsFalse(sortedList.IsReadOnly);
            sortedList.Add("cat");
            sortedList.Add("dog");
            sortedList.Add("canary");
            Assert.IsFalse(sortedList.IsReadOnly);
        }

        #endregion


        #region Remove

        [Test]
        public void RemoveExample()
        {
            var sortedList = new SortedList<string> {"cat", "dog", "canary"};

            // SortedList Contains "dog"
            Assert.IsTrue(sortedList.Contains("dog"));
            
            // Remove "dog"
            sortedList.Remove("dog");
            
            // SortedList does not contains "dog"
            Assert.IsFalse(sortedList.Contains("dog"));
        }

        #endregion


        #region RemoveAt

        [Test]
        public void RemoveAtExample()
        {
            var sortedList = new SortedList<string> {"canary", "cat", "dog"};

            // SortedList Contains "dog"
            Assert.IsTrue(sortedList.Contains("dog"));

            // "dog" is in position 2
            Assert.AreEqual(2, sortedList.IndexOf("dog"));

            // Remove "dog"
            sortedList.RemoveAt(2);

            // SortedList does not contains "dog"
            Assert.IsFalse(sortedList.Contains("dog"));
        }

        #endregion
    }
}