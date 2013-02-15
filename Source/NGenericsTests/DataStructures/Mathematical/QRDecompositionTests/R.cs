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
    public class R : QRDecompositionTests
    {

        [Test]
        public void Simple()
        {
            var decomposition = new QRDecomposition(GetMatrix());

            var matrixR = decomposition.RightFactorMatrix;

            Assert.AreEqual(matrixR[0, 0], -14d, 0.0000001);
            Assert.AreEqual(matrixR[0, 1], -21d, 0.0000001);
            Assert.AreEqual(matrixR[0, 2], 24.571428571428569d, 0.0000001);

            Assert.AreEqual(matrixR[1, 0], 0d, 0.0000001);
            Assert.AreEqual(matrixR[1, 1], -175d, 0.0000001);
            Assert.AreEqual(matrixR[1, 2], 63.657142857142844d, 0.0000001);

            Assert.AreEqual(matrixR[2, 0], 0d, 0.0000001);
            Assert.AreEqual(matrixR[2, 1], 0d, 0.0000001);
            Assert.AreEqual(matrixR[2, 2], 0.11428571428571477d, 0.0000001);
        }
        /* 
       * Hilbert order 4 QR decomposition :
       * 
      Q = 0.84  -0.52  0.15  0.03    R = 1.19  0.67  0.47  0.37
          0.42   0.44 -0.73  0.32        0     0.12  0.13  0.12
          0.28   0.53  0.14  0.79        0     0     0.01  0.01
          0.21   0.50  0.65  0.53        0     0     0     0.00
      */

        [Test]
        public void Hilbert()
        {

            var matrix = GetHilbertMatrix4();

            var decomposition = new QRDecomposition(matrix);
            var matrixR = decomposition.RightFactorMatrix;
            var matrixH = decomposition.H;

            Assert.AreEqual(matrixR[0, 0], -1.19, 0.01);
            Assert.AreEqual(matrixR[0, 1], -0.67, 0.01);
            Assert.AreEqual(matrixR[0, 2], -0.47, 0.01);
            Assert.AreEqual(matrixR[0, 3], -0.37, 0.01);

            Assert.AreEqual(matrixR[1, 0], 0);
            Assert.AreEqual(matrixR[1, 1], -0.12, 0.01);
            Assert.AreEqual(matrixR[1, 2], -0.13, 0.01);
            Assert.AreEqual(matrixR[1, 3], -0.12, 0.01);

            Assert.AreEqual(matrixR[2, 0], 0);
            Assert.AreEqual(matrixR[2, 1], 0);
            Assert.AreEqual(matrixR[2, 2], -0.01, 0.01);
            Assert.AreEqual(matrixR[2, 3], -0.01, 0.01);

            Assert.AreEqual(matrixR[3, 0], 0);
            Assert.AreEqual(matrixR[3, 1], 0);
            Assert.AreEqual(matrixR[3, 2], 0);
            Assert.AreEqual(matrixR[3, 3], -0.0001, 0.0001);
        }

    }
}