/*  
  Copyright 2007-2013 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/
using NGenerics.DataStructures.Mathematical;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Mathematical.QRDecompositionTests
{
    [TestFixture]
    public class Q : QRDecompositionTests
    {
        [Test]
        public void Simple()
        {
            var decomposition = new QRDecomposition(GetMatrix());

            var matrixQ = decomposition.LeftFactorMatrix;


            Assert.AreEqual(matrixQ[0, 0], -6d / 7d, 0.0000001);
            Assert.AreEqual(matrixQ[0, 1], 69d / 175d, 0.0000001);
            Assert.AreEqual(matrixQ[0, 2], -58d / 175d, 0.0000001);

            Assert.AreEqual(matrixQ[1, 0], -3d / 7d, 0.0000001);
            Assert.AreEqual(matrixQ[1, 1], -158d / 175d, 0.0000001);
            Assert.AreEqual(matrixQ[1, 2], 6d / 175d, 0.0000001);

            Assert.AreEqual(matrixQ[2, 0], 2d / 7d, 0.0000001);
            Assert.AreEqual(matrixQ[2, 1], -6d / 35d, 0.0000001);
            Assert.AreEqual(matrixQ[2, 2], -33d / 35d, 0.0000001);
        }

        [Test]
        public void Hilbert()
        {
            var matrix = GetHilbertMatrix4();

            var decomposition = new QRDecomposition(matrix);
            var matrixQ = decomposition.LeftFactorMatrix;

            Assert.AreEqual(matrixQ[0, 0], -0.84, 0.01);
            Assert.AreEqual(matrixQ[0, 1], 0.52, 0.01);
            Assert.AreEqual(matrixQ[0, 2], -0.15, 0.01);
            Assert.AreEqual(matrixQ[0, 3], 0.03, 0.01);

            Assert.AreEqual(matrixQ[1, 0], -0.42, 0.01);
            Assert.AreEqual(matrixQ[1, 1], -0.44, 0.01);
            Assert.AreEqual(matrixQ[1, 2], 0.73, 0.01);
            Assert.AreEqual(matrixQ[1, 3], -0.32, 0.01);

            Assert.AreEqual(matrixQ[2, 0], -0.28, 0.01);
            Assert.AreEqual(matrixQ[2, 1], -0.53, 0.01);
            Assert.AreEqual(matrixQ[2, 2], -0.14, 0.01);
            Assert.AreEqual(matrixQ[2, 3], 0.79, 0.01);

            Assert.AreEqual(matrixQ[3, 0], -0.21, 0.01);
            Assert.AreEqual(matrixQ[3, 1], -0.50, 0.01);
            Assert.AreEqual(matrixQ[3, 2], -0.65, 0.01);
            Assert.AreEqual(matrixQ[3, 3], -0.53, 0.01);
        }

    }
}