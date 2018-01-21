/*  
  Copyright 2007-2017 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the MIT License.  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at https://opensource.org/licenses/MIT.
*/

using System;
using NGenerics.DataStructures.Mathematical;
using NGenerics.Patterns.Visitor;
using NGenerics.Tests.DataStructures.Mathematical.VectorBaseTestObjects;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Mathematical.VectorBaseTest
{

    [TestFixture]
    public class Accept
    {

        [Test]
        public void Simple()
        {
            var visitor = new CountingVisitor<double>();
            var vector = new VectorN(2);
            vector.AcceptVisitor(visitor);
            Assert.AreEqual(2, visitor.Count);
        }

        [Test]
        public void Completed()
        {
            var visitor = new ComparableFindingVisitor<double>(5);
            var vector = new VectorN(3);
            vector.SetValues(2, 5, 9);
            vector.AcceptVisitor(visitor);
            Assert.IsTrue(visitor.Found);
        }

        [Test]
        public void ExceptionNullVisitor()
        {
            var vector = new VectorBaseTestObject(2);
            Assert.Throws<ArgumentNullException>(() => vector.AcceptVisitor(null));
        }

    }

    [TestFixture]
    public class Add
    {
        [Test]
        public void Exception1()
        {
            var vector1 = new VectorBaseTestObject(2);
            var vector2 = new VectorBaseTestObject(2);
            Assert.Throws<NotImplementedException>(() => vector1.Add(vector2), "AddSafe");
        }


        [Test]
        public void ExceptionDifferentDimensions()
        {
            var vector1 = new VectorBaseTestObject(2);
            var vector2 = new VectorBaseTestObject(4);
            Assert.Throws<ArgumentException>(() => vector1.Add(vector2));
        }

        [Test]
        public void ExceptionNullVector()
        {
            Assert.Throws<ArgumentNullException>(() => new VectorBaseTestObject(2) { null });
        }
    }

    [TestFixture]
    public class Clear
    {
        [Test]
        public void Simple()
        {
            var vector = new VectorN(3);
            vector.SetValues(3, 7, 8);

            vector.Clear();

            Assert.AreEqual(0, vector[0]);
            Assert.AreEqual(0, vector[1]);
            Assert.AreEqual(0, vector[0]);
        }
    }

    [TestFixture]
    public class Contruction
    {

        [Test]
        public void Simple()
        {
            var vector = new VectorBaseTestObject(2);
            Assert.AreEqual(2, vector.DimensionCount);
        }

    }

    [TestFixture]
    public class CrossProduct
    {

        [Test]
        public void Exception3x3()
        {
            var vector1 = new VectorBaseTestObject(3);
            var vector2 = new VectorBaseTestObject(3);
            Assert.Throws<NotImplementedException>(() => vector1.CrossProduct(vector2), "CrossProductSafe");
        }

        [Test]
        public void Exception2x3()
        {
            var vector1 = new VectorBaseTestObject(2);
            var vector2 = new VectorBaseTestObject(3);
            Assert.Throws<NotImplementedException>(() => vector1.CrossProduct(vector2), "CrossProductSafe");
        }

        [Test]
        public void Exception3x2()
        {
            var vector1 = new VectorBaseTestObject(3);
            var vector2 = new VectorBaseTestObject(2);
            Assert.Throws<NotImplementedException>(() => vector1.CrossProduct(vector2));
        }

        [Test]
        public void Exception2x2()
        {
            var vector1 = new VectorBaseTestObject(2);
            var vector2 = new VectorBaseTestObject(2);
            Assert.Throws<NotImplementedException>(() => vector1.CrossProduct(vector2));
        }

        [Test]
        public void Exception1x2()
        {
            var vector1 = new VectorBaseTestObject(1);
            var vector2 = new VectorBaseTestObject(2);
            Assert.Throws<InvalidOperationException>(() => vector1.CrossProduct(vector2));
        }

        [Test]
        public void Exception4x2()
        {
            var vector1 = new VectorBaseTestObject(4);
            var vector2 = new VectorBaseTestObject(2);
            Assert.Throws<InvalidOperationException>(() => vector1.CrossProduct(vector2));
        }

        [Test]
        public void Exception2x1()
        {
            var vector1 = new VectorBaseTestObject(2);
            var vector2 = new VectorBaseTestObject(1);
            Assert.Throws<ArgumentException>(() => vector1.CrossProduct(vector2));
        }

        [Test]
        public void ExceptionDifferentDimensions1()
        {
            var vector1 = new VectorBaseTestObject(2);
            var vector2 = new VectorBaseTestObject(4);
            Assert.Throws<ArgumentException>(() => vector1.CrossProduct(vector2));
        }

        [Test]
        public void ExceptionNullVector()
        {
            var vector1 = new VectorBaseTestObject(2);
            Assert.Throws<ArgumentNullException>(() => vector1.CrossProduct(null));
        }

    }

    [TestFixture]
    public class DimensionCount
    {
        [Test]
        public void Simple()
        {
            var vector = new VectorBaseTestObject(2);
            Assert.AreEqual(2, vector.DimensionCount);
        }

    }

    [TestFixture]
    public class Divide
    {
        [Test]
        public void Exception()
        {
            var vector1 = new VectorBaseTestObject(2);
            var vector2 = new VectorBaseTestObject(2);
            Assert.Throws<NotImplementedException>(() => vector1.Divide(vector2));
        }

        [Test]
        public void ExceptionNullVector()
        {
            var vector1 = new VectorBaseTestObject(2);
            Assert.Throws<ArgumentNullException>(() => vector1.Divide(null));
        }


        [Test]
        public void ExceptionDifferentDimensions()
        {
            var vector1 = new VectorBaseTestObject(2);
            var vector2 = new VectorBaseTestObject(3);
            Assert.Throws<ArgumentException>(() => vector1.Divide(vector2));
        }

    }

    [TestFixture]
    public class DotProduct
    {

        [Test]
        public void Exception1()
        {
            var vector1 = new VectorBaseTestObject(2);
            var vector2 = new VectorBaseTestObject(2);
            Assert.Throws<NotImplementedException>(() => vector1.DotProduct(vector2));
        }


        [Test]
        public void ExceptionNullVector()
        {
            var vector1 = new VectorBaseTestObject(2);
            Assert.Throws<ArgumentNullException>(() => vector1.DotProduct(null));
        }


        [Test]
        public void EceptionDifferentDimensions()
        {
            var vector1 = new VectorBaseTestObject(2);
            var vector2 = new VectorBaseTestObject(3);
            Assert.Throws<ArgumentException>(() => vector1.DotProduct(vector2));
        }

    }

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

    [TestFixture]
    public class Maximum
    {
        [Test]
        public void Simple()
        {
            var vector = new VectorN(3);
            vector.SetValues(1, -4, 3);

            Assert.AreEqual(3, vector.Maximum());
            Assert.AreEqual(1, vector[0]);
            Assert.AreEqual(-4, vector[1]);
            Assert.AreEqual(3, vector[2]);
        }
    }

    [TestFixture]
    public class Minimum
    {

        [Test]
        public void Simple()
        {
            var vector = new VectorN(3);
            vector.SetValues(1, -4, 3);

            Assert.AreEqual(-4, vector.Minimum());
            Assert.AreEqual(1, vector[0]);
            Assert.AreEqual(-4, vector[1]);
            Assert.AreEqual(3, vector[2]);
        }

    }

    [TestFixture]
    public class Multiply
    {
        [Test]
        public void Exception()
        {
            var vector1 = new VectorBaseTestObject(2);
            var vector2 = new VectorBaseTestObject(2);
            Assert.Throws<NotImplementedException>(() => vector1.Multiply(vector2));
        }

        [Test]
        public void ExceptionNullVector()
        {
            var vector1 = new VectorBaseTestObject(2);
            Assert.Throws<ArgumentNullException>(() => vector1.Multiply(null));
        }

        [Test]
        public void ExceptionDifferentDimensions()
        {
            var vector1 = new VectorBaseTestObject(2);
            var vector2 = new VectorBaseTestObject(3);
            Assert.Throws<ArgumentException>(() => vector1.Multiply(vector2));
        }

    }

    [TestFixture]
    public class Subtract
    {
        [Test]
        public void Exception()
        {
            var vector1 = new VectorBaseTestObject(2);
            var vector2 = new VectorBaseTestObject(2);
            Assert.Throws<NotImplementedException>(() => vector1.Subtract(vector2));
        }

        [Test]
        public void ExceptionVectorNull()
        {
            var vector1 = new VectorBaseTestObject(2);
            Assert.Throws<ArgumentNullException>(() => vector1.Subtract(null));
        }


        [Test]
        public void ExceptionDifferentDimensions()
        {
            var vector1 = new VectorBaseTestObject(2);
            var vector2 = new VectorBaseTestObject(3);
            Assert.Throws<ArgumentException>(() => vector1.Subtract(vector2));
        }

    }

    [TestFixture]
    public class Swap
    {

        [Test]
        public void Simple()
        {
            var vector1 = new VectorN(2);
            vector1[0] = 1;
            vector1[1] = 2;

            var vector2 = new VectorN(2);
            vector2[0] = 3;
            vector2[1] = 4;

            vector1.Swap((IVector<double>)vector2);

            Assert.AreEqual(3, vector1[0]);
            Assert.AreEqual(4, vector1[1]);
            Assert.AreEqual(1, vector2[0]);
            Assert.AreEqual(2, vector2[1]);
        }

        [Test]
        public void ExcpetionNullOther()
        {
            var vector1 = new VectorBaseTestObject(2);
            Assert.Throws<ArgumentNullException>(() => vector1.Swap(null));
        }


        [Test]
        public void ExceptionDifferentDimensions()
        {
            var vector1 = new VectorBaseTestObject(2);
            var vector2 = new VectorBaseTestObject(3);
            Assert.Throws<ArgumentException>(() => vector1.Swap(vector2));
        }
    }
}
