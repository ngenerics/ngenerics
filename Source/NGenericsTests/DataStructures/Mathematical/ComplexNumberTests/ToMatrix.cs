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
    public class ToMatrix
    {

        [Test]
        public void Simple()
        {
            var complexNumber = new ComplexNumber(3, 4);

            /* For (a, b) :
                * [ a, -b ]
                * [ b, a ]
                */

            var matrix = complexNumber.ToMatrix();

            Assert.AreEqual(matrix[0, 0], complexNumber.Real);
            Assert.AreEqual(matrix[0, 1], -1 * complexNumber.Imaginary);
            Assert.AreEqual(matrix[1, 0], complexNumber.Imaginary);
            Assert.AreEqual(matrix[1, 1], complexNumber.Real);

            complexNumber = new ComplexNumber(-2, 6);

            matrix = complexNumber.ToMatrix();

            Assert.AreEqual(matrix[0, 0], complexNumber.Real);
            Assert.AreEqual(matrix[0, 1], -1 * complexNumber.Imaginary);
            Assert.AreEqual(matrix[1, 0], complexNumber.Imaginary);
            Assert.AreEqual(matrix[1, 1], complexNumber.Real);

            complexNumber = new ComplexNumber(5, -1);

            matrix = complexNumber.ToMatrix();

            Assert.AreEqual(matrix[0, 0], complexNumber.Real);
            Assert.AreEqual(matrix[0, 1], -1 * complexNumber.Imaginary);
            Assert.AreEqual(matrix[1, 0], complexNumber.Imaginary);
            Assert.AreEqual(matrix[1, 1], complexNumber.Real);

            complexNumber = new ComplexNumber(-3, -2);

            matrix = complexNumber.ToMatrix();

            Assert.AreEqual(matrix[0, 0], complexNumber.Real);
            Assert.AreEqual(matrix[0, 1], -1 * complexNumber.Imaginary);
            Assert.AreEqual(matrix[1, 0], complexNumber.Imaginary);
            Assert.AreEqual(matrix[1, 1], complexNumber.Real);
        }

    }
}