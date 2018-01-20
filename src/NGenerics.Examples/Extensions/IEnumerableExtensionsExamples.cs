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

namespace ExampleLibraryCSharp.Extensions
{
    [TestFixture]
    public class IEnumerableExtensionsExamples
    {
        #region ForEach

        [Test]
        public void ForEachExample()
        {
            IEnumerable<long> numbers = new List<long> {1, 3, 5, 7, 10};
            long total = 0;
            
            // For each number in the list, add it to the total.
            numbers.ForEach(x => total += x);

            Assert.AreEqual(total, 26);
        }

        #endregion
    }
}
