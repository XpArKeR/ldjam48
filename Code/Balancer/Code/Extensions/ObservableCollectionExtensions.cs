using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Balancer.Extensions
{
    public static class ObservableCollectionExtensions
    {
        public static ObservableCollection<T> Clone<T>(this ObservableCollection<T> observableCollection)
        {
            if (observableCollection != default)
            {
                var newCollection = new ObservableCollection<T>();

                foreach (var entry in observableCollection)
                {
                    if (entry.GetType().IsValueType)
                    {
                        newCollection.Add(entry);
                    }
                    else
                    {
                        //shite
                    }
                }
            }

            return default;
        }
    }
}
