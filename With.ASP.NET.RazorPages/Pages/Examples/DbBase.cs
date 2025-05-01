namespace With.ASP.NET.RazorPages.Pages.Examples;

public abstract class DbBase<T>
{
    protected static List<T>? TheList;

    public static void Reset() => TheList = null;
}
