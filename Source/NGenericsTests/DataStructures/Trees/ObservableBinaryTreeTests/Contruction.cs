/*  
  Copyright 2007-2010 The NGenerics Team
 (http://code.google.com/p/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/
using NGenerics.DataStructures.Trees;
using NGenerics.DataStructures.Trees.Observable;
using NGenerics.Tests.TestObjects;
using NGenerics.Tests.Util;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.Trees.ObservableBinaryTreeTests
{
    [TestFixture]
    public class Contruction
    {

        [Test]
        public void Serialization()
        {
            var deserialize = SerializeUtil.BinarySerializeDeserialize(new ObservableBinaryTree<int>(4));
            ObservableCollectionTester.CheckMonitor(deserialize);
        }
        [Test]
        public void Monitor1()
        {
            ObservableCollectionTester.CheckMonitor(new ObservableBinaryTree<int>(4));
        }
        [Test]
        public void Monitor2()
        {
            var left = new BinaryTree<int>(2);
            var right = new BinaryTree<int>(2);
            ObservableCollectionTester.CheckMonitor(new ObservableBinaryTree<int>(4, left, right));
        }
        [Test]
        public void Monitor3()
        {
            ObservableCollectionTester.CheckMonitor(new ObservableBinaryTree<int>(4, 5, 6));
        }
    }
}