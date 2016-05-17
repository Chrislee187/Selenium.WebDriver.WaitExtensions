using OpenQA.Selenium;

namespace WebDriver.WaitExtensions.WaitConditions
{
    public interface IAttributeWaitConditions
    {
        bool ToContain(string attrName);
        bool ToContainValue(string attrName, string attrValue);
        bool ToNotContain(string attrName);
        bool ToNotContainValue(string attrName, string attrValue);
    }
}