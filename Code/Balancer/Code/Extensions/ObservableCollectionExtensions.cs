using System;
using System.Collections.ObjectModel;
using System.Diagnostics;

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
                    else if (entry is ICloneable cloneable)
                    {
                        var clone = cloneable.Clone();

                        if (clone is T clonedObject)
                        {
                            newCollection.Add(clonedObject);
                        }
                    }
                    else
                    {
                        Debug.WriteLine("Cant clone Object!");
                    }
                }

                return newCollection;
            }

            return default;
        }

        public static void Normalize(this ObservableCollection<Balancer.Model.UnityColor> observableCollection)
        {
            if (observableCollection != default)
            {
                foreach (var color in observableCollection)
                {
                    if (color.A > 1)
                    {
                        color.A /= 255;
                    }

                    if (color.R > 1)
                    {
                        color.R /= 255;
                    }

                    if (color.G > 1)
                    {
                        color.G /= 255;
                    }

                    if (color.B > 1)
                    {
                        color.B /= 255;
                    }
                }
            }
        }
    }
}
