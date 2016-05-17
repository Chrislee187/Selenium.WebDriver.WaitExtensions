using OpenQA.Selenium;
using WebDriver.WaitExtensions.WaitConditions;

namespace WebDriver.WaitExtensions.WaitTypeSelections
{
    public interface IWaitTypeSelection
    {
        IElementWaitConditions ForElement(By @by);
    }
}