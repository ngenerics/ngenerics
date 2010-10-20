
using System;
using System.Collections.ObjectModel;
using System.Linq;
using NGenerics.Sorting;

namespace WpfExample
{
    public class Util
    {

        private static readonly ObservableCollection<ISorter<int>> _sorterList =
            new ObservableCollection<ISorter<int>>();

        /// <summary>
        /// Singleton method dynamically creating a list of available ISorter Implementations
        /// </summary>
        /// <returns></returns>
        static public ObservableCollection<ISorter<int>> GetSorterList()
        {
            if (_sorterList.Count == 0)
            {
                var types = AppDomain.CurrentDomain.GetAssemblies()
                    .SelectMany(s => s.GetTypes())
                    .Where(p => (p.IsClass && !p.IsAbstract && p.GetInterface("ISorter`1") != null));
                foreach (var t in types)
                {
                    try
                    {
                        var a = (t.IsGenericType)
                                    ? Activator.CreateInstance(t.MakeGenericType(new[] { typeof(int) }))
                                    : Activator.CreateInstance(t);
                        _sorterList.Add(a as ISorter<int>);
                    }
                    catch (Exception)
                    {
                    }

                }
            }
            return _sorterList;
        }

    }
}
