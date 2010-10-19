using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading;

namespace WpfExample
{
    public class DelayedObservableCollection<T> : ObservableCollection<T>
    {
        public int Delay { get; set; }
        /// <summary>Initializes a new instance of the <see cref="T:System.Collections.ObjectModel.ObservableCollection`1" /> class.</summary>
        public DelayedObservableCollection()
            : base()
        {
        }

        /// <summary>Initializes a new instance of the <see cref="T:System.Collections.ObjectModel.ObservableCollection`1" /> class that contains elements copied from the specified collection.</summary>
        /// <param name="collection">The collection from which the elements are copied.</param>
        /// <exception cref="T:System.ArgumentNullException">The <paramref name="collection" /> parameter cannot be null.</exception>
        public DelayedObservableCollection(IEnumerable<T> collection)
            : base(collection)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="T:System.Collections.ObjectModel.ObservableCollection`1" /> class that contains elements copied from the specified list.</summary>
        /// <param name="list">The list from which the elements are copied.</param>
        /// <exception cref="T:System.ArgumentNullException">The <paramref name="list" /> parameter cannot be null.</exception>
        public DelayedObservableCollection(List<T> list)
            : base(list)
        {
        }
        protected override void SetItem(int index, T item)
        {
            base.SetItem(index, item);

            Thread.Sleep(Delay);
        }

    }
}