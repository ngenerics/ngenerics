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

namespace NGenerics.Tests.DataStructures.General.SkipListTests
{
    [TestFixture]
    public class CopyTo
    {

        [Test]
        public void Simple()
        {
            var skipList = new SkipList<int, string>();

            var pairs = new KeyValuePair<int, string>[5];

            for (var i = 0; i < pairs.Length; i++)
            {
                pairs[i] = new KeyValuePair<int, string>(i, i.ToString());
                skipList.Add(pairs[i]);
            }

            var array = new KeyValuePair<int, string>[50];

            skipList.CopyTo(array, 0);

            var list = new List<KeyValuePair<int, string>>
                           {
                               array[0],
                               array[1],
                               array[2],
                               array[3],
                               array[4],
                               array[5]
                           };

            foreach (var keyValuePair in pairs)
            {
                Assert.IsTrue(list.Contains(keyValuePair));
            }
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void ExceptionInvalid1()
        {
            var skipList = new SkipList<int, string>();

            var pairs = new KeyValuePair<int, string>[5];

            for (var i = 0; i < pairs.Length; i++)
            {
                pairs[i] = new KeyValuePair<int, string>(i, i.ToString());
                skipList.Add(pairs[i]);
            }

            var array = new KeyValuePair<int, string>[4];

            skipList.CopyTo(array, 0);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void ExceptionInvalid2()
        {
            var skipList = new SkipList<int, string>();

            var pairs = new KeyValuePair<int, string>[5];

            for (var i = 0; i < pairs.Length; i++)
            {
                pairs[i] = new KeyValuePair<int, string>(i, i.ToString());
                skipList.Add(pairs[i]);
            }

            var array = new KeyValuePair<int, string>[4];

            skipList.CopyTo(array, 0);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ExceptionInvalid3()
        {
            var skipList = new SkipList<int, string>();

            var pairs = new KeyValuePair<int, string>[5];

            for (var i = 0; i < pairs.Length; i++)
            {
                pairs[i] = new KeyValuePair<int, string>(i, i.ToString());
                skipList.Add(pairs[i]);
            }

            skipList.CopyTo(null, 0);
        }

    }
}