using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.General.ObjectMatrixTests
{
    [TestFixture]
    public class GetEnumerator:ObjectMatrixTest
    {
        [Test]
        public void Interface()
        {
            var matrix = GetTestMatrix();

            var list = new List<int>();

            var enumerator = ((IEnumerable)matrix).GetEnumerator();
            {
                while (enumerator.MoveNext())
                {
                    list.Add((int) enumerator.Current);
                }
            }

            Assert.AreEqual(list.Count, matrix.Columns * matrix.Rows);

            for (var i = 0; i < matrix.Rows; i++)
            {
                for (var j = 0; j < matrix.Columns; j++)
                {
                    Assert.IsTrue(list.Contains(i + j));
                }
            }
        }

        [Test]
        public void Simple()
        {
            var matrix = GetTestMatrix();

            var list = new List<int>();

            using (var enumerator = matrix.GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    list.Add(enumerator.Current);
                }
            }

            Assert.AreEqual(list.Count, matrix.Columns * matrix.Rows);

            for (var i = 0; i < matrix.Rows; i++)
            {
                for (var j = 0; j < matrix.Columns; j++)
                {
                    Assert.IsTrue(list.Contains(i + j));
                }
            }
        }
    }
}