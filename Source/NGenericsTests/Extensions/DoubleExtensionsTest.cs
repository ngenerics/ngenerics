/*  
  Copyright 2007-2010 The NGenerics Team
 (http://code.google.com/p/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using NUnit.Framework;
using NGenerics.Extensions;

namespace NGenerics.Tests.Extensions
{
	[TestFixture]
	public class DoubleExtensionsTests
	{
		[TestFixture]
		public class IsSimilarTo
		{
			[Test]
			public void Should_Be_Similiar()
			{
				var d1 = 5.000000000009d;
				var d2 = 5d;

				Assert.IsTrue(d1.IsSimilarTo(d2));
			}

			[Test]
			public void Should_Not_Be_Similiar()
			{
				var d1 = 5.00000000002d;
				var d2 = 5d;

				Assert.IsFalse(d1.IsSimilarTo(d2));
			}
		}

	}

}