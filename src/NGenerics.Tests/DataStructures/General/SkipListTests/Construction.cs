/*  
  Copyright 2007-2017 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the MIT License.  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at https://opensource.org/licenses/MIT.
*/

using System;
using System.Collections.Generic;
using NGenerics.Comparers;
using NGenerics.DataStructures.General;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.General.SkipListTests
{
    [TestFixture]
    public class Construction
    {

        [Test]
        public void Simple1()
        {
            var skipList = new SkipList<int, string>();

            Assert.AreEqual(0, skipList.Count);
            Assert.AreEqual(Comparer<int>.Default, skipList.Comparer);
            Assert.AreEqual(.5, skipList.Probability);
            Assert.AreEqual(16, skipList.MaximumListLevel);

        }
        [Test]
        public void Simple2()
        {
            var skipList = new SkipList<int, string>(Comparer<int>.Default);

            Assert.AreEqual(0, skipList.Count);
            Assert.AreEqual(Comparer<int>.Default, skipList.Comparer);
            Assert.AreEqual(.5, skipList.Probability);
            Assert.AreEqual(16, skipList.MaximumListLevel);

        }
        [Test]
        public void Simple3()
        {
            var skipList = new SkipList<int, string>(Comparer<int>.Default);
            Assert.AreEqual(0, skipList.Count);
            Assert.AreEqual(Comparer<int>.Default, skipList.Comparer);
            Assert.AreEqual(.5, skipList.Probability);
            Assert.AreEqual(16, skipList.MaximumListLevel);
        }
        [Test]
        public void Simple4()
        {
            var comparison = new Comparison<int>(CompareMethod);
            var skipList = new SkipList<int, string>(10, .2, comparison);
            Assert.AreEqual(0, skipList.Count);
            Assert.IsTrue(skipList.Comparer is ComparisonComparer<int>);
            Assert.AreEqual(.2, skipList.Probability);
            Assert.AreEqual(10, skipList.MaximumListLevel);
        }

        private int CompareMethod(int x, int y)
        {
            throw new NotImplementedException();
        }

        [Test]
        public void Simple5()
        {
            var skipList = new SkipList<int, string>(14, 0.7, Comparer<int>.Default);
            Assert.AreEqual(skipList.Count, 0);
            Assert.AreEqual(Comparer<int>.Default, skipList.Comparer);
            Assert.AreEqual(0.7, skipList.Probability);
            Assert.AreEqual(14, skipList.MaximumListLevel);
        }

        [Test]
        public void ExceptionNullComparer1()
        {
            Assert.Throws<ArgumentNullException>(() => new SkipList<int, string>((IComparer<int>)null));
        }

        [Test]
        public void ExceptionNullComparer2()
        {
            Assert.Throws<ArgumentNullException>(() => new SkipList<int, string>(2, 0.6, (IComparer<int>)null));
        }

        [Test]
        public void ExceptionMaximumLevelBelowOne()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new SkipList<int, string>(-1, 0.5, Comparer<int>.Default));
            Assert.Throws<ArgumentOutOfRangeException>(() => new SkipList<int, string>(0, 1, Comparer<int>.Default));
        }

        [Test]
        public void ExceptionInvalidProbability()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new SkipList<int, string>(0, 0.5, Comparer<int>.Default));
            Assert.Throws<ArgumentOutOfRangeException>(() => new SkipList<int, string>(5, 0, Comparer<int>.Default));
        }
    }
}