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
    public class BagExamples
    {
        #region Accept

        [Test]
        public void AcceptVisitorExample()
        {
            // Create a Bag
            var bag = new Bag<string>
                      	{
                      		"cat",
                      		"dog",
                      		"canary"
                      	};

        	// There should be 3 items in the bag.
            Assert.AreEqual(3, bag.Count);

            // Create a visitor that will simply count the items in the bag.
            var visitor = new CountingVisitor<string>();

            // Make bag call IVisitor<T>.Visit on all items contained.
            bag.AcceptVisitor<string>(visitor);

            // The counting visitor would have visited 3 items.
            Assert.AreEqual(3, visitor.Count);
        }

        #endregion

        #region Add

        [Test]
        public void AddExample()
        {
            var bag = new Bag<string>();
            bag.Add("cat");
            bag.Add("dog");
            bag.Add("canary");

            // There should be 3 items in the bag.
            Assert.AreEqual(3, bag.Count);
        }

        #endregion

        #region AddAmount

        [Test]
        public void AddAmountExample()
        {
            var bag = new Bag<string>();
            bag.Add("cat");
            bag.Add("dog", 2);
            bag.Add("canary");

            // There are 4 items in the bag.
            Assert.AreEqual(4, bag.Count);

            // There are 2 "dog"s in the bag.
            Assert.AreEqual(2, bag["dog"]);
        }

        #endregion

        #region Clear

        [Test]
        public void ClearExample()
        {
            var bag = new Bag<string> {"cat", "dog", "canary"};

            // There should be 3 items in the bag.
            Assert.AreEqual(3, bag.Count);

            // Clear the bag
            bag.Clear();

            // The bag should be empty.
            Assert.AreEqual(0, bag.Count);

            // No cat here..
            Assert.IsFalse(bag.Contains("cat"));
        }

        #endregion

        #region Constructor

        [Test]
        public void ConstructorExample()
        {
            var bag = new Bag<string> {"cat", "dog", "canary"};
        }

        #endregion

        #region ConstructorCapacity

        [Test]
        public void ConstructorCapacityExample()
        {
            // If you know how many items will initially be in the list it is 
            // more efficient to set the initial capacity
            var bag = new Bag<string>(3) {"cat", "dog", "canary"};
        }

        #endregion

        #region ConstructorComparer

        [Test]
        public void ConstructorComparerExample()
        {
            var bagIgnoreCase = new Bag<string>(StringComparer.OrdinalIgnoreCase) {"cat", "dog", "CAT"};
            // "CAT" will have a count of 2 because case is ignored
            Assert.AreEqual(2, bagIgnoreCase["CAT"]);


            var bagUseCase = new Bag<string> {"cat", "dog", "CAT"};
            // "CAT" will have a count of 1 because case is not ignored
            Assert.AreEqual(1, bagUseCase["CAT"]);
        }

        #endregion

        #region Contains

        [Test]
        public void ContainsExample()
        {
            var bag = new Bag<string> {"cat", "dog", "canary"};

            // bag does contain cat, dog and canary
            Assert.IsTrue(bag.Contains("cat"));
            Assert.IsTrue(bag.Contains("dog"));
            Assert.IsTrue(bag.Contains("canary"));
            // but not frog
            Assert.IsFalse(bag.Contains("frog"));
        }

        #endregion

        #region CopyTo

        [Test]
        public void CopyToExample()
        {
            var bag = new Bag<string> {"cat", "dog", "canary", "canary"};

            // Create new string array - the count is 4 because "canary" will exists twice.
            var stringArray = new string[4];
            bag.CopyTo(stringArray, 0);
        }

        #endregion

        #region Count

        [Test]
        public void CountExample()
        {
            var bag = new Bag<string> {"cat", "dog", "canary", "canary"};

            // Count is 4
            Assert.AreEqual(4, bag.Count);
        }

        #endregion

        #region Equals

        [Test]
        public void EqualsExample()
        {
            var bag1 = new Bag<string> {"cat", "dog", "canary"};

            var bag2 = new Bag<string> {"cat", "dog", "canary"};


            // bag1 is "Equal" to bag2
            Assert.IsTrue(bag1.Equals(bag2));
        }

        #endregion

        #region GetEnumerator

        [Test]
        public void GetEnumeratorExample()
        {
            var bag = new Bag<string> {"cat", "dog", "dog", "canary"};

            // Get the enumerator and iterate through it.
            var enumerator = bag.GetEnumerator();
            while (enumerator.MoveNext())
            {
                Debug.WriteLine(enumerator.Current);
            }
        }

        #endregion

        #region Intersection

        [Test]
        public void IntersectionExample()
        {
            var bag1 = new Bag<string> {"cat", "dog", "dog", "canary"};


            var bag2 = new Bag<string> {"cat", "cat", "dog", "dog", "canary"};

            var intersectionBag = bag1.Intersection(bag2);

            // Bag contains 2 "dog"s, 1 "cat"s and 1 "canary".
            Assert.AreEqual(2, intersectionBag["dog"]);
            Assert.AreEqual(1, intersectionBag["cat"]);
            Assert.AreEqual(1, intersectionBag["canary"]);
        }

        #endregion

        #region IsEmpty

        [Test]
        public void IsEmptyExample()
        {
            var bag = new Bag<string>();

            // Bag will be empty initially
            Assert.IsTrue(bag.IsEmpty);

            bag.Add("cat");

            // Bag will be not be empty when an item is added
            Assert.IsFalse(bag.IsEmpty);

            bag.Clear();

            // Bag will be empty when items are cleared
            Assert.IsTrue(bag.IsEmpty);
        }

        #endregion



        #region IsReadOnly

        [Test]
        public void IsReadOnlyExample()
        {
            var bag = new Bag<string>();
            // IsReadOnly is always false for a Bag
            Assert.IsFalse(bag.IsReadOnly);
            bag.Add("cat");
            bag.Add("dog");
            bag.Add("canary");
            Assert.IsFalse(bag.IsReadOnly);
        }

        #endregion

        #region Item

        [Test]
        public void ItemExample()
        {
            var bag = new Bag<string> {"cat", "dog", "dog", "canary"};

            // bag contains 1 "cat", 2 "dog"s and 1 "canary.
            Assert.AreEqual(1, bag["cat"]);
            Assert.AreEqual(2, bag["dog"]);
            Assert.AreEqual(1, bag["canary"]);
        }

        #endregion

        #region OperatorAdd

        [Test]
        public void OperatorAddExample()
        {
            var bag1 = new Bag<string> {"cat", "dog", "dog", "canary"};


            var bag2 = new Bag<string> {"cat", "cat", "dog", "dog", "canary"};

            var unionBag = bag1 + bag2;
            // Bag contains 4 "dog"s, 3 "cat"s and 2 "canary"s.
            Assert.AreEqual(4, unionBag["dog"]);
            Assert.AreEqual(3, unionBag["cat"]);
            Assert.AreEqual(2, unionBag["canary"]);
        }

        #endregion

        #region OperatorMultiply

        [Test]
        public void OperatorMultiplyExample()
        {
            var bag1 = new Bag<string> {"cat", "dog", "dog", "canary"};


            var bag2 = new Bag<string> {"cat", "cat", "dog", "dog", "canary"};

            var multipliedBag = bag1*bag2;
            // Bag contains 2 "dog"s, 1 "cat"s and 1 "canary".
            Assert.AreEqual(2, multipliedBag["dog"]);
            Assert.AreEqual(1, multipliedBag["cat"]);
            Assert.AreEqual(1, multipliedBag["canary"]);
        }

        #endregion

        #region OperatorSubtract

        [Test]
        public void OperatorSubtractExample()
        {
            var bag1 = new Bag<string> {"cat", "dog", "dog", "canary"};


            var bag2 = new Bag<string> {"cat", "dog"};

            var subtractBag = bag1 - bag2;

            // Bag contains 1 "dog", 0 "cat"s and 1 "canary".
            Assert.AreEqual(1, subtractBag["dog"]);
            Assert.AreEqual(0, subtractBag["cat"]);
            Assert.AreEqual(1, subtractBag["canary"]);
        }

        #endregion

        #region Remove

        [Test]
        public void RemoveExample()
        {
            var bag = new Bag<string> {"cat", "dog", "dog", "canary"};

            // Bag contains 2 "dog"s
            Assert.AreEqual(2, bag["dog"]);

            // Remove a "dog"
            bag.Remove("dog");

            // Bag contains 1 "dog"
            Assert.AreEqual(1, bag["dog"]);

            // Remove a "dog"
            bag.Remove("dog");

            // Bag contains 0 "dog"s
            Assert.AreEqual(0, bag["dog"]);
        }

        #endregion

        #region RemoveAll

        [Test]
        public void RemoveAllExample()
        {
            var bag = new Bag<string> {"cat", "dog", "dog", "canary"};

            // Bag contains 2 "dog"s
            Assert.AreEqual(2, bag["dog"]);

            // Remove "dog"
            bag.RemoveAll("dog");

            // Bag contains 0 "dog"
            Assert.AreEqual(0, bag["dog"]);
        }

        #endregion

        #region RemoveMaximum

        [Test]
        public void RemoveMaximumExample()
        {
            var bag = new Bag<string> {"cat", "dog", "dog", "dog", "canary"};

            // Bag contains 3 "dog"s
            Assert.AreEqual(3, bag["dog"]);

            // Remove 2 "dog"s
            bag.Remove("dog", 2);

            // Bag contains 1 "dog"
            Assert.AreEqual(1, bag["dog"]);
        }

        #endregion

        #region Subtract

        [Test]
        public void SubtractExample()
        {
            var bag1 = new Bag<string> {"cat", "dog", "dog", "canary"};


            var bag2 = new Bag<string> {"cat", "dog"};

            var subtractBag = bag1.Subtract(bag2);

            // Bag contains 1 "dog", 0 "cat"s and 1 "canary".
            Assert.AreEqual(1, subtractBag["dog"]);
            Assert.AreEqual(0, subtractBag["cat"]);
            Assert.AreEqual(1, subtractBag["canary"]);
        }

        #endregion

        #region Union

        [Test]
        public void UnionExample()
        {
            var bag1 = new Bag<string> {"cat", "dog", "dog", "canary"};


            var bag2 = new Bag<string> {"cat", "cat", "dog", "dog", "canary"};

            var unionBag = bag1.Union(bag2);

            // Bag contains 4 "dog"s, 3 "cat"s and 2 "canary"s.
            Assert.AreEqual(4, unionBag["dog"]);
            Assert.AreEqual(3, unionBag["cat"]);
            Assert.AreEqual(2, unionBag["canary"]);
        }

        #endregion
    }
}