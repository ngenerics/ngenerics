/*  
  Copyright 2007-2017 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the MIT License.  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at https://opensource.org/licenses/MIT.
*/


using System;
using System.Collections.Generic;
using System.Diagnostics;
using NGenerics.DataStructures.General;
using NGenerics.Patterns.Visitor;
using NUnit.Framework;

namespace NGenerics.Examples.DataStructures.General
{
    [TestFixture]
    public class SkipListExamples
    {
        #region Accept
        [Test]
        public void AcceptVisitorExample()
        {
            var skipList = new SkipList<string, int> {{"cat", 1}, {"dog", 2}, {"canary", 3}};

            // There should be 3 items in the SkipList.
            Assert.AreEqual(3, skipList.Count);

            // Create a visitor that will simply count the items in the skipList.
            var visitor =new CountingVisitor<KeyValuePair<string, int>>();

            // Make the skipList call IVisitor<T>.Visit on all items contained.
            skipList.AcceptVisitor(visitor);

            // The counting visitor would have visited 3 items.
            Assert.AreEqual(3, visitor.Count);
        }
        #endregion

        #region Add
        [Test]
        public void AddExample()
        {
            var skipList = new SkipList<string, int>();
            skipList.Add("cat", 1);
            skipList.Add("dog", 2);
            skipList.Add("canary", 3);

            // There will be 3 items in the skipList.
            Assert.AreEqual(3, skipList.Count);
        }
        #endregion

        #region AddKeyValuePair
        [Test]
        public void AddKeyValuePairExample()
        {
            var skipList = new SkipList<string, int>();
            skipList.Add(new KeyValuePair<string, int>("cat", 1));
            skipList.Add(new KeyValuePair<string, int>("dog", 2));
            skipList.Add(new KeyValuePair<string, int>("canary", 3));

            // There should be 3 items in the SkipList.
            Assert.AreEqual(3, skipList.Count);

            // The skipList should contain all three keys
            Assert.IsTrue(skipList.ContainsKey("cat"));
            Assert.IsTrue(skipList.ContainsKey("dog"));
            Assert.IsTrue(skipList.ContainsKey("canary"));

            // The value of the item with key "dog" must be 2.
            Assert.AreEqual(2, skipList["dog"]);
        }
        #endregion

        #region Clear
        [Test]
        public void ClearExample()
        {
            var skipList = new SkipList<string, int> {{"cat", 1}, {"dog", 2}, {"canary", 3}};

            // There should be 3 items in the SkipList.
            Assert.AreEqual(3, skipList.Count);

            // Clear the skipList
            skipList.Clear();

            // The skipList should be empty.
            Assert.AreEqual(0, skipList.Count);

            // No cat here..
            Assert.IsFalse(skipList.ContainsKey("cat"));
        }
        #endregion

        #region Comparer
        [Test]
        public void ComparerExample()
        {
            var skipList = new SkipList<string, int>();

            // If no comparer is specified, the default comparer is used.
            Assert.AreSame(skipList.Comparer, Comparer<string>.Default);
        }
        #endregion

        #region ContainsKeyValue
        [Test]
        public void ContainsKeyValueExample()
        {
            var skipList = new SkipList<string, int> {{"cat", 1}, {"dog", 2}, {"canary", 3}};

            // The skipList should contain 1 cat and 2 dogs...
            Assert.IsTrue(skipList.Contains(new KeyValuePair<string, int>("cat", 1)));
            Assert.IsTrue(skipList.Contains(new KeyValuePair<string, int>("dog", 2)));

            // But not 3 cats and 1 dog
            Assert.IsFalse(skipList.Contains(new KeyValuePair<string, int>("cat", 3)));
            Assert.IsFalse(skipList.Contains(new KeyValuePair<string, int>("dog", 1)));
        }
        #endregion

        #region ContainsKey
        [Test]
        public void ContainsKeyExample()
        {
            var skipList = new SkipList<string, int> {{"cat", 1}, {"dog", 2}, {"canary", 3}};

            // The skipList should contain a cat and a dog...
            Assert.IsTrue(skipList.ContainsKey("cat"));
            Assert.IsTrue(skipList.ContainsKey("dog"));

            // But definitely not an ostrich.
            Assert.IsFalse(skipList.ContainsKey("ostrich"));
        }
        #endregion
        
        #region Constructor

        [Test]
        public void ConstructorExample()
        {

            var skipList = new SkipList<string, int> {{"cat", 1}, {"dog", 2}, {"canary", 3}};
        }

        #endregion
       
        #region ConstructorComparer

        [Test]
        public void ConstructorComparerExample()
        {
        	var ignoreCaseSkipList = new SkipList<string, int>(StringComparer.OrdinalIgnoreCase)
        	                         	{
        	                         		{"cat", 1},
        	                         		{"dog", 2},
        	                         		{"canary", 3}
        	                         	};
        	// "CAT" will be in the SkipList because case is ignored
        	Assert.IsTrue(ignoreCaseSkipList.ContainsKey("CAT"));


        	var useCaseSkipList = new SkipList<string, int>(StringComparer.Ordinal)
        	                      	{
        	                      		{"cat", 1},
        	                      		{"dog", 2},
        	                      		{"canary", 3}
        	                      	};
        	// "CAT" will not be in the SkipList because case is not ignored
        	Assert.IsFalse(useCaseSkipList.ContainsKey("CAT"));
        }

    	#endregion

        #region CopyTo
        [Test]
        public void CopyToExample()
        {
            var skipList = new SkipList<string, int> {{"cat", 1}, {"dog", 2}, {"canary", 3}};

            // Create a new array of length 3 to copy the elements into.
            var values = new KeyValuePair<string, int>[3];
            skipList.CopyTo(values, 0);
        }
        #endregion

        #region Count
        [Test]
        public void CountExample()
        {
            var skipList = new SkipList<string, int>();

            // SkipList count is 0.
            Assert.AreEqual(0, skipList.Count);

            // Add a cat.
            skipList.Add("cat", 1);

            // SkipList count is 1.
            Assert.AreEqual(1, skipList.Count);

            // Add a dog
            skipList.Add("dog", 2);

            // SkipList count is 2.
            Assert.AreEqual(2, skipList.Count);

            // Clear the skipList - thereby removing all items contained.
            skipList.Clear();

            // SkipList is empty again with 0 count.
            Assert.AreEqual(0, skipList.Count);
        }
        #endregion

        #region CurrentListLevel

        [Test]
        public void CurrentListLevelExample()
        {
            var skipList = new SkipList<int, string>();

            // CurrentListLevel will initial be 0
            Assert.AreEqual(0, skipList.CurrentListLevel);

            for (var i = 0; i < 100; i++)
            {
                skipList.Add(new KeyValuePair<int, string>(i, i.ToString()));
            }

            Assert.Greater(skipList.CurrentListLevel, 0);
        }
        #endregion

        #region GetEnumerator
        public void GetEnumeratorExample()
        {
            var skipList = new SkipList<string, int> {{"cat", 1}, {"dog", 2}, {"canary", 3}};

            var enumerator = skipList.GetEnumerator();

            // Enumerate through the items in the SkipList, and write the contents
            // to the standard output.
            while (enumerator.MoveNext())
            {
                Console.Write("Key : ");
                Console.WriteLine(enumerator.Current.Key);
                Console.Write("Value : ");
                Console.WriteLine(enumerator.Current.Value);
            }
        }
        #endregion

        #region Item
        [Test]
        public void ItemExample()
        {
            var skipList = new SkipList<string, int> {{"cat", 1}, {"dog", 2}, {"canary", 3}};

            Assert.AreEqual(1, skipList["cat"]);
            Assert.AreEqual(2, skipList["dog"]);
            Assert.AreEqual(3, skipList["canary"]);
        }
        #endregion

        #region IsEmpty
        [Test]
        public void IsEmptyExample()
        {
            var skipList = new SkipList<string, int>();

            // SkipList is empty.
            Assert.IsTrue(skipList.IsEmpty);

            // Add a cat.
            skipList.Add("cat", 1);

            // SkipList is not empty.
            Assert.IsFalse(skipList.IsEmpty);

            // Clear the SkipList - thereby removing all items contained.
            skipList.Clear();

            // SkipList is empty again with count = 0.
            Assert.IsTrue(skipList.IsEmpty);
        }
        #endregion

 


        #region IsReadOnly
        [Test]
        public void IsReadOnlyExample()
        {
            // The IsReadOnly property will always return false - the 
            // search skipList is not a read-only data structure.
            var skipList = new SkipList<string, int>();

            Assert.IsFalse(skipList.IsReadOnly);
        }
        #endregion

        #region Keys
        [Test]
        public void KeysExample()
        {
            var skipList = new SkipList<string, int> {{"cat", 1}, {"dog", 2}, {"canary", 3}};

            // Retrieve the keys from the SkipList.
            var keys = skipList.Keys;

            // The keys collection contains three items : 
            // "cat", "dog", and "canary".
            Assert.AreEqual(3, keys.Count);

            Assert.IsTrue(keys.Contains("cat"));
            Assert.IsTrue(keys.Contains("dog"));
            Assert.IsTrue(keys.Contains("canary"));
        }
        #endregion

        #region Probability
        [Test]
        public void ProbabilityExample()
        {
        	var skipList = new SkipList<string, int>(14, 0.7, StringComparer.OrdinalIgnoreCase)
        	               	{
        	               		{"cat", 1},
        	               		{"dog", 2},
        	               		{"canary", 3}
        	               	};

        	Assert.AreEqual(3, skipList.Count);
        	Assert.AreEqual(0.7, skipList.Probability);
        	Assert.AreEqual(14, skipList.MaximumListLevel);
        }

    	#endregion

        #region MaximumListLevel
        [Test]
        public void MaximumListLevelExample()
        {
        	var skipList = new SkipList<string, int>(14, 0.7, StringComparer.OrdinalIgnoreCase)
        	               	{
        	               		{"cat", 1},
        	               		{"dog", 2},
        	               		{"canary", 3}
        	               	};

        	Assert.AreEqual(3, skipList.Count);
        	Assert.AreEqual(.7, skipList.Probability);
        	Assert.AreEqual(14, skipList.MaximumListLevel);
        }

    	#endregion

        #region Remove
        [Test]
        public void RemoveExample()
        {
            var skipList = new SkipList<string, int> {{"cat", 1}, {"dog", 2}, {"canary", 3}};

            // There are three items in the SkipList
            Assert.AreEqual(3, skipList.Count);

            // Let's remove the dog
            var success = skipList.Remove("dog");

            // The dog should be removed
            Assert.IsTrue(success);

            // Now the SkipList contains only two items, and dog isn't 
            // in the SkipList.
            Assert.AreEqual(2, skipList.Count);

            if (skipList.ContainsKey("dog"))
            {
                Debugger.Break();
            }

            Assert.IsFalse(skipList.ContainsKey("dog"));
        }

        #endregion

        #region TryGetValue
        [Test]
        public void TryGetValueExample()
        {
            var skipList = new SkipList<string, int> {{"cat", 1}, {"dog", 2}, {"canary", 3}};

            int value;

            // We'll get the value for cat successfully.
            Assert.IsTrue(skipList.TryGetValue("cat", out value));

            // And the value should be 1.
            Assert.AreEqual(1, value);

            // But we won't get a horse
            Assert.IsFalse(skipList.TryGetValue("horse", out value));
        }
        #endregion

        #region Values
        [Test]
        public void ValuesExample()
        {
            // Build a simple SkipList.
            var skipList = new SkipList<string, int> {{"cat", 1}, {"dog", 2}, {"canary", 3}};

            // Retrieve the values from the SkipList.
            var values = skipList.Values;

            // The keys collection contains three items : 
            // 1, 2, and 3.
            Assert.AreEqual(3, values.Count);

            Assert.IsTrue(values.Contains(1));
            Assert.IsTrue(values.Contains(2));
            Assert.IsTrue(values.Contains(3));
        }
        #endregion
    }
}
