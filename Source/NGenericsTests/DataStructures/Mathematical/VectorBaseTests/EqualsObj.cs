/*  
  Copyright 2007-2010 The NGenerics Team
 (http://code.google.com/p/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/
using NGenerics.DataStructures.Mathematical;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Mathematical.VectorBaseTests
{
    [TestFixture]
    public class EqualsObj
    {

        [Test]
        public void SameValues()
        {
            var vector1 = new VectorN(3);
            vector1.SetValues(1, 2, 5);
            var vector2 = new VectorN(3);
            vector2.SetValues(1, 2, 5);

            Assert.IsTrue(vector1.Equals(vector2));

            Assert.AreEqual(1, vector1[0]);
            Assert.AreEqual(2, vector1[1]);
            Assert.AreEqual(5, vector1[2]);

            Assert.AreEqual(1, vector2[0]);
            Assert.AreEqual(2, vector2[1]);
            Assert.AreEqual(5, vector2[2]);
        }
        [Test]
        public void SameValuesObject()
        {
            var vector1 = new VectorN(3);
            vector1.SetValues(1, 2, 5);
            var vector2 = new VectorN(3);
            vector2.SetValues(1, 2, 5);

            Assert.IsTrue(vector1.Equals((object)vector2));

            Assert.AreEqual(1, vector1[0]);
            Assert.AreEqual(2, vector1[1]);
            Assert.AreEqual(5, vector1[2]);

            Assert.AreEqual(1, vector2[0]);
            Assert.AreEqual(2, vector2[1]);
            Assert.AreEqual(5, vector2[2]);
        }


        [Test]
        public void DifferentDimensions()
        {
            var vector1 = new VectorN(3);
            vector1.SetValues(1, 2, 5);
            var vector2 = new VectorN(4);
            vector2.SetValues(1, 2, 5, 6);

            Assert.IsFalse(vector1.Equals(vector2));

            Assert.AreEqual(1, vector1[0]);
            Assert.AreEqual(2, vector1[1]);
            Assert.AreEqual(5, vector1[2]);

            Assert.AreEqual(1, vector2[0]);
            Assert.AreEqual(2, vector2[1]);
            Assert.AreEqual(5, vector2[2]);
            Assert.AreEqual(6, vector2[3]);
        }


        [Test]
        public void Null()
        {
            var vector1 = new VectorN(3);
            vector1.SetValues(1, 2, 5);

            Assert.IsFalse(vector1.Equals(null));

            Assert.AreEqual(1, vector1[0]);
            Assert.AreEqual(2, vector1[1]);
            Assert.AreEqual(5, vector1[2]);

        }

        [Test]
        public void NullObject()
        {
            var vector1 = new VectorN(3);
            vector1.SetValues(1, 2, 5);

            Assert.IsFalse(vector1.Equals((object)null));

            Assert.AreEqual(1, vector1[0]);
            Assert.AreEqual(2, vector1[1]);
            Assert.AreEqual(5, vector1[2]);

        }
    }
}