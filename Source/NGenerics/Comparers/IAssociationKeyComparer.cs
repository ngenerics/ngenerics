/*  
  Copyright 2007-2010 The NGenerics Team
 (http://code.google.com/p/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using System.Collections.Generic;
using NGenerics.DataStructures.General;

namespace NGenerics.Comparers
{
    /// <summary>
    /// A comparer for Associations of the specified type.
    /// </summary>
    /// <typeparam name="TKey">The type of the key.</typeparam>
    /// <typeparam name="TValue">The type of the value.</typeparam>
    public interface IAssociationKeyComparer<TKey, TValue> : IComparer<Association<TKey, TValue>>,  IComparer<TKey>
    {
        
    }
}