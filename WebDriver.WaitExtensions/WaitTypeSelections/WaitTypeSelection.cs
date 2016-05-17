using OpenQA.Selenium;
using WebDriver.WaitExtensions.WaitConditions;

namespace WebDriver.WaitExtensions.WaitTypeSelections
{
    public class WaitTypeSelection : IWaitTypeSelection
    {
        private readonly IWebDriver _webDriver;
        private readonly int _waitMs;

        public WaitTypeSelection(IWebDriver webDriver, int waitMs)
        {
            _webDriver = webDriver;
            _waitMs = waitMs;
        }

        public IElementWaitConditions ForElement(By @by)
        {
            return new ElementWaitConditions(_webDriver, _waitMs, @by);
        }
    }
}