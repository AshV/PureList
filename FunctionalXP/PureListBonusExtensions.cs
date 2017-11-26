using System.Diagnostics.Contracts;

namespace FunctionalXP
{
    public delegate bool FilterPredicate<in T>(T obj);

    public delegate T MapFunction<in T1, out T>();
    public delegate T MapFunction<in T1, in T2, out T>();
    public delegate T MapFunction<in T1, in T2, in T3, out T>();
    public delegate T MapFunction<in T1, in T2, in T3, in T4, out T>();
    public delegate T MapFunction<in T1, in T2, in T3, in T4, in T5, out T>();

    public static class PureListBonusExtensions
    {
        [Pure]
        public static PureList<T> Filter<T>(this PureList<T> pureList, FilterPredicate<T> predicate) =>
                    FilterApply(
                        pureList,
                        predicate,
                        new PureList<T>(),
                        pureList.Length - 1);

        [Pure]
        private static PureList<T> FilterApply<T>(PureList<T> list, FilterPredicate<T> predicate, PureList<T> output, int n) =>
            (n < 0) ? output : FilterApply(
                list,
                predicate,
                predicate(list[n]) ? output.Cons(list[n]) : output,
                n - 1);

    }
}