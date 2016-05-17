using System;
using System.Diagnostics;
using System.Threading;
using OpenQA.Selenium;

namespace WebDriver.WaitExtensions.WaitConditions
{
    public abstract class WaitConditionsBase
    {
        protected readonly int _waitMs;
        private readonly TimeSpan _interval = TimeSpan.FromMilliseconds(25);

        protected WaitConditionsBase(int waitMs) : base()
        {
            _waitMs = waitMs;
        }
        protected bool WaitFor(Func<bool> test)
        {
            var stopwatch = new Stopwatch();

            stopwatch.Start();

            if (test()) return true;

            while (stopwatch.ElapsedMilliseconds <= _waitMs)
            {
                if (test()) return true;
                Thread.Sleep(_interval);
            }

            throw new WebDriverTimeoutException($"Waiting for Text to change.");
        }
    }
}