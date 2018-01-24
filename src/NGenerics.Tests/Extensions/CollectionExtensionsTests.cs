/*  
  Copyright 2007-2017 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the MIT License.  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at https://opensource.org/licenses/MIT.
*/

using System.Collections.Generic;
using NGenerics.Extensions;
using NUnit.Framework;

namespace NGenerics.Tests.Extensions
{
    [TestFixture]
    public class CollectionExtensionsTests
    {
        [Test]
        public void IsEmpty_Returns_False_When_Collection_Has_Items()
        {
            Assert.IsFalse(new List<int>() { 1 }.IsEmpty());
        }

        [Test]
        public void IsEmpty_Returns_True_When_Collection_Has_No_Items()
        {
            Assert.IsTrue(new List<int>().IsEmpty());
        }
    }
}
