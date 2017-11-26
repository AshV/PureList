using System.Collections.Generic;

namespace FunctionalXP
{
    public delegate bool FilterPredicate<in T>(T obj);

    public static class PureListBonusExtensions
    {
        public static PureList<T> Filter<T>(this PureList<T> pureList, FilterPredicate<T> predicate)
        {
            return FilterApply(
                      pureList,
                      predicate,
                      new PureList<T>(),
                      pureList.Length - 1);
        }

        private static PureList<T> FilterApply<T>(PureList<T> list, FilterPredicate<T> predicate, PureList<T> output, int n)
        {
            if (n < 0)
                return output;

            if (predicate.Invoke(list[n]))
                output.Cons(list[n]);
            return FilterApply(list, predicate, output, n - 1);
        }
    }
}