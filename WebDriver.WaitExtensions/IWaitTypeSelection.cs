using OpenQA.Selenium;

namespace WebDriver.WaitExtensions
{
    public interface IWaitTypeSelection
    {
        IElementWaitConditions ForElement(By @by);
    }
}