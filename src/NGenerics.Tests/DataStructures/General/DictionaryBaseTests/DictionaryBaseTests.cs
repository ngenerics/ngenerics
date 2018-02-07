/*  
  Copyright 2007-2017 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the MIT License.  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at https://opensource.org/licenses/MIT.
*/


using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.General.DictionaryBaseTests
{
    [TestFixture]
    public class DictionaryBaseICollectionTest
    {


        [Test]
        public void CopyToTest()
        {
            var target = new MockStringDictionary { { "a", "b" }, { "g", "s" }, { "h", "x" } };
            ICollection collection = target;
            var pairs = new KeyValuePair<string, string>[3];
            collection.CopyTo(pairs, 0);
            Assert.AreEqual("a", pairs[0].Key);
            Assert.AreEqual("g", pairs[1].Key);
            Assert.AreEqual("h", pairs[2].Key);
            Assert.AreEqual("b", pairs[0].Value);
            Assert.AreEqual("s", pairs[1].Value);
            Assert.AreEqual("x", pairs[2].Value);
        }


        [Test]
        public void GetEnumeratorTest()
        {
            var target = new MockStringDictionary { { "a", "b" }, { "s", "r" }, { "f", "t" } };
            ICollection collection = target;
            var enumerator = collection.GetEnumerator();

            enumerator.MoveNext();
            var current = (KeyValuePair<string, string>)enumerator.Current;
            Assert.AreEqual("a", current.Key);
            Assert.AreEqual("b", current.Value);


            enumerator.MoveNext();
            current = (KeyValuePair<string, string>)enumerator.Current;
            Assert.AreEqual("s", current.Key);
            Assert.AreEqual("r", current.Value);

            enumerator.MoveNext();
            current = (KeyValuePair<string, string>)enumerator.Current;
            Assert.AreEqual("f", current.Key);
            Assert.AreEqual("t", current.Value);

        }


        [Test]
        public void IsSynchronizedTest()
        {
            var target = new MockStringDictionary();
            ICollection collection = target;
            Assert.IsFalse(collection.IsSynchronized);
        }


        [Test]
        public void IsSyncRootTest()
        {
            var target = new MockStringDictionary();
            ICollection collection = target;
            Assert.IsNotNull(collection.SyncRoot);

        }
    }
}