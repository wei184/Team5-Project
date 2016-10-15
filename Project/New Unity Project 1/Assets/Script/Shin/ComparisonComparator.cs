using System;
using System.Collections.Generic;

public sealed class ComparisonComparer<T> : IComparer<T>
{
    readonly Comparison<T> comparison;

    public ComparisonComparer(Comparison<T> comparison)
    {
        if (comparison == null)
            throw new ArgumentNullException("comparison");

        this.comparison = comparison;
    }

    public int Compare(T x, T y)
    {
        return comparison(x, y);
    }
}
