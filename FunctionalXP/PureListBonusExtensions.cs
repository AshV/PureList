using System.Collections.Generic;

namespace FunctionalXP
{
    public delegate bool FilterPredicate<in T>(T obj);

    public static class PureListBonusExtensions
    {
        public static T[] Filter<T>(this PureList<T> pureList, FilterPredicate<T> predicate)
        {
            var a= FilterApply(
                    pureList.initItems,
                    predicate,
                    new PureList<T>(),
                    pureList.initItems.Length - 1);
            return new T[0];
        }

        private static PureList<T> FilterApply<T>(T[] list, FilterPredicate<T> predicate, PureList<T> output, int n)
        {
            if (n < 0)
                return output;

            if (predicate.Invoke(list[n]))
                output.Cons(list[n]);
            return FilterApply(list, predicate, output, n - 1);
        }
    }
}