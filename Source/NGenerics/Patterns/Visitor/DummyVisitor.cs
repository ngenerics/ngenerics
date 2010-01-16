/*  
  Copyright 2007-2010 The NGenerics Team
 (http://code.google.com/p/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html. 
*/

namespace NGenerics.Patterns.Visitor
{
    /// <summary>
    /// A dummy visitor - that does absolutely nothing with visits.
    /// Believe it or not, it's actually useful in some situations.
    /// </summary>
    /// <typeparam name="T">The type of item to visit.</typeparam>
    public class DummyVisitor<T> : IVisitor<T>
    {
        #region IVisitor<T> Members

        /// <inheritdoc />
        public bool HasCompleted
        {
            get { return false; }
        }

        /// <inheritdoc />
        public void Visit(T obj)
        {
            
        }

        #endregion
    }
}