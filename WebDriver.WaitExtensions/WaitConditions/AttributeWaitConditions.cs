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

        public bool ToContain(string attrName)
        {
            return WaitFor(() => !string.IsNullOrEmpty(_webelement.GetAttribute(attrName)));
        }

        public bool ToContainValue(string attrName, string attrValue)
        {
            return WaitFor(() => !string.IsNullOrEmpty(_webelement.GetAttribute(attrName)) && _webelement.GetAttribute(attrName) == attrValue);
        }

        public bool ToNotContainValue(string attrName, string attrValue)
        {
            return WaitFor(() => !string.IsNullOrEmpty(_webelement.GetAttribute(attrName)) && _webelement.GetAttribute(attrName) != attrValue);
        }

        public bool ToNotContain(string attrName)
        {
            return WaitFor(() => string.IsNullOrEmpty(_webelement.GetAttribute(attrName)));
        }
    }
}