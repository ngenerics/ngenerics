/*  
  Copyright 2007-2017 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the MIT License.  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at https://opensource.org/licenses/MIT.
*/

using System;
using System.Collections.Generic;
using NGenerics.DataStructures.General;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.General.SkipListTests
{
    [TestFixture]
    public class Add
    {

        [Test]
        public void Sequential()
        {
            var skipList = new SkipList<int, string>();

            for (var i = 0; i < 500; i++)
            {
                if ((i % 2) == 0)
                {
                    skipList.Add(i, i.ToString());
                }
                else
                {
                    skipList.Add(new KeyValuePair<int, string>(i, i.ToString()));
                }

                Assert.AreEqual(skipList.Count, i + 1);
                Assert.AreEqual(skipList[i], i.ToString());
            }
        }

        [Test]
        public void ExceptionDuplicate1()
        {
            var skipList = new SkipList<int, string>();

            for (var i = 0; i < 20; i++)
            {
                skipList.Add(i, i.ToString());
            }

            Assert.Throws<ArgumentException>(() => skipList.Add(5, "5"));
        }

        [Test]
        public void ExceptionDuplicate2()
        {
            var skipList = new SkipList<int, string>();

            for (var i = 0; i < 20; i++)
            {
                skipList.Add(i, i.ToString());
            }

            Assert.Throws<ArgumentException>(() => skipList.Add(0, "0"));
        }

        [Test]
        public void ExceptionDuplicate3()
        {
            var skipList = new SkipList<int, string>();

            for (var i = 0; i < 20; i++)
            {
                skipList.Add(i, i.ToString());
            }

            Assert.Throws<ArgumentException>(() => skipList.Add(19, "19"));
        }

        [Test]
        public void ExceptionDuplicate4()
        {
            var skipList = new SkipList<int, string>();

            for (var i = 0; i < 20; i++)
            {
                skipList.Add(i, i.ToString());
            }

            Assert.Throws<ArgumentException>(() => skipList.Add(10, "15"));
        }

        [Test]
        public void Reverse()
        {
            var skipList = new SkipList<int, string>();

            var counter = 0;

            for (var i = 499; i >= 0; i--)
            {
                if ((i % 2) == 0)
                {
                    skipList.Add(i, i.ToString());
                }
                else
                {
                    skipList.Add(new KeyValuePair<int, string>(i, i.ToString()));
                }

                counter++;

                Assert.AreEqual(skipList.Count, counter);
                Assert.AreEqual(skipList[i], i.ToString());
            }
        }

    }
}