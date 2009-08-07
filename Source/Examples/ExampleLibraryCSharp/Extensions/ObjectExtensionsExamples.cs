/*  
 Copyright 2009 The NGenerics Team
 (http://www.codeplex.com/NGenerics/Wiki/View.aspx?title=Team)

 This program is licensed under the Microsoft Permissive License (Ms-PL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.codeplex.com/NGenerics/Project/License.aspx.
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
            var to = from.ConvertTo<decimal>();

            Assert.AreEqual(to, 23.55);
        }
        #endregion
    }
}
