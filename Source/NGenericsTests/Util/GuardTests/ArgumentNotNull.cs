using System;
using NGenerics.Util;
using NUnit.Framework;

namespace NGenerics.Tests.Util.GuardTests
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
}