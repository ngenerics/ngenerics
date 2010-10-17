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

namespace NGenerics.Tests.DataStructures.General.Observable.ObservableDictionaryTests
{
    [TestFixture]
    public class Clear
    {
        [Test]
        public void Simple()
        {
            var observableDictionary = new ObservableDictionary<string, string>
                                           {
                                               {"foo", "Bar"}
                                           };

            ObservableCollectionTester.ExpectEvents(observableDictionary, obj => obj.Clear(), "Count", "Item[]", "IsEmpty", "ValueCount", "KeyCount");
        }
        [Test]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ExceptionReentrancy()
        {
            var observableDictionary = new ObservableDictionary<string, string>
                                           {
                                               {"foo", "Bar"}
                                           };
            new ReentracyTester<ObservableDictionary<string, string>>(observableDictionary, obj => obj.Clear());
        }
    }
}