/*  
  Copyright 2007-2017 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the MIT License.  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at https://opensource.org/licenses/MIT.
*/



using NGenerics.DataStructures.Mathematical;

namespace NGenerics.Tests.DataStructures.Mathematical.QRDecompositionTests
{

    public class QRDecompositionTests
    {

        /*
         
        Hl = [1]  	H2 = [1, 1/2]  	H3 = [1, 1/2, 1/3]  	H4 = [1, 1/2,1/3,1/4]
	                     [1/2, 1/3] 	 [1/2, 1/3, 1/4] 	     [1/2,1/3,1/4,1/5]
		                                 [1/3, 1/4, 1/5] 	     [1/3,1/4,1/5,1/6]
			                                                     [1/4,1/5,1/6, 1/7]
         
         */

        internal static Matrix GetHilbertMatrix4()
        {
            var matrix = new Matrix(4, 4);

            for (var i = 0; i < 4; i++)
            {
                for (var j = 0; j < 4; j++)
                {
                    matrix[i, j] = 1 / (j + 1d + i);
                }
            }

            return matrix;
        }

        internal static Matrix GetMatrix()
        {
            var matrix = new Matrix(3, 3);
            matrix[0, 0] = 12;
            matrix[0, 1] = -51;
            matrix[0, 2] = 4;

            matrix[1, 0] = 6;
            matrix[1, 1] = 167;
            matrix[1, 2] = -68;

            matrix[2, 0] = -4;
            matrix[2, 1] = 24;
            matrix[2, 2] = -4;

            return matrix;

        }

    }
}
