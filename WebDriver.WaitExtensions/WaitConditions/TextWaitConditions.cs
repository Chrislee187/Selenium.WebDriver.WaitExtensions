using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace WebDriver.WaitExtensions.WaitConditions
{
    public class TextWaitConditions : WaitConditionsBase, ITextWaitConditions
    {
        private readonly IWebElement _webelement;

        public TextWaitConditions(IWebElement webelement, int waitMs) : base(waitMs)
        {
            _webelement = webelement;
        }

        public bool ToEqual(string newText)
        {
            return WaitFor(() => _webelement.Text == newText);
        }

        public bool ToContain(string partial)
        {
            return WaitFor(() => _webelement.Text.Contains(partial));
        }
    }

    public class ElementWaitConditions : WaitConditionsBase, IElementWaitConditions
    {
        private readonly IWebElement _webelement;

        public ElementWaitConditions(IWebElement webelement, int waitMs) : base(waitMs)
        {
            _webelement = webelement;
        }

        public void ToBeVisible()
        {
            WaitFor(() => _webelement.Displayed);
        }

        public void ToNotBeVisible()
        {
            WaitFor(() => !_webelement.Displayed);
        }
    }
}