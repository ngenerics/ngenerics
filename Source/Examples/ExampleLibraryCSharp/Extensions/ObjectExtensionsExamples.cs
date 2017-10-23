/*  
  Copyright 2007-2017 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the MIT License.  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at https://opensource.org/licenses/MIT.
*/


using NGenerics.Extensions;
using NUnit.Framework;

namespace ExampleLibraryCSharp.Extensions
{
    [TestFixture]
    public class ObjectExtensionsExamples
    {
        #region ConvertTo
        [Test]
        public void ConvertToExample()
        {
            // Convert from the string representation to an actual number,
            var from = "23.55";
            var to =  from.ConvertTo<decimal>();

            Assert.AreEqual(to, 23.55);
        }
        #endregion
    }
}
