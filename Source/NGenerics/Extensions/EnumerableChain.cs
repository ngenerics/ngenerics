/*  
  Copyright 2007-2009 The NGenerics Team
 (http://code.google.com/p/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using System.Collections.Generic;
using NGenerics.Util;

namespace NGenerics.Extensions
{
    /// <summary>
    /// A simple chainer for enumerators.
    /// </summary>
    /// <typeparam name="T">The type of item to enumerate.</typeparam>
    internal class EnumerableChain<T> : IEnumerable<T>
    {
        #region Globals

        private readonly IEnumerable<T>[] links;

        #endregion

        #region Public Members

        /// <summary>
        /// Initializes a new instance of the <see cref="EnumerableChain&lt;T&gt;"/> class.
        /// </summary>
        /// <param name="links">The links.</param>
        public EnumerableChain(params IEnumerable<T>[] links)
        {
            #region Validation

            Guard.ArgumentNotNull(links, "links");

            #endregion

            this.links = links;
        }

        #endregion

        #region IEnumerable<T> Members

        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.Collections.Generic.IEnumerator`1"/> that can be used to iterate through the collection.
        /// </returns>
        public IEnumerator<T> GetEnumerator()
        {
            foreach (var link in links)
            {
                foreach (var item in link)
                {
                    yield return item;
                }
            }
        }

        #endregion

        #region IEnumerable Members

        /// <summary>
        /// Returns an enumerator that iterates through a collection.
        /// </summary>
        /// <returns>
        /// An <see cref="T:System.Collections.IEnumerator"/> object that can be used to iterate through the collection.
        /// </returns>
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #endregion
    }
}