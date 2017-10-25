/*  
  Copyright 2007-2017 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the MIT License.  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at https://opensource.org/licenses/MIT.
*/

using NGenerics.Tests.Util;
using NUnit.Framework;
using NGenerics.DataStructures.General;

namespace NGenerics.Tests.DataStructures.General.HashListTests
{
    [TestFixture]
        public class Serializable
        {
            [Test]
			public void Simple()
            {
                var hashList = new HashList<int, string>
                                              {
                                                  {2, "a"},
                                                  {2, "b"},
                                                  {3, "b"},
                                                  {3, "c"},
                                                  {3, "d"},
                                                  {4, "c"}
                                              };

                var newHash = SerializeUtil.BinarySerializeDeserialize(hashList);

                Assert.AreNotSame(hashList, newHash);
                Assert.AreEqual(hashList.Count, newHash.Count);

                var hashListEnumerator = hashList.GetEnumerator();
                var newHashEnumerator = newHash.GetEnumerator();

                while (hashListEnumerator.MoveNext())
                {
                    Assert.IsTrue(newHashEnumerator.MoveNext());

                    Assert.AreEqual(hashListEnumerator.Current.Key, newHashEnumerator.Current.Key);

                    var l1 = hashListEnumerator.Current.Value;
                    var l2 = newHashEnumerator.Current.Value;

                    Assert.AreNotSame(l1, l2);
                    Assert.AreEqual(l1.Count, l2.Count);

                    for (var i = 0; i < l1.Count; i++)
                    {
                        Assert.AreEqual(l1[i], l2[i]);
                    }
                }

                Assert.IsFalse(newHashEnumerator.MoveNext());
            }
        }
}
