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
    public class Clone
    {

        [Test]
        public void Simple()
        {
            var complexNumber = new ComplexNumber(5, 6);
            var copy = (ComplexNumber) complexNumber.Clone();

            Assert.AreEqual(copy.Real, complexNumber.Real);
            Assert.AreEqual(copy.Imaginary, complexNumber.Imaginary);

            complexNumber = new ComplexNumber(-2, 3);
            copy = (ComplexNumber) complexNumber.Clone();

            Assert.AreEqual(copy.Real, complexNumber.Real);
            Assert.AreEqual(copy.Imaginary, complexNumber.Imaginary);

            complexNumber = new ComplexNumber(5, -3);
            copy = (ComplexNumber) complexNumber.Clone();

            Assert.AreEqual(copy.Real, complexNumber.Real);
            Assert.AreEqual(copy.Imaginary, complexNumber.Imaginary);

            complexNumber = new ComplexNumber(-9, -4);
            copy = (ComplexNumber) complexNumber.Clone();

            Assert.AreEqual(copy.Real, complexNumber.Real);
            Assert.AreEqual(copy.Imaginary, complexNumber.Imaginary);
        }

    }
}