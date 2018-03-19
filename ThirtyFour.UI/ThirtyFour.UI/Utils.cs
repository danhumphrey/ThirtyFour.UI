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
        /// Retries a task every 500 milliseconds until timeout or success
        /// </summary>
        /// <param name="timeout">the timeout</param>
        /// <param name="task">the task to retry</param>
        /// <returns>Boolean - tru if the task succeeded</returns>
        public static bool RetryUntilTimeout(TimeSpan timeout,  Func<bool> task)
        {
            bool success = false;
            int elapsed = 0;
            while ((!success) && (elapsed < timeout.TotalMilliseconds))
            {
                Thread.Sleep(500);
                elapsed += 500;
                success = task();
            }
            return success;
        }
    }
}
