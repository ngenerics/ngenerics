/*  
 Copyright 2009 The NGenerics Team
 (http://www.codeplex.com/NGenerics/Wiki/View.aspx?title=Team)

 This program is licensed under the Microsoft Permissive License (Ms-PL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.codeplex.com/NGenerics/Project/License.aspx.
*/


using System;
using NGenerics.Util;
using NUnit.Framework;

namespace NGenerics.Tests.Util
{
    [TestFixture]
    public class GuardTest
	{
		[TestFixture]
		public class ArgumentNotNull
		{
			[Test]
			public void ExceptionParameterNull()
			{
				try
				{
				    const object tmp = null;
				    Guard.ArgumentNotNull(tmp, "tmp");
				}
				catch (ArgumentNullException ex)
				{
					Assert.AreEqual(ex.ParamName, "tmp");
				}
			}

			[Test]
			public void ParameterNotNull()
			{
				var tmp = new object();
				// Should not throw an exception
				Guard.ArgumentNotNull(tmp, "tmp");
			}
		}

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
					Assert.AreEqual(ex.ParamName, "tmp1");
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
					Assert.AreEqual(ex.ParamName, "tmp2");
				}
			}
		}
    }
}
