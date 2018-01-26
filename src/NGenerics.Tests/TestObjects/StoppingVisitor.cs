/*  
  Copyright 2007-2017 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the MIT License.  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at https://opensource.org/licenses/MIT.
*/

using System;
using NGenerics.Patterns.Visitor;

namespace NGenerics.Tests.TestObjects
{
    public class StoppingVisitor<T> : IVisitor<T>
    {
        #region Globals

        private readonly int _stopAfterCount;
        private int _visitedCount;

        #endregion

        #region Construction

        public StoppingVisitor(int stopAfterCount = 1)
        {
            _stopAfterCount = stopAfterCount;
        }

        #endregion

        #region IVisitor Members

        public bool HasCompleted => _visitedCount >= _stopAfterCount;

        public void Visit(T obj)
        {
            if (HasCompleted)
            {
                throw new InvalidOperationException("Attempted to visit an object while finished.");
            }

            _visitedCount++;
        }

        #endregion
    }
}