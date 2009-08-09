/*  
  Copyright 2007-2009 The NGenerics Team
 (http://code.google.com/p/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html. 
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
