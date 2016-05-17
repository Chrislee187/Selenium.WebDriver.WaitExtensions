using OpenQA.Selenium;

namespace WebDriver.WaitExtensions.WaitConditions
{
    public interface IElementWaitConditions
    {
        IWebElement ToExist();
        void ToNotExist();
    }
}