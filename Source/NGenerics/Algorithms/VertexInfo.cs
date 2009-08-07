/*  
 Copyright 2009 The NGenerics Team
 (http://www.codeplex.com/NGenerics/Wiki/View.aspx?title=Team)

 This program is licensed under the Microsoft Permissive License (Ms-PL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.codeplex.com/NGenerics/Project/License.aspx.
*/


using NGenerics.DataStructures.General;

namespace NGenerics.Algorithms
{
    internal class VertexInfo<T>
    {
        #region Construction

        public VertexInfo(double distance, Edge<T> edgeFollowed, bool isFinalised)
        {
            Distance = distance;
            EdgeFollowed = edgeFollowed;
            IsFinalised = isFinalised;
        }

        #endregion

        #region Properties

        public double Distance { get; set; }

        public Edge<T> EdgeFollowed { get; set; }

        public bool IsFinalised { get; set; }

        #endregion
    }
}
