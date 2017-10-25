/*  
  Copyright 2007-2017 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the MIT License.  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at https://opensource.org/licenses/MIT.
*/
 
namespace NGenerics.DataStructures.Mathematical
{
    /// <summary>
    /// Represents the different types of Triangular Matrices.
    /// </summary>
    public enum TriangularMatrixType
    {
        /// <summary>
        /// Non-triangular Matrix
        /// </summary>
        None,
        /// <summary>
        /// Upper Triangular Matrixes
        /// </summary>
        Upper,
        /// <summary>
        /// Lower Triangular Matrixes
        /// </summary>
        Lower,
        /// <summary>
        /// Diagonal Matrixes
        /// </summary>
        Diagonal
    };
}
