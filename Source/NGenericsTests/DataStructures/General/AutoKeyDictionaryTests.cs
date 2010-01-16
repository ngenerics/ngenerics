/*  
  Copyright 2007-2010 The NGenerics Team
 (http://code.google.com/p/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using System;
using System.Collections;
using System.Collections.Generic;
using NGenerics.DataStructures.General;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.General
{
    [TestFixture]
    public class AutoKeyDictionaryTests
    {

        [TestFixture]
        public class Construction
        {
            [Test]
            public void Simple()
            {
                new AutoKeyDictionary<string, int>(x => x.ToString());
            }

            [Test]
            public void Comparer()
            {
                new AutoKeyDictionary<string, int>(x => x.ToString(),StringComparer.InvariantCultureIgnoreCase);
            }

            [Test]
            public void CapacityComparer()
            {
                var target = new AutoKeyDictionary<string, int>(x => x.ToString(),StringComparer.InvariantCultureIgnoreCase, 1);
                Assert.AreEqual(StringComparer.InvariantCultureIgnoreCase, target.Comparer);
            }
        }

        [TestFixture]
        public class Keys
        {
            [Test]
            public void Simple()
            {
                var target = new AutoKeyDictionary<string, int>(x => x.ToString()) { 2, 4, 9 };
                var keys = target.Keys;

                IEnumerable<string> enumerable = keys;
                var enumerator = enumerable.GetEnumerator();

                enumerator.MoveNext();
                var current = enumerator.Current;
                Assert.AreEqual("2", current);

                enumerator.MoveNext();
                current = enumerator.Current;
                Assert.AreEqual("4", current);

                enumerator.MoveNext();
                current = enumerator.Current;
                Assert.AreEqual("9", current);

            }
        }

        [TestFixture]
        public class Values
        {
            [Test]
            public void Simple()
            {
                var target = new AutoKeyDictionary<string, int>(x => x.ToString()) { 2, 4, 9 };
                var valueCollection = target.Values;

                IEnumerable<int> enumerable = valueCollection;
                var enumerator = enumerable.GetEnumerator();

                enumerator.MoveNext();
                var current = enumerator.Current;
                Assert.AreEqual(2, current);

                enumerator.MoveNext();
                current = enumerator.Current;
                Assert.AreEqual(4, current);

                enumerator.MoveNext();
                current = enumerator.Current;
                Assert.AreEqual(9, current);

            }
        }

        [TestFixture]
        public class ContainsKey
        {
            [Test]
            public void Simple()
            {
                var target = new AutoKeyDictionary<string, int>(x => x.ToString()) { 2 };
                Assert.IsTrue(target.ContainsKey("2"));
                Assert.IsFalse(target.ContainsKey("1"));
                Assert.IsFalse(target.ContainsKey("3"));
            }
        }
        [TestFixture]
        public class RemoveKey
        {
            [Test]
            public void Simple()
            {
                var target = new AutoKeyDictionary<string, int>(x => x.ToString()) { 2 };
                Assert.IsTrue(target.ContainsKey("2"));
                Assert.IsTrue(target.RemoveKey("2"));
                Assert.IsFalse(target.ContainsKey("2"));
            }
        }

        [TestFixture]
        public class InternalRemove
        {
            [Test]
            public void Simple()
            {
                var target = new AutoKeyDictionary<string, int>(x => x.ToString()) { 2 };
                Assert.IsTrue(target.ContainsKey("2"));
                Assert.IsTrue(target.InternalRemove("2"));
                Assert.IsFalse(target.ContainsKey("2"));
            }

            [Test]
            [ExpectedException(typeof(ArgumentNullException))]
            public void ExceptionNullKey()
            {
                var target = new AutoKeyDictionary<string, int>(x => x.ToString());
                target.InternalRemove(null);
            }
        }

        [TestFixture]
        public class Add
        {
            [Test]
            public void Interface()
            {
                var target = new AutoKeyDictionary<string, int>(x => x.ToString());
                ICollection<int> collection = target;
                collection.Add(1);
                Assert.IsTrue(target.Contains(1));
            }
        }

        [TestFixture]
        public class Clear
        {
            [Test]
            public void Simple()
            {
                var target = new AutoKeyDictionary<string, int>(x => x.ToString()) { 2 };
                Assert.IsTrue(target.Contains(2));
                target.Clear();
                Assert.IsFalse(target.Contains(2));
            }
        }

        [TestFixture]
        public class Remove
        {
            [Test]
            public void Simple()
            {
                var target = new AutoKeyDictionary<string, int>(x => x.ToString()) { 3 };
                ICollection<int> collection = target;
                Assert.IsTrue(collection.Remove(3));
                Assert.IsFalse(target.ContainsKey("3"));
                Assert.IsFalse(collection.Remove(3));
            }

            [Test]
            public void NonExisting()
            {
                var target = new AutoKeyDictionary<string, int>(x => x.ToString()) { 1 };
                ICollection<int> collection = target;
                Assert.IsFalse(collection.Remove(2));
            }
        }


        [TestFixture]
        public class GetEnumerator
        {
            [Test]
            public void Simple()
            {
                var target = new AutoKeyDictionary<string, int>(x => x.ToString()) { 2, 4, 9 };
                IEnumerable<int> enumerable = target;
                var enumerator = enumerable.GetEnumerator();

                enumerator.MoveNext();
                var current = enumerator.Current;
                Assert.AreEqual(2, current);

                enumerator.MoveNext();
                current = enumerator.Current;
                Assert.AreEqual(4, current);

                enumerator.MoveNext();
                current = enumerator.Current;
                Assert.AreEqual(9, current);
            }

            [Test]
            public void Interface()
            {
                var target = new AutoKeyDictionary<string, int>(x => x.ToString()) { 2, 4, 9 };
                IEnumerable enumerable = target;
                var enumerator = enumerable.GetEnumerator();

                enumerator.MoveNext();
                var current = (int)enumerator.Current;
                Assert.AreEqual(2, current);

                enumerator.MoveNext();
                current = (int)enumerator.Current;
                Assert.AreEqual(4, current);

                enumerator.MoveNext();
                current = (int)enumerator.Current;
                Assert.AreEqual(9, current);
            }
        }


        [TestFixture]
        public class Contains
        {
            [Test]
            public void ContainsTest()
            {
                var target = new AutoKeyDictionary<string, int>(x => x.ToString()) { 2 };
                ICollection<int> collection = target;
                Assert.IsTrue(collection.Contains(2));
                Assert.IsFalse(collection.Contains(1));
                Assert.IsFalse(collection.Contains(3));
            }
        }

        [TestFixture]
        public class Serialization
        {
            [Test]
            public void DataContractSerializer()
            {
                var target = new AutoKeyDictionary<string, int>(x => x.ToString()) { 2 };
                ICollection<int> collection = target;
                Assert.IsTrue(collection.Contains(2));
                Assert.IsFalse(collection.Contains(1));
                Assert.IsFalse(collection.Contains(3));
            }
        }

        [TestFixture]
        public class CopyTo
        {
            [Test]
            public void Simple()
            {
                var target = new AutoKeyDictionary<string, int>(x => x.ToString())
                             { 1, 2, 3 };
                ICollection<int> collection = target;
                var pairs = new int[3];
                collection.CopyTo(pairs, 0);
                Assert.AreEqual(1, pairs[0]);
                Assert.AreEqual(2, pairs[1]);
                Assert.AreEqual(3, pairs[2]);
            }
        }
    }
}
