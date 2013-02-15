/*  
  Copyright 2007-2013 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/
using System.Collections.Generic;
using NGenerics.DataStructures.General.Observable;
using NGenerics.Tests.TestObjects;
using NGenerics.Tests.Util;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.General.Observable.ObservableSkipListTests
{
    [TestFixture]
    public class Contruction
    {

        [Test]
        public void Serialization()
        {
            var deserialize = SerializeUtil.BinarySerializeDeserialize(new ObservableSkipList<int, int>());
            ObservableCollectionTester.CheckMonitor(deserialize);
        }

        [Test]
        public void Monitor1()
        {
            ObservableCollectionTester.CheckMonitor(new ObservableSkipList<int, int>());
        }
        [Test]
        public void Monitor2()
        {
            ObservableCollectionTester.CheckMonitor(new ObservableSkipList<int, int>(Comparer<int>.Default));
        }
        [Test]
        public void Monitor3()
        {
            ObservableCollectionTester.CheckMonitor(new ObservableSkipList<int, int>(2, .4, Comparer<int>.Default));
        }
    }
}