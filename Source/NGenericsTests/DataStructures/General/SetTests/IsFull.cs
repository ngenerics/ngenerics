using NGenerics.DataStructures.General;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.General.SetTests
{
    [TestFixture]
    public class IsFull
    {

        [Test]
        public void Simple()
        {
            var pascalSet = new PascalSet(0, 100);
            Assert.IsFalse(pascalSet.IsFull);

            for (var i = 0; i <= 100; i++)
            {
                pascalSet.Add(i);

                if (i < 100)
                {
                    Assert.IsFalse(pascalSet.IsFull);
                }
                else
                {
                    Assert.IsTrue(pascalSet.IsFull);
                }
            }

            pascalSet.Clear();

            Assert.IsFalse(pascalSet.IsFull);
        }

    }
}