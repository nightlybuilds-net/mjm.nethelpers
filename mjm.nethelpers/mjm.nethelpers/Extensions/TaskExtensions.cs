using System;
using System.Threading;
using System.Threading.Tasks;

namespace mjm.nethelpers.Extensions
{
    public static class TaskExtensions
    {
        /// <summary>
        /// Add Timeout after 
        /// </summary>
        /// <param name="task"></param>
        /// <param name="timeout"></param>
        /// <typeparam name="TResult"></typeparam>
        /// <returns></returns>
        /// <exception cref="TimeoutException"></exception>
        public static async Task<TResult> TimeoutAfter<TResult>(this Task<TResult> task, TimeSpan timeout)
        {
            using var timeoutCancellationTokenSource = new CancellationTokenSource();
            var completedTask = await Task.WhenAny(task, Task.Delay(timeout, timeoutCancellationTokenSource.Token));
            if (completedTask == task) {
                timeoutCancellationTokenSource.Cancel();
                return await task;  // Very important in order to propagate exceptions
            } else {
                throw new TimeoutException("The operation has timed out.");
            }
        }
        
        /// <summary>
        /// Add Timeout after 
        /// </summary>
        /// <param name="task"></param>
        /// <param name="timeout"></param>
        /// <typeparam name="TResult"></typeparam>
        /// <returns></returns>
        /// <exception cref="TimeoutException"></exception>
        public static async Task TimeoutAfter(this Task task, TimeSpan timeout)
        {
            using var timeoutCancellationTokenSource = new CancellationTokenSource();
            var completedTask = await Task.WhenAny(task, Task.Delay(timeout, timeoutCancellationTokenSource.Token));
            if (completedTask == task) {
                timeoutCancellationTokenSource.Cancel();
                await task;  // Very important in order to propagate exceptions
            } else {
                throw new TimeoutException("The operation has timed out.");
            }
        }
    }
}