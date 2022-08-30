using System;
using System.Threading.Tasks;

namespace mjm.nethelpers;

public static class RunnerHelper
{
    public static void RunAndManageException(Action run, Action<Exception> onException)
    {
        try
        {
            run?.Invoke();
        }
        catch (Exception e)
        {
            onException?.Invoke(e);
        }
    }

    public static T RunAndManageException<T>(Func<T> run, Func<Exception, T> onException)
    {
        try
        {
            return run.Invoke();
        }
        catch (Exception e)
        {
            return onException.Invoke(e);
        }
    }
    
    public static async Task<T> RunAndManageException<T>(Func<Task<T>> run, Func<Exception, Task<T>> onException)
    {
        try
        {
            return await run();
        }
        catch (Exception e)
        {
            return await onException(e);
        }
    }
}