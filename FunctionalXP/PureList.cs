using System.Diagnostics.Contracts;

namespace FunctionalXP
{
    public class PureList<T>
    {
        public readonly T[] initItems;

        [Pure]
        public PureList(params T[] items)
        {
            initItems = items;
        }
    }
}