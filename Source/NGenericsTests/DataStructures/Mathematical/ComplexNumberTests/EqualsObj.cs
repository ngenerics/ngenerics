/*  
  Copyright 2007-2010 The NGenerics Team
 (http://code.google.com/p/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/
using NGenerics.DataStructures.Mathematical;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Mathematical.ComplexNumberTests
{
    [TestFixture]
    public class EqualsObj
    {

        [Test]
        public void Simple2()
        {
            var complexNumber1 = new ComplexNumber(1, 2);
            var complexNumber2 = new ComplexNumber(1, 2);
            var complexNumber3 = new ComplexNumber(1, 6);
            var complexNumber4 = new ComplexNumber(2, 2);
            var complexNumber5 = new ComplexNumber(3, 3);

            Assert.IsTrue(complexNumber1.Equals(complexNumber1));
            Assert.IsTrue(complexNumber1.Equals(complexNumber2));
            Assert.IsFalse(complexNumber1.Equals(complexNumber3));
            Assert.IsFalse(complexNumber1.Equals(complexNumber4));
            Assert.IsFalse(complexNumber1.Equals(complexNumber5));

            // Disable warning C1718 : Testing equality of same variable
#pragma warning disable 1718

            Assert.IsTrue(complexNumber1 == complexNumber1);

#pragma warning restore 1718

            Assert.IsTrue(complexNumber1 == complexNumber2);
            Assert.IsFalse(complexNumber1 == complexNumber3);
            Assert.IsFalse(complexNumber1 == complexNumber4);
            Assert.IsFalse(complexNumber1 == complexNumber5);

#pragma warning disable 1718

            Assert.IsFalse(complexNumber1 != complexNumber1);

#pragma warning restore 1718

            Assert.IsFalse(complexNumber1 != complexNumber2);
            Assert.IsTrue(complexNumber1 != complexNumber3);
            Assert.IsTrue(complexNumber1 != complexNumber4);
            Assert.IsTrue(complexNumber1 != complexNumber5);
        }

        [Test]
        public void Simple1()
        {
            object complexNumber1 = new ComplexNumber(1, 2);
            object complexNumber2 = new ComplexNumber(1, 2);
            object complexNumber3 = new ComplexNumber(1, 6);
            object complexNumber4 = new ComplexNumber(2, 2);
            object complexNumber5 = new ComplexNumber(3, 3);

            Assert.IsTrue(complexNumber1.Equals(complexNumber1));
            Assert.IsTrue(complexNumber1.Equals(complexNumber2));
            Assert.IsFalse(complexNumber1.Equals(complexNumber3));
            Assert.IsFalse(complexNumber1.Equals(complexNumber4));
            Assert.IsFalse(complexNumber1.Equals(complexNumber5));
        }

        [Test]
        public void Simple3()
        {
            object complexNumber1 = new ComplexNumber(1, 2);
            var complexNumber2 = new object();

            Assert.IsFalse(complexNumber1.Equals(complexNumber2));
            Assert.IsFalse(complexNumber1.Equals(null));
        }

    }
}