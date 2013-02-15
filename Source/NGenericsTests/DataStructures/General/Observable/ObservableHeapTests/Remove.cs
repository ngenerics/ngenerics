/*  
  Copyright 2007-2013 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/


using System;
using NGenerics.DataStructures.General;
using NGenerics.DataStructures.General.Observable;
using NGenerics.Tests.TestObjects;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.General.Observable.ObservableHeapTests
{
    [TestFixture]
    public class Remove
    {
        [Test]
        public void Simple()
        {
            var heap = new ObservableHeap<string>(HeapType.Minimum)
                               {
                                   "foo"
                               };

            ObservableCollectionTester.ExpectEvents(heap, obj => obj.RemoveRoot(), "Count", "Root", "IsEmpty");
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ExceptionReentrancy()
        {
            var heap = new ObservableHeap<string>(HeapType.Minimum)
                               {
                                   "foo"
                               };
            new ReentracyTester<ObservableHeap<string>>(heap, obj => obj.RemoveRoot());
        }
    }

}