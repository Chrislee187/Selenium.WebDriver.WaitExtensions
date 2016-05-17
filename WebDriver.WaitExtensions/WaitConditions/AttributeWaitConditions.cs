using OpenQA.Selenium;

namespace WebDriver.WaitExtensions.WaitConditions
{
    public class AttributeWaitConditions : WaitConditionsBase, IAttributeWaitConditions
    {
        private readonly IWebElement _webelement;

        public AttributeWaitConditions(IWebElement webelement, int delayMs) : base(delayMs)
        {
            _webelement = webelement;
        }

        public bool ToContain(string className)
        {
            return WaitFor(() => !string.IsNullOrEmpty(_webelement.GetAttribute(className)));
        }

        public bool ToNotContain(string className)
        {
            return WaitFor(() => string.IsNullOrEmpty(_webelement.GetAttribute(className)));
        }
    }
}