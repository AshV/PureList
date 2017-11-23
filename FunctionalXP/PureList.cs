using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunctionalXP
{
    [Pure]
    public class PureList<T>
    {
        public readonly T[] initItems;

        public PureList(params T[] items)
        {
            initItems = items;
        }
    }
}