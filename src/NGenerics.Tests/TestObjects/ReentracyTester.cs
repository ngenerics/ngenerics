/*  
  Copyright 2007-2017 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the MIT License.  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at https://opensource.org/licenses/MIT.
*/


using System;
using System.Collections.Specialized;
using System.ComponentModel;

namespace NGenerics.Tests.TestObjects
{
    public class ReentracyTester<T> where T : INotifyCollectionChanged, INotifyPropertyChanged
    {
        private readonly T target;
        private readonly Action<T> action2;

        public ReentracyTester(T target, Action<T> action1):this (target,action1,action1)
        {
        }

        public ReentracyTester(T target, Action<T> action1, Action<T> action2)
        {
            this.target = target;
            this.action2 = action2;
            target.CollectionChanged += CollectionChanged;
            action1(target);
        }

        void CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            action2(target);
        }
    }
}