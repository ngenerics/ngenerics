/*  
  Copyright 2007-2010 The NGenerics Team
 (http://code.google.com/p/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/


using System;
using NGenerics.DataStructures.General.Observable;
using NGenerics.Tests.TestObjects;
using NUnit.Framework;

namespace NGenerics.Tests.DataStructures.General.Observable.ObservableBagTests
{
    [TestFixture]
    public class Remove
    {
        [Test]
        public void Simple()
        {

            var bag = new ObservableBag<string> { "foo" };

            ObservableCollectionTester.ExpectEvents(bag, obj => obj.Remove("foo"), "Count", "Item[]", "IsEmpty");

        }
        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ExceptionReentrancy()
        {
            var bag = new ObservableBag<string> { "foo", "bar" };
            new ReentracyTester<ObservableBag<string>>(bag, obj => obj.Remove("foo"), obj => obj.Remove("bar"));
        }
        [Test]
        public void Amount()
        {

            var bag = new ObservableBag<string> { { "foo", 2 } };

            ObservableCollectionTester.ExpectEvents(bag, obj => obj.Remove("foo", 1), "Count", "Item[]", "IsEmpty");

        }

    }


}