using OpenQA.Selenium;

namespace WebDriver.WaitExtensions
{
    public static class WebDriverExtensions
    {
        public static IWaitTypeSelection Wait(this IWebDriver webDriver, int ms = 500)
        {
            return new WaitTypeSelection(webDriver, ms);
        }
    }
}