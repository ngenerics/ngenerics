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

namespace NGenerics.Tests.DataStructures.Trees.SplayTreeTests
{
    [TestFixture]
    public class Contains : SplayTreeTest
    {

        [Test]
        public void Simple()
        {
            var splayTree = new SplayTree<int, string>();

            Assert.IsFalse(splayTree.ContainsKey(5));

            splayTree.Add(4, "4");
            Assert.AreEqual(splayTree[4], "4");
            Assert.IsTrue(splayTree.ContainsKey(4));
            Assert.IsFalse(splayTree.ContainsKey(5));

            splayTree.Add(6, "6");
            Assert.AreEqual(splayTree[6], "6");
            Assert.IsTrue(splayTree.ContainsKey(4));
            Assert.IsFalse(splayTree.ContainsKey(5));
            Assert.IsTrue(splayTree.ContainsKey(6));

            splayTree.Add(2, "2");
            Assert.AreEqual(splayTree[2], "2");
            Assert.IsTrue(splayTree.ContainsKey(2));
            Assert.IsTrue(splayTree.ContainsKey(4));
            Assert.IsFalse(splayTree.ContainsKey(5));
            Assert.IsTrue(splayTree.ContainsKey(6));

            splayTree.Add(5, "5");
            Assert.AreEqual(splayTree[5], "5");
            Assert.IsTrue(splayTree.ContainsKey(2));
            Assert.IsTrue(splayTree.ContainsKey(4));
            Assert.IsTrue(splayTree.ContainsKey(5));
            Assert.IsTrue(splayTree.ContainsKey(6));


            var rand = new Random();

            splayTree = new SplayTree<int, string>();

            var list = new List<int>();

            for (var i = 0; i < 100; i++)
            {
                int r;

                do
                {
                    r = rand.Next(5000);
                }
                while (list.Contains(r));

                list.Add(r);

                splayTree.Add(r, null);

                Assert.IsTrue(splayTree.ContainsKey(r));
            }
        }


        [Test]
        public void KeyValuePair()
        {
            var splayTree = new SplayTree<int, string>();

            Assert.IsFalse(splayTree.Contains(new KeyValuePair<int, string>(5, "5")));

            splayTree.Add(4, "4");
            Assert.IsTrue(splayTree.Contains(new KeyValuePair<int, string>(4, "4")));
            Assert.IsFalse(splayTree.Contains(new KeyValuePair<int, string>(4, "5")));

            splayTree.Add(6, "6");
            Assert.IsTrue(splayTree.Contains(new KeyValuePair<int, string>(6, "6")));
            Assert.IsFalse(splayTree.Contains(new KeyValuePair<int, string>(6, "5")));
        }

    }
}