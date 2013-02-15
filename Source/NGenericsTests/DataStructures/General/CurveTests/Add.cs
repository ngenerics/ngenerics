/*  
  Copyright 2007-2013 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/
using System.Collections;
using NGenerics.DataStructures.General;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.General.CurveTests
{
    [TestFixture]
    public class Add : Curve<int, int>
    {
        [Test]
        public void Simple()
        {
            var curve = new Curve<string, int> { { "alpha", 3 } };
            Assert.IsTrue(curve.Contains("alpha", 3));
        }
        [Test]
        public void Interface()
        {
            var curve = (IList)new Curve<int, int>();
            var a = new Association<int, int>(11, 32);
            curve.Add(a);
            Assert.IsTrue(curve.Contains(a));
        }
        [Test]
        public void AddOne()
        {
            var curve = new Curve<int, int>();
            var a = new Association<int, int>(11, 32);
            curve.Add(a);
            Assert.IsTrue(curve.Contains(a));
            Assert.IsTrue(curve.Contains(11, 32));

        }

        [Test]
        public void AddTwo()
        {
            var curve = new Curve<int, int>
                            {
                                {12, 32}
                            };
            Assert.IsTrue(curve.Contains(12, 32));
        }

    }
}