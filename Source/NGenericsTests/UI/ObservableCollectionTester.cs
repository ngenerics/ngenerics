/*  
  Copyright 2007-2009 The NGenerics Team
 (http://code.google.com/p/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/

using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Reflection;
using NUnit.Framework;

namespace NGenerics.Tests.UI
{
    public static class ObservableCollectionTester
    {

        public static void CheckMonitor(object target)
        {
            var fieldInfo = target.GetType().GetField("monitor", BindingFlags.Instance | BindingFlags.NonPublic	);
            var monitor = fieldInfo.GetValue(target);
            Assert.IsNotNull(monitor);
        }

        public static void ExpectNoEvents<T>(T target, Action<T> action) where T : INotifyCollectionChanged, INotifyPropertyChanged
        {
            var collectionChangedEventFired = false;
            var propertyNameFired = new List<string>();
            target.CollectionChanged += ((colectionChangedSender, collectionChangedEventArgs) => collectionChangedEventFired = true);
            target.PropertyChanged += ((propertyChangedSender, propertyChangedEventArgs) => propertyNameFired.Add(propertyChangedEventArgs.PropertyName));
            action(target);
            Assert.IsFalse(collectionChangedEventFired);
            Assert.AreEqual(0, propertyNameFired.Count);
        }

        public static void ExpectEvents<T>(T target, Action<T> action, bool expectCollectionChanged, params string[] expectedPropertyChangedNames) where T : INotifyCollectionChanged, INotifyPropertyChanged
        {
            var collectionChangedEventFired = false;
            var propertyNameFired = new List<string>();
            target.CollectionChanged += ((colectionChangedSender, collectionChangedEventArgs) => collectionChangedEventFired = true);
            target.PropertyChanged += ((propertyChangedSender, propertyChangedEventArgs) => propertyNameFired.Add(propertyChangedEventArgs.PropertyName));
            action(target);
            if(expectCollectionChanged)
            {
                Assert.IsTrue(collectionChangedEventFired);
            }
            Assert.AreEqual(expectedPropertyChangedNames.Length, propertyNameFired.Count);
            foreach (var propertyName in expectedPropertyChangedNames)
            {
                Assert.IsTrue(propertyNameFired.Contains(propertyName));
            }
        }

        public static void ExpectEvents<T>(T target, Action<T> action, params string[] expectedPropertyChangedNames) where T : INotifyCollectionChanged, INotifyPropertyChanged
        {
            ExpectEvents(target,action,true,expectedPropertyChangedNames);
        }

    
    }
}