/*  
  Copyright 2007-2010 The NGenerics Team
 (http://code.google.com/p/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/
using System;
using System.Collections.Generic;
using NGenerics.DataStructures.Trees;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Trees.BinarySearchTreeTests
{
    [TestFixture]
    public class TryGetValue : BinarySearchTreeTest
    {

        [Test]
        public void Simple()
        {
            var tree = new BinarySearchTree<int, string>();

            var dictionary = new Dictionary<int, string>();

            var rand = new Random(Convert.ToInt32(DateTime.Now.Ticks % Int32.MaxValue));

            for (var i = 0; i < 50; i++)
            {
                var gen = rand.Next(2000);

                while (dictionary.ContainsKey(gen))
                {
                    gen = rand.Next(2000);
                }

                dictionary.Add(gen, null);

                tree.Add(gen, gen.ToString());

                string val;

                Assert.AreEqual(tree.Count, i + 1);

                tree.TryGetValue(gen, out val);
                Assert.AreEqual(val, gen.ToString());
                Assert.AreEqual(tree[gen], gen.ToString());
            }

            string val2;
            tree.TryGetValue(2001, out val2);
            Assert.IsNull(val2);
        }

    }
}