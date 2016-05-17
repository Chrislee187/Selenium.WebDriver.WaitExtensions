using System;
using System.Diagnostics;
using System.Threading;
using OpenQA.Selenium;

namespace WebDriver.WaitExtensions
{
    public class TextWaitConditions : ITextWaitConditions
    {
        private readonly IWebElement _webelement;
        private readonly int _waitMs;
        private readonly string _attrName;
        private readonly TimeSpan _interval = TimeSpan.FromMilliseconds(25);

        public TextWaitConditions(IWebElement webelement, int waitMs, string attrName)
        {
            _webelement = webelement;
            _waitMs = waitMs;
            _attrName = attrName;
        }

        public bool ToEqual(string newText)
        {
            return TextEquality(() => _webelement.Text, newText);
        }

        private bool TextEquality(Func<string> text, string newText)
        {
            var stopwatch = new Stopwatch();

            stopwatch.Start();
            string attrValue = "";

            Func<bool> testNameAttr = () => text() == newText;

            if (testNameAttr()) return true;

            while (stopwatch.ElapsedMilliseconds <= _waitMs)
            {
                if (testNameAttr()) return true;
                Thread.Sleep(_interval);
            }

            throw new WebDriverTimeoutException($"Waiting for attribute {_attrName} to equal '{newText}' but was '{attrValue}'.");
        }
    }
}