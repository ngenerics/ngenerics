/*  
  Copyright 2007-2013 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
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
