/*  
  Copyright 2007-2017 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the MIT License.  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at https://opensource.org/licenses/MIT.
*/

using System;
using NGenerics.Patterns.Visitor;
using NUnit.Framework;

namespace NGenerics.Tests.TestObjects
{
    public class AssertionVisitor<T> : TrackingVisitor<T>
    {
        public void AssertTracked(params T[] items)
        {
            AssertTracked(x => x, items);
        }

        public void AssertTracked<TK>(Func<T, TK> map, params TK[] items)
        {
            for (int i = 0; i < items.Length; i++)
            {
                Assert.AreEqual(items[i], map(TrackingList[i]));
            }
        }
    }
}
