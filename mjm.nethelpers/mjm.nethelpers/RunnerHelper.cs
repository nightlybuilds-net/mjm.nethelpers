using System;
using System.Threading.Tasks;

namespace mjm.nethelpers
{
    public static class RunnerHelper
    {
        /// <summary>
        /// > Run the given action and if it throws an exception, run the given exception handler
        /// </summary>
        /// <param name="run">A delegate that represents a method that takes no parameters and returns void.</param>
        /// <param name="onException">The action to run if an exception is thrown.</param>
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
        
        /// <summary>
        /// > Run a function and if it throws an exception, run another function with the exception as a parameter
        /// </summary>
        /// <param name="run">The task to run</param>
        /// <param name="onException">The function to run if an exception is thrown.</param>
        /// <returns>
        /// A Task
        /// </returns>
        public static Task RunAndManageException(Func<Task> run, Func<Exception, Task> onException)
        {
            try
            {
                return run?.Invoke();
            }
            catch (Exception e)
            {
                return onException?.Invoke(e);
            }
        }

        /// <summary>
        /// "Run the given function and return its result, or if an exception is thrown, return the result of the given
        /// exception handler."
        /// 
        /// The above function is a generic function, so it can be used with any type of function
        /// </summary>
        /// <param name="run">The function to run.</param>
        /// <param name="onException">A function that takes an exception and returns a value of type T.</param>
        /// <returns>
        /// The result of the run function, or the result of the onException function.
        /// </returns>
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
    
        /// <summary>
        /// "Run the given function, and if it throws an exception, run the given exception handler instead."
        /// 
        /// The above function is a bit more complicated than the previous one, but it's still pretty simple. It takes two
        /// parameters: a function to run, and a function to run if the first function throws an exception. It then runs the
        /// first function, and if it throws an exception, it runs the second function instead
        /// </summary>
        /// <param name="run">The function that you want to run.</param>
        /// <param name="onException">This is the function that will be called if an exception is thrown.</param>
        /// <returns>
        /// The result of the run() function or the result of the onException() function.
        /// </returns>
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
}