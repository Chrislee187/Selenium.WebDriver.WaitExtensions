using OpenQA.Selenium;

namespace WebDriver.WaitExtensions
{
    public interface IElementWaitConditions
    {
        IWebElement ToExist();
        void ToNotExist();
    }
}