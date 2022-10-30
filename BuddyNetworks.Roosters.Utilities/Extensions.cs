namespace BuddyNetworks.Roosters.Utilities;

public static class Extensions
{
    public static double ToRadians(this double val)
    {
        return (Math.PI / 180) * val;
    }

    public static bool IsBetween<T>(this T item, T start, T end)
    {
        return Comparer<T>.Default.Compare(item, start) >= 0
            && Comparer<T>.Default.Compare(item, end) <= 0;
    }

    public static int ToUnixTimestamp(this DateTime value)
    {
        return (int)Math.Truncate((value.ToUniversalTime().Subtract(new DateTime(1970, 1, 1))).TotalSeconds);
    }

    public static DateTime FromUnixTimestamp(this long value)
    {
        return new DateTime(1970, 1, 1).AddSeconds(value);
    }
}

