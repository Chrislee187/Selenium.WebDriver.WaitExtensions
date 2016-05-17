using OpenQA.Selenium;

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
}