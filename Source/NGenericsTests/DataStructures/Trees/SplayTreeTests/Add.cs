/*  
  Copyright 2007-2013 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

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
    public class Add : SplayTreeTest
    {
        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void ExceptionDuplicate()
        {
            var splayTree = new SplayTree<int, string> { { 4, "4" }, { 4, "4" } };
        }

        [Test]
        public void Simple()
        {
            var splayTree = new SplayTree<int, string>();

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

                splayTree.Add(gen, gen.ToString());

                Assert.AreEqual(splayTree.Count, i + 1);
                Assert.IsTrue(splayTree.ContainsKey(gen));
            }
        }

        [Test]
        public void KeyValuePair()
        {
            var splayTree = new SplayTree<int, string>();

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

                splayTree.Add(new KeyValuePair<int, string>(gen, gen.ToString()));

                Assert.AreEqual(splayTree.Count, i + 1);
                Assert.IsTrue(splayTree.ContainsKey(gen));
            }
        }

    }
}