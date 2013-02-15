/*  
  Copyright 2007-2013 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/
using System;
using NGenerics.DataStructures.Mathematical;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Mathematical.VectorNTests
{
    [TestFixture]
    public class PlusOperator
    {
        [Test]
        public void Double()
        {
            var vector1 = new VectorN(2);
            vector1.SetValues(4, 7);

            IVector<double> vector = vector1 + 2;

            Assert.AreEqual(6, vector[0]);
            Assert.AreEqual(9, vector[1]);

            Assert.AreEqual(4, vector1[0]);
            Assert.AreEqual(7, vector1[1]);

            Assert.AreNotSame(vector1, vector);
        }


        [Test]
        public void Vector()
        {
            var vector1 = new VectorN(2);
            vector1.SetValues(4, 7);

            var vector2 = new VectorN(2);
            vector2.SetValues(3, 4);

            IVector<double> vector = vector1 + vector2;

            Assert.AreEqual(7, vector[0]);
            Assert.AreEqual(11, vector[1]);

            Assert.AreEqual(4, vector1[0]);
            Assert.AreEqual(7, vector1[1]);
            Assert.AreEqual(3, vector2[0]);
            Assert.AreEqual(4, vector2[1]);

            Assert.AreNotSame(vector1, vector);
            Assert.AreNotSame(vector2, vector);
        }


        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void ExceptionDifferentDimensions()
        {
            var vector1 = new VectorN(2);
            var vector2 = new VectorN(4);
            IVector<double> vector = vector1 + vector2;
        }


        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ExceptionLeftNull()
        {
            var vector1 = new VectorN(2);
            IVector<double> vector = null + vector1;
        }


        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ExceptionRightNull()
        {
            var vector1 = new VectorN(2);
            IVector<double> vector = vector1 + null;
        }
    }
}