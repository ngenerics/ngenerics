/*  
 Copyright 2009 The NGenerics Team
 (http://www.codeplex.com/NGenerics/Wiki/View.aspx?title=Team)

 This program is licensed under the Microsoft Permissive License (Ms-PL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.codeplex.com/NGenerics/Project/License.aspx.
*/

using System;
using System.Collections.Generic;
using NGenerics.Util;

namespace NGenerics.Patterns.Visitor
{
    /// <summary>
    /// Visitor related extensions.
    /// </summary>
    public static class VisitorExtensions
    {
        /// <summary>
        /// Accepts the visitor into the collection, visiting each item.
        /// </summary>
        /// <typeparam name="T">The type of item to visit.</typeparam>
        /// <param name="enumerable">The enumerable.</param>
        /// <param name="visitor">The visitor.</param>
        /// <exception cref="ArgumentNullException"><paramref name="visitor"/> is a null reference (<c>Nothing</c> in Visual Basic).</exception>
        public static void AcceptVisitor<T>(this IEnumerable<T> enumerable, IVisitor<T> visitor)
        {
            Guard.ArgumentNotNull(visitor, "visitor");

            foreach (var item in enumerable)
            {
                if (visitor.HasCompleted)
                {
                    return;
                }
                
                visitor.Visit(item);
            }
        }
    }
}