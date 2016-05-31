using OpenQA.Selenium;
using WebDriver.WaitExtensions.WaitConditions;

namespace WebDriver.WaitExtensions.WaitTypeSelections
{
    public interface IWaitTypeSelection
    {
        IWebElementWaitConditions ForElement(By @by);
        IWebPageWaitConditions ForPage();
    }
}