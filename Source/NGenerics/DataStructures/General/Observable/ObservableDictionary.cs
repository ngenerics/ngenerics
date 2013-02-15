/*  
  Copyright 2007-2013 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html.
*/


using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics.CodeAnalysis;
using System;

namespace NGenerics.DataStructures.General.Observable
{
    [Serializable]
    [SuppressMessage("Microsoft.Naming", "CA1710:IdentifiersShouldHaveCorrectSuffix")]
    public partial class ObservableDictionary<TKey, TValue> : DictionaryBase<TKey, TValue>
    {
        /// <summary>
        /// Protected virual method for adding items which can be overriden in subclasses
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        protected override void AddItem(TKey key, TValue value)
        {
            CheckReentrancy();
            base.AddItem(key, value);
            OnPropertyChanged("Count", "KeyCount", "ValueCount", "IsEmpty", "Item[]");
            OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, new KeyValuePair<TKey, TValue>(key, value), -1));
        }

        /// <summary>
        /// Protected virual method for removing items which can be overriden in subclasses
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        protected override bool RemoveItem(TKey key)
        {
            CheckReentrancy();
            TValue value;
            if (TryGetValue(key, out value))
            {
                base.RemoveItem(key);
                OnPropertyChanged("Count", "KeyCount", "ValueCount", "IsEmpty", "Item[]");
                OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove, new KeyValuePair<TKey, TValue>(key, value), -1));
                return true;
            }
            return false;
        }

        /// <summary>
        /// Protected virual method for setting items which can be overriden in subclasses
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        protected override void SetItem(TKey key, TValue value)
        {
            CheckReentrancy();
            base.SetItem(key, value);
            OnPropertyChanged("Item[]");
            OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Replace, new KeyValuePair<TKey, TValue>(key, value), -1));
        }

        /// <summary>
        /// Protected virual method for clearing items which can be overriden in subclasses
        /// </summary>
        protected override void ClearItems()
        {
            CheckReentrancy();
            base.ClearItems();
            OnPropertyChanged("Count", "KeyCount", "ValueCount", "IsEmpty", "Item[]");
            OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
        }

    }
}