using System.Collections.Generic;
using System.Diagnostics.Contracts;

namespace FunctionalXP
{
    public static class PureListExtensions
    {
        [Pure]
        public static T Head<T>(this PureList<T> purelist) => purelist.initItems.Length > 0 ? purelist.initItems[0] : default(T);

        [Pure]
        public static T[] Tail<T>(this PureList<T> pureList) => CopyTail(
            pureList.initItems,
            new T[pureList.initItems.Length - 1],
            pureList.initItems.Length - 2);

        [Pure]
        public static T[] Drop<T>(this PureList<T> pureList, int n) => Copy(
                pureList.initItems,
                new T[pureList.initItems.Length - n],
                n,
                pureList.initItems.Length - 1,
                pureList.initItems.Length - n - 1);

        [Pure]
        public static T[] Reverse<T>(this PureList<T> pureList) => ReverseList<T>(
                pureList.initItems,
                new T[pureList.initItems.Length],
                0,
                pureList.initItems.Length - 1);

        [Pure]
        public static T[] Cons<T>(this PureList<T> pureList, T element)
        {
            var consContent = new T[pureList.initItems.Length + 1];
            consContent[0] = element;
            return CopyCons(
                pureList.initItems,
                consContent,
                pureList.initItems.Length - 1);
        }
        
        [Pure]
        private static T[] ReverseList<T>(T[] list, T[] reverseList, int start, int end)
        {
            if (start > end)
                return reverseList;
            reverseList[start] = list[end];
            reverseList[end] = list[start];
            return ReverseList(list, reverseList, start + 1, end - 1);
        }

        [Pure]
        private static T[] Copy<T>(T[] source, T[] destination, int sourceStart, int sourceEnd, int destinationEnd)
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
        private static T[] CopyCons<T>(T[] s, T[] d, int N)
        {
            if (N < 0) return d;
            d[N + 1] = s[N];
            return CopyCons(s, d, --N);
        }

        [Pure]
        private static T[] CopyTail<T>(T[] s, T[] d, int N)
        {
            if (N < 0) return d;
            d[N] = s[N + 1];
            return CopyTail(s, d, --N);
        }
    }
}