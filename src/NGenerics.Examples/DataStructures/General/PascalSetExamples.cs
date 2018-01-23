/*  
  Copyright 2007-2017 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the MIT License.  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at https://opensource.org/licenses/MIT.
*/




using System;
using NGenerics.DataStructures.General;
using NGenerics.Patterns.Visitor;
using NUnit.Framework;

namespace NGenerics.Examples.DataStructures.General
{
    [TestFixture]
    public class PascalSetExamples
    {
        #region Accept
        [Test]
        public void AcceptExample()
        {
            // Create a sample PascalSet instance
            var set = new PascalSet(100);

            // Set a couple of values in the PascalSet
            for (var i = 0; i < 100; i += 10)
            {
                set.Add(i);
            }

            // Create a counting visitor that will count the number of 
            // items visited.
            var visitor = new CountingVisitor<int>();

            // Open up the door for the visitor
            set.AcceptVisitor(visitor);

            // The visitor will have visited 10 items
            Assert.AreEqual(visitor.Count, 10);
        }
        #endregion

        #region Add
        [Test]
        public void AddExample()
        {
            // Create a sample PascalSet instance
            var pascalSet = new PascalSet(100);

            // Add the 10th item to the set
            pascalSet.Add(10);

            // Add the 57th item to the set
            pascalSet.Add(57);

            // There will be two items in the set
            Assert.AreEqual(pascalSet.Count, 2);

            // And the set will contain the 10th and 57th item
            Assert.IsTrue(pascalSet.Contains(10));
            Assert.IsTrue(pascalSet.Contains(57));
        }
        #endregion


        #region Capacity
        [Test]
        public void CapacityExample()
        {
            // Create a sample PascalSet instance
            var pascalSet = new PascalSet(10, 100);

            Assert.AreEqual(pascalSet.Capacity, 91);
        }
        #endregion

        #region Clear
        [Test]
        public void ClearExample()
        {
            // Create a sample PascalSet instance
            var pascalSet = new PascalSet(100);

            // Add the 10th item to the set
            pascalSet.Add(10);

            // Add the 57th item to the set
            pascalSet.Add(57);

            // There will be two items in the set
            Assert.AreEqual(pascalSet.Count, 2);

            // Remove all items from the set
            pascalSet.Clear();

            // There will be no items left in the set
            Assert.AreEqual(pascalSet.Count, 0);
        }
        #endregion

        #region Contains
        [Test]
        public void ContainsExample()
        {
            // Create a sample PascalSet instance
            var pascalSet = new PascalSet(100);

            // Add the 10th item to the set
            pascalSet.Add(10);

            // Add the 57th item to the set
            pascalSet.Add(57);

            // There will be two items in the set
            Assert.AreEqual(pascalSet.Count, 2);

            // And the set will contain the 10th and 57th item
            Assert.IsTrue(pascalSet.Contains(10));
            Assert.IsTrue(pascalSet.Contains(57));

            // But not the item 84
            Assert.IsFalse(pascalSet.Contains(84));
        }
        #endregion

        #region Count
        [Test]
        public void CountExample()
        {
            // Create a sample PascalSet instance
            var pascalSet = new PascalSet(100);

            // Add the 10th item to the set
            pascalSet.Add(10);

            // There will be one item in the set
            Assert.AreEqual(pascalSet.Count, 1);

            // Add the 57th item to the set
            pascalSet.Add(57);

            // There will be two items in the set
            Assert.AreEqual(pascalSet.Count, 2);

            // Clear the set, thereby removing all items
            pascalSet.Clear();

            // There will be no items left in the set
            Assert.AreEqual(pascalSet.Count, 0);
        }
        #endregion

        #region CopyTo
        [Test]
        public void CopyToExample()
        {
            // Create a sample PascalSet instance
            var pascalSet = new PascalSet(100);

            // Set a couple of values in the PascalSet
            for (var i = 0; i < 100; i += 10)
            {
                pascalSet.Add(i);
            }

            // Create an array to store the items in
            var values = new int[10];

            // Copy the items in the set to the array, at index 0
            pascalSet.CopyTo(values, 0);
        }
        #endregion

        #region GetEnumerator
        [Test]
        public void GetEnumeratorExample()
        {
            var pascalSet = new PascalSet(100);

            // Set a couple of values in the PascalSet
            for (var i = 0; i < 100; i += 10)
            {
                pascalSet.Add(i);
            }

            // Enumerate over the items in the PascalSet,
            // printing them to the standard console
            using (var enumerator = pascalSet.GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    Console.WriteLine(enumerator.Current);
                }
            }
        }
        #endregion

        #region Intersection
        [Test]
        public void IntersectionExample()
        {
            // Create a sample PascalSet
			var pascalSet1 = new PascalSet(100);

            // Set a couple of values in the PascalSet
            for (var i = 0; i < 100; i += 10)
            {
				pascalSet1.Add(i);
            }

            // Create another sample PascalSet
			var pascalSet2 = new PascalSet(100) { 4, 6, 7, 10, 30 };

            // Get the intersection of the two sets
			var intersection = pascalSet1.Intersection(pascalSet2);

            // The intersection will contain values that was
            // contained in both sets.
            Assert.IsTrue(intersection[10]);
            Assert.IsTrue(intersection[30]);
            Assert.AreEqual(intersection.Count, 2);
        }
        #endregion

        #region Inverse
        [Test]
        public void InverseExample()
        {
            // Create a sample PascalSet
            var pascalSet = new PascalSet(100);

            // Set a couple of values in the PascalSet
            for (var i = 0; i < 100; i += 10)
            {
                pascalSet.Add(i);
            }

            // Get the inverse of the set
            var inverse = pascalSet.Inverse();

            // All the items that were not included in the original
            // set will be in the inverse.
            for (var i = 0; i < 100; i++)
            {
                if ((i % 10) > 0)
                {
                    Assert.IsTrue(inverse[i]);
                }
            }

            // We'll have 91 items in the set (101 - 10)
            Assert.AreEqual(inverse.Count, 91);
        }
        #endregion

        #region IsEmpty
        [Test]
        public void IsEmptyExample()
        {
            // Create a sample PascalSet
            var pascalSet = new PascalSet(100);

            // The PascalSet will initially be empty
            Assert.IsTrue(pascalSet.IsEmpty);

            // Add a couple of values in the PascalSet
            for (var i = 0; i < 100; i += 10)
            {
                pascalSet.Add(i);
            }

            // Not empty anymore...
            Assert.IsFalse(pascalSet.IsEmpty);

            // Clear the PascalSet, making it empty once more.
            pascalSet.Clear();
            Assert.IsTrue(pascalSet.IsEmpty);
        }
        #endregion

  

        #region IsFull
        [Test]
        public void IsFullExample()
        {
            // Create a sample PascalSet with a capacity of
            // 100 items (1 - 100)
            var pascalSet = new PascalSet(1, 100);

            // The set is initially empty
            Assert.IsFalse(pascalSet.IsFull);

            // The IsFull Property only returns true when every
            // possible item in the set's universe has been added
            // to the set.  We add some items to illustrate.
            for (var i = 1; i <= 100; i++)
            {
                pascalSet.Add(i);
            }

            // The set contains 100 items - thus, it's full
            Assert.AreEqual(pascalSet.Count, 100);
            Assert.IsTrue(pascalSet.IsFull);
        }
        #endregion

        #region IsProperSubsetOf
        [Test]
        public void IsProperSubsetOfExample()
        {
            // Create 3 pascal sets with various items
			var pascalSet1 = new PascalSet(0, 50, new[] { 15, 20, 30, 40, 34 });
			var pascalSet2 = new PascalSet(0, 50, new[] { 15, 20, 30 });
			var pascalSet3 = new PascalSet(0, 50, new[] { 15, 20, 30, 40, 34 });

            // s1 is not a proper subset of s2
			Assert.IsFalse(pascalSet1.IsProperSubsetOf(pascalSet2));

            // s2 is a proper subset of s1
			Assert.IsTrue(pascalSet2.IsProperSubsetOf(pascalSet1));

            // s3 is not a proper subset of s1
			Assert.IsFalse(pascalSet3.IsProperSubsetOf(pascalSet1));

            // s1 is a proper subset of s3
			Assert.IsFalse(pascalSet1.IsProperSubsetOf(pascalSet3));
        }
        #endregion

        #region IsProperSupersetOf
        [Test]
        public void IsProperSupersetOfExample()
        {
            // Create 3 pascal sets with various items
			var pascalSet1 = new PascalSet(0, 50, new[] { 15, 20, 30, 40, 34 });
			var pascalSet2 = new PascalSet(0, 50, new[] { 15, 20, 30 });
            var pascalSet3 = new PascalSet(0, 50, new[] { 15, 20, 30, 40, 34 });

            // s1 is a proper superset of s2
			Assert.IsTrue(pascalSet1.IsProperSupersetOf(pascalSet2));

            // s2 is not a proper superset of s1
			Assert.IsFalse(pascalSet2.IsProperSupersetOf(pascalSet1));

            // s3 is not a proper subset of s1
			Assert.IsFalse(pascalSet3.IsProperSupersetOf(pascalSet1));

            // s1 is also not a proper subset of s3
			Assert.IsFalse(pascalSet1.IsProperSupersetOf(pascalSet3));
        }
        #endregion

        #region IsReadOnly
        [Test]
        public void IsReadOnlyExample()
        {
            // Create a sample PascalSet
            var pascalSet = new PascalSet(100);

            // The IsReadOnly property of the PascalSet
            // always returns false.
            Assert.IsFalse(pascalSet.IsReadOnly);
        }
        #endregion

        #region IsSubsetOf
        [Test]
        public void IsSubsetOfExample()
        {
            // Create 3 pascal sets with various items
			var pascalSet1 = new PascalSet(0, 50, new[] { 15, 20, 30, 40, 34 });
			var pascalSet2 = new PascalSet(0, 50, new[] { 15, 20, 30 });
			var pascalSet3 = new PascalSet(0, 50, new[] { 15, 20, 30, 40, 34 });

            // s1 is not a subset of s2
			Assert.IsFalse(pascalSet1.IsSubsetOf(pascalSet2));

            // s2 is a subset of s1
			Assert.IsTrue(pascalSet2.IsSubsetOf(pascalSet1));

            // s3 is a subset of s1
			Assert.IsTrue(pascalSet3.IsSubsetOf(pascalSet1));

            // s1 is a subset of s3
			Assert.IsTrue(pascalSet1.IsSubsetOf(pascalSet3));
        }
        #endregion

        #region IsSupersetOf
        [Test]
        public void IsSupersetOfExample()
        {
            // Create 3 pascal sets with various items
			var pascalSet1 = new PascalSet(0, 50, new[] { 15, 20, 30, 40, 34 });
			var pascalSet2 = new PascalSet(0, 50, new[] { 15, 20, 30 });
			var pascalSet3 = new PascalSet(0, 50, new[] { 15, 20, 30, 40, 34 });

            // s1 is a superset of s2
			Assert.IsTrue(pascalSet1.IsSupersetOf(pascalSet2));

            // s2 is not a superset of s1
			Assert.IsFalse(pascalSet2.IsSupersetOf(pascalSet1));

            // s3 is a superset of s1
			Assert.IsTrue(pascalSet3.IsSupersetOf(pascalSet1));

            // s1 is a superset of s3
			Assert.IsTrue(pascalSet1.IsSupersetOf(pascalSet3));
        }
        #endregion

        #region LowerBound
        [Test]
        public void LowerBoundExample()
        {
            // Create a sample PascalSet, with a lower bound
            // of 50, and an upper bound of 100
            var pascalSet = new PascalSet(50, 100);

            // The lower bound will be 50
            Assert.AreEqual(pascalSet.LowerBound, 50);
        }
        #endregion

        #region UpperBound
        [Test]
        public void UpperBoundExample()
        {
            // Create a sample PascalSet, with a lower bound
            // of 50, and an upper bound of 100
            var pascalSet = new PascalSet(50, 100);

            // The upper bound will be 100
            Assert.AreEqual(pascalSet.UpperBound, 100);
        }
        #endregion

        #region Remove
        [Test]
        public void RemoveExample()
        {
            // Create a sample PascalSet, with a lower bound
            // of 1, and an upper bound of 100
            var pascalSet = new PascalSet(0, 100);

            // Add a couple items to the set
            for (var i = 0; i < 100; i += 10)
            {
                pascalSet.Add(i);
            }

            // There should be 10 items in the set
            Assert.AreEqual(pascalSet.Count, 10);

            // Remove 30 from the set
            var success = pascalSet.Remove(30);

            // The item would have been removed
            Assert.IsTrue(success);

            // There should be 9 items in the set now
            Assert.AreEqual(pascalSet.Count, 9);

            // Try and remove an item not in the set
            success = pascalSet.Remove(15);

            // Which, of course, wouldn't be successful
            Assert.IsFalse(success);
        }
        #endregion

        #region Subtract
        [Test]
        public void SubtractExample()
        {
            // Create 2 pascal sets with various items
			var pascalSet1 = new PascalSet(0, 50, new[] { 15, 20, 30, 40, 34 });
			var pascalSet2 = new PascalSet(0, 50, new[] { 15, 20, 30 });

            // Subtract s2 from s1, obtaining another PascalSet
			var result = pascalSet1.Subtract(pascalSet2);

            // There will only be two items in the result
            Assert.AreEqual(result.Count, 2);

            // And those items will be 40, and 34
            Assert.IsTrue(result[40]);
            Assert.IsTrue(result[34]);
        }
        #endregion

        #region Union
        [Test]
        public void UnionExample()
        {
            // Create 2 pascal sets with various items
			var pascalSet1 = new PascalSet(0, 50, new[] { 15, 20, 30, 40, 34 });
			var pascalSet2 = new PascalSet(0, 50, new[] { 3, 4, 20 });

            // Compute the union of set s1 and s2
			var union = pascalSet1.Union(pascalSet2);

            // The union will consist of the following items :
            // { 3, 4, 15, 20, 30, 50, 34 }
            Assert.AreEqual(union.Count, 7);
            Assert.IsTrue(union[3]);
            Assert.IsTrue(union[4]);
            Assert.IsTrue(union[15]);
            Assert.IsTrue(union[20]);
            Assert.IsTrue(union[30]);
            Assert.IsTrue(union[40]);
            Assert.IsTrue(union[34]);
        }
        #endregion
    }
}