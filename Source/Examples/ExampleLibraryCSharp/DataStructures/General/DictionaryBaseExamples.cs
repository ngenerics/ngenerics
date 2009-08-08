/*  
  Copyright 2007-2009 The NGenerics Team
 (http://code.google.com/p/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/


using System;
using System.Collections.Generic;
using NGenerics.DataStructures.General;
using NUnit.Framework;

namespace ExampleLibraryCSharp.DataStructures.General
{
    [TestFixture]
    public class DictionaryBaseExamples
    {

        public class MyDictionary<TKey, TValue> : DictionaryBase<string, int>
            {
                
            }

        #region Add
        [Test]
        public void AddExample()
        {
            var dictionary = new MyDictionary<string, int>();
            dictionary.Add("cat", 1);
            dictionary.Add("dog", 2);
            dictionary.Add("canary", 3);

            // There should be 3 items in the dictionary.
            Assert.AreEqual(3, dictionary.Count);
        }
        #endregion


        #region Clear
        [Test]
        public void ClearExample()
        {
            DictionaryBase<string, int> dictionary = new MyDictionary<string, int>
                                                         {
                                                             {"cat", 1},
                                                             {"dog", 2},
                                                             {"canary", 3}
                                                         };

            // There should be 3 items in the dictionary.
            Assert.AreEqual(3, dictionary.Count);

            // Clear the dictionary
            dictionary.Clear();

            // The dictionary should be empty.
            Assert.AreEqual(0, dictionary.Count);

            // No cat here..
            Assert.IsFalse(dictionary.ContainsKey("cat"));
        }
        #endregion


        #region Comparer
        [Test]
        public void ComparerExample()
        {
            DictionaryBase<string, int> dictionary = new MyDictionary<string, int>();

            // If no comparer is specified, the default comparer is used.
            Assert.AreSame(dictionary.Comparer, EqualityComparer<string>.Default);
        }
        #endregion


        #region ContainsKey
        [Test]
        public void ContainsKeyExample()
        {
            DictionaryBase<string, int> dictionary = new MyDictionary<string, int>
                                                         {
                                                             {"cat", 1},
                                                             {"dog", 2},
                                                             {"canary", 3}
                                                         };

            // The dictionary should contain a cat and a dog...
            Assert.IsTrue(dictionary.ContainsKey("cat"));
            Assert.IsTrue(dictionary.ContainsKey("dog"));

            // But definitely not an ostrich.
            Assert.IsFalse(dictionary.ContainsKey("ostrich"));
        }
        #endregion


        #region Count
        [Test]
        public void CountExample()
        {
            DictionaryBase<string, int> dictionary = new MyDictionary<string, int>();

            // dictionary count is 0.
            Assert.AreEqual(0, dictionary.Count);

            // Add a cat.
            dictionary.Add("cat", 1);

            // Tree count is 1.
            Assert.AreEqual(1, dictionary.Count);

            // Add a dog
            dictionary.Add("dog", 2);

            // Tree count is 2.
            Assert.AreEqual(2, dictionary.Count);

            // Clear the dictionary - thereby removing all items contained.
            dictionary.Clear();

            // Tree is empty again with 0 count.
            Assert.AreEqual(0, dictionary.Count);
        }
        #endregion


        #region GetEnumerator
        public void GetEnumeratorExample()
        {
            DictionaryBase<string, int> dictionary = new MyDictionary<string, int>
                                                         {
                                                             {"cat", 1},
                                                             {"dog", 2},
                                                             {"canary", 3}
                                                         };

            IEnumerator<KeyValuePair<string, int>> enumerator = dictionary.GetEnumerator();

            // Enumerate through the items in the dictionary, and write the contents
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
        public void ItemExample()
        {
            DictionaryBase<string, int> dictionary = new MyDictionary<string, int>
                                                         {
                                                             {"cat", 1},
                                                             {"dog", 2},
                                                             {"canary", 3}
                                                         };

            Assert.AreEqual(1, dictionary["cat"]);
            Assert.AreEqual(2, dictionary["dog"]);
            Assert.AreEqual(3, dictionary["canary"]);
        }
        #endregion


        #region Keys
        [Test]
        public void KeysExample()
        {
            DictionaryBase<string, int> dictionary = new MyDictionary<string, int>
                                                         {
                                                             {"cat", 1},
                                                             {"dog", 2},
                                                             {"canary", 3}
                                                         };

            // Retrieve the keys from the dictionary.
            var keys = dictionary.Keys;

            // The keys collection contains three items : 
            // "cat", "dog", and "canary".
            Assert.AreEqual(3, keys.Count);

            Assert.IsTrue(keys.Contains("cat"));
            Assert.IsTrue(keys.Contains("dog"));
            Assert.IsTrue(keys.Contains("canary"));
        }
        #endregion


        #region Remove
        [Test]
        public void RemoveExample()
        {
            DictionaryBase<string, int> dictionary = new MyDictionary<string, int>
                                                         {
                                                             {"cat", 1},
                                                             {"dog", 2},
                                                             {"canary", 3}
                                                         };

            // There are three items in the dictionary
            Assert.AreEqual(3, dictionary.Count);

            // Let's remove the dog
            dictionary.Remove("dog");

            // Now the dictionary contains only two items, and dog isn't 
            // in the dictionary.
            Assert.AreEqual(2, dictionary.Count);
            Assert.IsFalse(dictionary.ContainsKey("dog"));
        }

        #endregion


        #region TryGetValue
        [Test]
        public void TryGetValueExample()
        {
            DictionaryBase<string, int> dictionary = new MyDictionary<string, int>
                                                         {
                                                             {"cat", 1},
                                                             {"dog", 2},
                                                             {"canary", 3}
                                                         };

            int value;

            // We'll get the value for cat successfully.
            Assert.IsTrue(dictionary.TryGetValue("cat", out value));

            // And the value should be 1.
            Assert.AreEqual(1, value);

            // But we won't get a horse
            Assert.IsFalse(dictionary.TryGetValue("horse", out value));
        }
        #endregion


        #region Values
        [Test]
        public void ValuesExample()
        {
            DictionaryBase<string, int> dictionary = new MyDictionary<string, int>
                                                         {
                                                             {"cat", 1},
                                                             {"dog", 2},
                                                             {"canary", 3}
                                                         };

            // Retrieve the values from the dictionary.
            var values = dictionary.Values;

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