namespace Core;

public static class NumericExtensions
{
    public static Nullable<T> NullIf<T>(this Nullable<T> value, T comparedValue) where T : struct, IComparable, IComparable<T>
    {
        if (value.Equals(comparedValue)) return null;
        return value;
    }

    public static Nullable<T> IsNull<T>(this Nullable<T> value, T substituteValue) where T : struct, IComparable, IComparable<T>
    {
        if (value == null) return substituteValue;
        return value;
    }

}