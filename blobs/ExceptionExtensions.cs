namespace blobs;

public static class ExceptionExtensions
{
    public static void ThrowIfNull(this object obj, string paramName)
    {
        if (obj == null)
            throw new ArgumentNullException(paramName);
    }
}