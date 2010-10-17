/*  
  Copyright 2007-2010 The NGenerics Team
 (http://code.google.com/p/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/
using System;
using System.Collections.Generic;
using NGenerics.DataStructures.General;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.General.HashListTests
{
    [TestFixture]
    public class Add
    {
        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ExceptionInvalidRange()
        {
            var hashList = new HashList<int, string>
                               {
                                   {3, (List<string>) null}
                               };
        }

        [Test]
        public void Simple()
        {
            var hashList = new HashList<int, string>
                               {
                                   {2, "a"}
                               };

            Assert.AreEqual(hashList.ValueCount, 1);
            Assert.AreEqual(hashList.KeyCount, 1);

            hashList.Add(4, new List<string>(new[] { "2", "3", "4", "5" }));

            Assert.AreEqual(hashList.ValueCount, 5);
            Assert.AreEqual(hashList.KeyCount, 2);

            hashList.Add(2, new List<string>(new[] { "2", "3", "4", "5" }));

            Assert.AreEqual(hashList.ValueCount, 9);
            Assert.AreEqual(hashList.KeyCount, 2);
        }


        [Test]
        public void Params()
        {
            var hashList = new HashList<int, string>
                               {
                                   {2, "a", "b"}
                               };

            Assert.AreEqual(hashList.ValueCount, 2);
            Assert.AreEqual(hashList.KeyCount, 1);

            hashList.Add(4, "2", "3", "4", "5");

            Assert.AreEqual(hashList.ValueCount, 6);
            Assert.AreEqual(hashList.KeyCount, 2);

            hashList.Add(2, "2", "3", "4", "5");

            Assert.AreEqual(hashList.ValueCount, 10);
            Assert.AreEqual(hashList.KeyCount, 2);
        }
    }
}