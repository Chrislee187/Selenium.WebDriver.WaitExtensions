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

        public bool ToNotContain(string attrName)
        {
            return WaitFor(() => !ToContain(attrName));
        }

        public bool ToContainWithValue(string attrName, string attrValue)
        {
            return WaitFor(() => ToContain(attrName) && _webelement.GetAttribute(attrName) == attrValue);
        }

        public bool ToContainWithoutValue(string attrName, string attrValue)
        {
            return WaitFor(() => !ToContain(attrName) && _webelement.GetAttribute(attrName) != attrValue);
        }
    }
}