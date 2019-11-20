using System;
using System.Threading;

namespace Amsel.Framework.Streamlabs.OBS.Tests.Utilities
{
    public static class TimeoutUtils
    {
        public static void WhileTimeout(TimeSpan timeSpan) {
            DateTime start = DateTime.UtcNow;
            while (start.Add(timeSpan) > DateTime.UtcNow) { }
        }

        public static bool RetryUntilSuccessOrTimeout(Func<bool> task, TimeSpan timeSpan) {
            var success = false;
            var elapsed = 0;
            while (!success && elapsed < timeSpan.TotalMilliseconds) {
                Thread.Sleep(1000);
                elapsed += 1000;
                success = task();
            }

            return success;
        }
    }
}