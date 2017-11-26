using System.Diagnostics.Contracts;

namespace FunctionalXP
{
    public class PureList<T>
    {
        private readonly T[] initItems;

        public int Length { get; }

        [Pure]
        public PureList(params T[] items)
        {
            initItems = items;
            Length = items.Length;
        }

        public T this[int index]
        {
            get
            {
                return initItems[index];
            }
        }
    }
}