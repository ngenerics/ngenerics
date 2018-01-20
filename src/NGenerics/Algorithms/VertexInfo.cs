/*  
  Copyright 2007-2017 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the MIT License.  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at https://opensource.org/licenses/MIT.
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
