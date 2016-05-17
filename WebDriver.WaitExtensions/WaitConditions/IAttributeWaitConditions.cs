using OpenQA.Selenium;

namespace WebDriver.WaitExtensions.WaitConditions
{
    public interface IAttributeWaitConditions
    {
        bool ToContain(string className);
        bool ToNotContain(string className);
    }
}