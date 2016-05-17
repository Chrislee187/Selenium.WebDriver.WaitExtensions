using OpenQA.Selenium;

namespace WebDriver.WaitExtensions.WaitConditions
{
    public interface IWebElementWaitConditions
    {
        IWebElement ToExist();
        void ToNotExist();
    }
}