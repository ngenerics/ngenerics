/*  
  Copyright 2007-2017 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the MIT License.  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at https://opensource.org/licenses/MIT.
*/

using System.Collections.Generic;
using NGenerics.DataStructures.General;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.General.HashListTests
{
    [TestFixture]
    public class Remove
    {
        [Test]
        public void Simple()
        {
            var hashList = new HashList<int, string> {{2, "a"}};

            Assert.AreEqual(hashList.ValueCount, 1);
            Assert.AreEqual(hashList.KeyCount, 1);

            hashList.Add(4, new List<string>(new[] { "2", "3", "4", "5" }));

            Assert.AreEqual(hashList.ValueCount, 5);
            Assert.AreEqual(hashList.KeyCount, 2);

            Assert.IsTrue(hashList.Remove(2));
            Assert.AreEqual(hashList.KeyCount, 1);
            Assert.AreEqual(hashList.ValueCount, 4);

            Assert.IsFalse(hashList.Remove(2));
            Assert.AreEqual(hashList.KeyCount, 1);
            Assert.AreEqual(hashList.ValueCount, 4);

            Assert.IsTrue(hashList.RemoveValue("2"));

            Assert.AreEqual(hashList.KeyCount, 1);
            Assert.AreEqual(hashList.ValueCount, 3);

            Assert.IsFalse(hashList.Remove(3, "2"));

            Assert.AreEqual(hashList.KeyCount, 1);
            Assert.AreEqual(hashList.ValueCount, 3);

            Assert.IsFalse(hashList.Remove(4, "2"));

            Assert.AreEqual(hashList.KeyCount, 1);
            Assert.AreEqual(hashList.ValueCount, 3);

            Assert.IsTrue(hashList.Remove(4, "5"));

            Assert.AreEqual(hashList.KeyCount, 1);
            Assert.AreEqual(hashList.ValueCount, 2);

            hashList.Add(4, "4");

            Assert.AreEqual(hashList.KeyCount, 1);
            Assert.AreEqual(hashList.ValueCount, 3);

            hashList.RemoveAll("4");

            Assert.AreEqual(hashList.KeyCount, 1);
            Assert.AreEqual(hashList.ValueCount, 1);

            Assert.IsFalse(hashList.Remove(10));

            hashList.Add(4, "5");
            hashList.Add(4, "6");

            Assert.AreEqual(hashList.KeyCount, 1);
            Assert.AreEqual(hashList.ValueCount, 3);


            Assert.IsTrue(hashList.RemoveValue("5"));

            Assert.AreEqual(hashList.KeyCount, 1);
            Assert.AreEqual(hashList.ValueCount, 2);

            Assert.IsFalse(hashList.RemoveValue("5"));

            Assert.AreEqual(hashList.KeyCount, 1);
            Assert.AreEqual(hashList.ValueCount, 2);
        }
    }
}