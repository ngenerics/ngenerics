/*  
  Copyright 2007-2017 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the MIT License.  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at https://opensource.org/licenses/MIT.
*/



using System;
using NGenerics.Util;
using NUnit.Framework;

namespace NGenerics.Tests.Util.GuardTests
{
    [TestFixture]
		public class ArgumentNotNullOrEmptyString
		{
			[Test]
			public void Simple()
			{
			    const string s = "a";

			    // Should not throw an exception
				Guard.ArgumentNotNullOrEmptyString(s, "tmp");
			}

		    [Test]
			public void ExceptionParameterNull()
		    {
		        const string s = null;
		        try
				{
					Guard.ArgumentNotNullOrEmptyString(s, "tmp1");
				}
				catch (ArgumentException ex)
				{
					Assert.AreEqual("tmp1", ex.ParamName);
				}
		    }

		    [Test]
			public void ExceptionParameterEmptyString()
			{
				var s = String.Empty;
				try
				{
					Guard.ArgumentNotNullOrEmptyString(s, "tmp2");
				}
				catch (ArgumentException ex)
				{
					Assert.AreEqual("tmp2", ex.ParamName);
				}
			}
		}
}
