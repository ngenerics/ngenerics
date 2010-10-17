/*  
  Copyright 2007-2010 The NGenerics Team
 (http://code.google.com/p/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/
using System.Collections.Generic;
using NGenerics.DataStructures.General.Observable;
using NGenerics.Tests.TestObjects;
using NGenerics.Tests.Util;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.General.Observable.ObservableHashListTests
{
    [TestFixture]
    public class Contruction
    {

        [Test]
        public void Serialization()
        {
            var deserialize = SerializeUtil.BinarySerializeDeserialize(new ObservableHashList<int, int>());
            ObservableCollectionTester.CheckMonitor(deserialize);
        }
        [Test]
        public void Monitor1()
        {
            ObservableCollectionTester.CheckMonitor(new ObservableHashList<int, int>());
        }
        [Test]
        public void Monitor2()
        {
            var capacity = new Dictionary<int, IList<int>>();
            ObservableCollectionTester.CheckMonitor(new ObservableHashList<int, int>(capacity));
        }

        [Test]
        public void Monitor3()
        {
            ObservableCollectionTester.CheckMonitor(new ObservableHashList<int, int>(EqualityComparer<int>.Default));
        }
        [Test]
        public void Monitor4()
        {
            ObservableCollectionTester.CheckMonitor(new ObservableHashList<int, int>(2));
        }
        [Test]
        public void Monitor5()
        {
            ObservableCollectionTester.CheckMonitor(new ObservableHashList<int, int>(2, EqualityComparer<int>.Default));
        }
    }
}