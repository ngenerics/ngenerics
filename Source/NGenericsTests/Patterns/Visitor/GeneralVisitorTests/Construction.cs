using System;
using NGenerics.Patterns.Visitor;
using NUnit.Framework;

namespace NGenerics.Tests.Patterns.Visitor.GeneralVisitorTests
{
    [TestFixture]
    public class Construction
    {
        [Test]
        public void Simple()
        {
            new GeneralVisitor<int>(
                delegate {
                             return false;
                }
                );
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ExceptionNullPredicate()
        {
            new GeneralVisitor<int>(null);
        }
    }
}