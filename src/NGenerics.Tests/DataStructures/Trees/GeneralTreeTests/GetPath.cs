/*  
  Copyright 2007-2017 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the MIT License.  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at https://opensource.org/licenses/MIT.
*/

using System;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Trees.GeneralTreeTests
{
    [TestFixture]
    public class GetPath : GeneralTreeTest
    {
        [Test]
        public void Simple()
        {
            var tree = GetTestTree();
            var data = tree[0][0].GetPath();

            Assert.AreEqual(data[0], tree);
            Assert.AreEqual(data[1], tree[0]);
        }

        [Test]
        public void SimpleWithConverter()
        {
            var tree = GetTestTree();
            var data = tree[0][0].GetPath(x => x.Data);

            Assert.AreEqual(data[0], 5);
            Assert.AreEqual(data[1], 2);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NullConverter()
        {
            var tree = GetTestTree();
            tree.GetPath<int>(null);
        }
    }
}