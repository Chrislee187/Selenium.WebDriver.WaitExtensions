using OpenQA.Selenium;

namespace WebDriver.WaitExtensions
{
    public class ElementWaitTypeSelection : IElementWaitTypeSelection
    {
        private readonly IWebElement _webelement;
        private readonly int _delayMs;

        public ElementWaitTypeSelection(IWebElement webelement, int delayMs)
        {
            _webelement = webelement;
            _delayMs = delayMs;
        }

        public ITextWaitConditions ForText(string attrName)
        {
            return new TextWaitConditions(_webelement, _delayMs, attrName);
        }
    }
}