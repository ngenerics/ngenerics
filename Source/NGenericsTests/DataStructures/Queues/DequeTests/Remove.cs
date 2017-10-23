/*  
  Copyright 2007-2017 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the MIT License.  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at https://opensource.org/licenses/MIT.
*/

using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Queues.DequeTests
{
    [TestFixture]
    public class Remove : DequeTest
    {

        [Test]
        [ExpectedException(typeof(NotSupportedException))]
        public void ExceptionInterface()
        {
            ICollection<int> deque = GetTestDeque();
            deque.Remove(5);
        }

    }
}