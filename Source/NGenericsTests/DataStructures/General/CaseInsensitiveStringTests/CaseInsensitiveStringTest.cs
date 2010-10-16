/*  
  Copyright 2007-2010 The NGenerics Team
 (http://code.google.com/p/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using System.Collections.Generic;
using NGenerics.DataStructures.General;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.General.CaseInsensitiveStringTests
{
    [TestFixture]
    public class CaseInsensitiveStringTest
    {

        [Test]
        public void ReplaceString()
        {
            CaseInsensitiveString value = "AbcDEf";

            Assert.AreEqual("AbEf", value.Replace("Cd", string.Empty).Value);
            Assert.AreEqual("AbXyEf", value.Replace("Cd", "Xy").Value);
        }

		[Test]
		public void EqualityComparer()
		{
			CaseInsensitiveString value1 = "AbcDEf";
			CaseInsensitiveString value2 = "AbcDEf";

			var defaultComparer = EqualityComparer<CaseInsensitiveString>.Default;
			Assert.AreEqual(defaultComparer.GetHashCode(value1), defaultComparer.GetHashCode(value2));
			Assert.IsTrue(defaultComparer.Equals(value1,value2));
		}

    	[Test]
        public void ReplaceChar()
        {
            CaseInsensitiveString value = "AbcDEf";

            Assert.AreEqual("AbFDEf", value.Replace('C', 'F').Value);
        }
    }
}