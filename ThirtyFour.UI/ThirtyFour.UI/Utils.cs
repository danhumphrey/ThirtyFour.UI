using System;
using System.Threading;

namespace ThirtyFour.UI
{
    /// <summary>
    /// Utils class
    /// </summary>
    public class Utils
    {
        /// <summary>
        /// Retries a task every 'interval' milliseconds until timeout or success
        /// </summary>
        /// <param name="timeout">the timeout</param>
        /// <param name="interval">the interval for retrying</param>
        /// <param name="task">the task to retry</param>
        /// <returns>Boolean - tru if the task succeeded</returns>
        public static bool RetryUntilTimeout(TimeSpan timeout, TimeSpan interval, Func<bool> task)
        {
            bool success = false;
            double elapsed = 0;
            while ((!success) && (elapsed < timeout.TotalMilliseconds))
            {
                Thread.Sleep(interval);
                elapsed += interval.TotalMilliseconds;
                success = task();
            }
            return success;
        }
    }
}
