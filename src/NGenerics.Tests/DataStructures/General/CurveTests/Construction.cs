/*  
  Copyright 2007-2017 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the MIT License.  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at https://opensource.org/licenses/MIT.
*/

using System.Collections.Generic;
using NGenerics.DataStructures.General;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.General.CurveTests
{
    [TestFixture]
    public class Construction
    {
        [Test]
        public void Simple()
        {
            var curve = new Curve<int, int>();
            Assert.IsEmpty(curve);
        }

        [Test]
        public void Capacity()
        {
            var curve = new Curve<int, int>(3);
            Assert.AreEqual(3, curve.Capacity);
        }

        [Test]
        public void DictionaryCollection()
        {
            var curve = new Curve<int, int>(new Dictionary<int, int> { { 1, 3 }, { 2, 3 }, { 4, 2 } });
            Assert.IsTrue(curve.Contains(2, 3));
        }

        [Test]
        public void ListCollection()
        {
            var arr = new[] { new Association<int, int>(1, 22) ,
                              new Association<int, int>(3,2),
                              new Association<int, int>(11,32)};

            var curve = new Curve<int, int>(arr);
            Assert.IsFalse(curve.Contains(2, 3));
            Assert.IsTrue(curve.Contains(3, 2));
        }
    }
}