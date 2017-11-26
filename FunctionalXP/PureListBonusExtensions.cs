using System.Collections.Generic;

namespace FunctionalXP
{
    public delegate bool FilterPredicate<in T>(T obj);

    public static class PureListBonusExtensions
    {
        public static T[] Filter<T>(this PureList<T> pureList, FilterPredicate<T> predicate)
        {
            return FilterApply(
                    pureList.initItems,
                    predicate,
                    new List<T>(),
                    pureList.initItems.Length - 1);
        }

        private static T[] FilterApply<T>(T[] list, FilterPredicate<T> predicate, List<T> output, int n)
        {
            if (n < 0)
                return output.ToArray();

            if (predicate.Invoke(list[n]))
                output.Add(list[n]);
            return FilterApply(list, predicate, output, n - 1);
        }
    }
}