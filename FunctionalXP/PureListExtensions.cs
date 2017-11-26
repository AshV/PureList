using System.Collections.Generic;
using System.Diagnostics.Contracts;

namespace FunctionalXP
{
    public static class PureListExtensions
    {
        [Pure]
        public static T Head<T>(this PureList<T> purelist) => purelist.Length > 0 ? purelist[0] : default(T);

        [Pure]
        public static PureList<T> Tail<T>(this PureList<T> pureList) => new PureList<T>(CopyTail(
            pureList,
            new T[pureList.Length - 1],
            pureList.Length - 2));

        [Pure]
        public static PureList<T> Drop<T>(this PureList<T> pureList, int n) => new PureList<T>(Copy(
                pureList,
                new T[pureList.Length - n],
                n,
                pureList.Length - 1,
                pureList.Length - n - 1));

        [Pure]
        public static PureList<T> Reverse<T>(this PureList<T> pureList) => new PureList<T>(ReverseList(
                pureList,
                new T[pureList.Length],
                0,
                pureList.Length - 1));

        [Pure]
        public static PureList<T> Cons<T>(this PureList<T> pureList, T element)
        {
            var consContent = new T[pureList.Length + 1];
            consContent[0] = element;
            return new PureList<T>(CopyCons(
                pureList,
                consContent,
                pureList.Length - 1));
        }

        [Pure]
        private static T[] ReverseList<T>(PureList<T> list, T[] reverseList, int start, int end)
        {
            if (start > end)
                return reverseList;
            reverseList[start] = list[end];
            reverseList[end] = list[start];
            return ReverseList(list, reverseList, start + 1, end - 1);
        }

        [Pure]
        private static T[] Copy<T>(PureList<T> source, T[] destination, int sourceStart, int sourceEnd, int destinationEnd)
        {
            if (sourceStart > sourceEnd)
                return destination;
            destination[destinationEnd] = source[sourceEnd];
            return Copy(
                source,
                destination,
                sourceStart,
                sourceEnd - 1,
                destinationEnd - 1);
        }

        [Pure]
        private static T[] CopyCons<T>(PureList<T> s, T[] d, int N)
        {
            if (N < 0) return d;
            d[N + 1] = s[N];
            return CopyCons(s, d, --N);
        }

        [Pure]
        private static T[] CopyTail<T>(PureList<T> s, T[] d, int N)
        {
            if (N < 0) return d;
            d[N] = s[N + 1];
            return CopyTail(s, d, --N);
        }
    }
}