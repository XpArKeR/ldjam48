using System;
using System.Collections.Generic;
using System.Linq;

namespace Balancer.Extensions
{
    public static class ListExtensions
    {
        public static void DeleteRandomEntry<T>(this List<T> list, Func<T, Boolean> condition = default)
        {
            if (list != default)
            {
                var baseList = list;

                if (condition != default)
                {
                    baseList = baseList.Where(condition).ToList();
                }

                int index = new Random().Next(0, baseList.Count);

                list.Remove(baseList[index]);
            }
        }

        public static T GetRandomEntry<T>(this List<T> list, Func<T, Boolean> condition = default)
        {
            T value = default(T);

            if (list != default)
            {
                var baseList = list;

                if (condition != default)
                {
                    baseList = baseList.Where(condition).ToList();
                }

                int index = new Random().Next(0, baseList.Count);

                value = baseList[index];
            }

            return value;
        }
    }
}
