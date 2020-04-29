using System;
using System.Threading;

namespace Amsel.Framework.Streamlabs.OBS.Tests.Utilities {
    public static class TimeoutUtils
    {
        public static bool RetryUntilSuccessOrTimeout(Func<bool> task, TimeSpan timeSpan) {
            bool success = false;
            int elapsed = 0;
            while(!success && (elapsed < timeSpan.TotalMilliseconds)) {
                Thread.Sleep(1000);
                elapsed += 1000;
                success = task();
            }

            return success;
        }

        public static void WhileTimeout(TimeSpan timeSpan) {
            DateTime start = DateTime.UtcNow;
            while(start.Add(timeSpan) > DateTime.UtcNow) {
            }
        }
    }
}