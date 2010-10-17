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

namespace NGenerics.Tests.DataStructures.General.Observable.ObservablePascalSetTests
{
    [TestFixture]
    public class Clear
    {
        [Test]
        public void Simple()
        {
            var pascalSet = new ObservablePascalSet(10){4};

            ObservableCollectionTester.ExpectEvents(pascalSet, obj => obj.Clear(), "Count", "LowerBound", "UpperBound", "Capacity", "IsFull", "Item[]");
        }

        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ExceptionReentrancy()
        {
            var pascalSet = new ObservablePascalSet(10);
            new ReentracyTester<ObservablePascalSet>(pascalSet, obj => obj.Clear());
        }
    }
}