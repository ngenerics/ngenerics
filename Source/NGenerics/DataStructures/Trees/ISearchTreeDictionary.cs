/*  
  Copyright 2007-2013 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/


using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace NGenerics.DataStructures.Trees {
    /// <summary>
    /// An interface for Search Trees that mimic a dictionary.
    /// </summary>
    /// <typeparam name="TKey">The type of the keys in the <see cref="ISearchTreeDictionary{TKey,TValue}"/>.</typeparam>
    /// <typeparam name="TValue">The type of the values in the <see cref="ISearchTreeDictionary{TKey,TValue}"/>.</typeparam>
    [SuppressMessage("Microsoft.Naming", "CA1710:IdentifiersShouldHaveCorrectSuffix")]
    public interface ISearchTreeDictionary<TKey, TValue> : ISearchTree<KeyValuePair<TKey, TValue>>, IDictionary<TKey, TValue> {

    }
}
