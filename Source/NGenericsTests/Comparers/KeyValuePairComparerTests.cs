/*  
  Copyright 2007-2010 The NGenerics Team
 (http://code.google.com/p/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/


using System.Collections.Generic;
using NGenerics.Comparers;
using NUnit.Framework;

namespace NGenerics.Tests.Comparers {
    [TestFixture]
    public class KeyValuePairComparerTest {

        [TestFixture]
        public class Construction {
            [Test]
            public void Simple() {
                new KeyValuePairComparer<int, string>();
            }
        }

        [TestFixture]
        public class Compare {
            
            [Test]
            public void DefaultComparer() {
                var associationKeyComparer = new KeyValuePairComparer<int, string>();

                var pair1 = new KeyValuePair<int, string>(5, "5");
                var pair2 = new KeyValuePair<int, string>(5, "6");
                var pair3 = new KeyValuePair<int, string>(3, "5");
                var pair4 = new KeyValuePair<int, string>(5, "5");

                Assert.AreEqual(associationKeyComparer.Compare(pair1, pair2), 0);
                Assert.AreEqual(associationKeyComparer.Compare(pair1, pair3), 1);
                Assert.AreEqual(associationKeyComparer.Compare(pair1, pair4), 0);

                Assert.AreEqual(associationKeyComparer.Compare(pair2, pair1), 0);
                Assert.AreEqual(associationKeyComparer.Compare(pair3, pair1), -1);
                Assert.AreEqual(associationKeyComparer.Compare(pair4, pair1), 0);
            }

            [Test]
            public void CustomComparer()
            {
                var associationKeyComparer = new KeyValuePairComparer<int, string>(Comparer<int>.Default);

                var pair1 = new KeyValuePair<int, string>(5, "5");
                var pair2 = new KeyValuePair<int, string>(5, "6");
                var pair3 = new KeyValuePair<int, string>(3, "5");
                var pair4 = new KeyValuePair<int, string>(5, "5");

                Assert.AreEqual(associationKeyComparer.Compare(pair1, pair2), 0);
                Assert.AreEqual(associationKeyComparer.Compare(pair1, pair3), 1);
                Assert.AreEqual(associationKeyComparer.Compare(pair1, pair4), 0);

                Assert.AreEqual(associationKeyComparer.Compare(pair2, pair1), 0);
                Assert.AreEqual(associationKeyComparer.Compare(pair3, pair1), -1);
                Assert.AreEqual(associationKeyComparer.Compare(pair4, pair1), 0);
            }

            [Test]
            public void CustomComparison() {
                var associationKeyComparer = new KeyValuePairComparer<int, string>((x, y) => x.CompareTo(y) * -1);

                var pair1 = new KeyValuePair<int, string>(5, "5");
                var pair2 = new KeyValuePair<int, string>(5, "6");
                var pair3 = new KeyValuePair<int, string>(3, "5");
                var pair4 = new KeyValuePair<int, string>(5, "5");

                Assert.AreEqual(associationKeyComparer.Compare(pair1, pair2), 0);
                Assert.AreEqual(associationKeyComparer.Compare(pair1, pair3), -1);
                Assert.AreEqual(associationKeyComparer.Compare(pair1, pair4), 0);

                Assert.AreEqual(associationKeyComparer.Compare(pair2, pair1), 0);
                Assert.AreEqual(associationKeyComparer.Compare(pair3, pair1), +1);
                Assert.AreEqual(associationKeyComparer.Compare(pair4, pair1), 0);

                Assert.AreEqual(associationKeyComparer.Compare(pair2.Key, pair1.Key), 0);
                Assert.AreEqual(associationKeyComparer.Compare(pair3.Key, pair1.Key), +1);
                Assert.AreEqual(associationKeyComparer.Compare(pair4.Key, pair1.Key), 0);
            }
        }
    }
}
