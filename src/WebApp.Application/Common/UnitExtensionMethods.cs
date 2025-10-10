namespace WebApp.Application.Common;

using static Unit;

public static class ExtensionMethods
{
    public static async Task<Unit> AsUnitTask(this Task task)
    {
        await task;
        return unit;
    }

    public static Func<TResult, Unit> AsFunc<TResult>(this Action<TResult> action)
    {
        return result =>
        {
            action(result);
            return unit;
        };
    }

    public static Func<Unit, Unit> AsFunc(this Action action)
    {
        return _ =>
        {
            action();
            return unit;
        };
    }
}