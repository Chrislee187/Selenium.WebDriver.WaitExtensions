using System.Linq;
using OpenQA.Selenium;
using WebDriver.WaitExtensions.WaitTypeSelections;

namespace WebDriver.WaitExtensions.WaitConditions
{
    public class ClassWaitConditions : WaitConditionsBase, IClassWaitConditions
    {
        private readonly IWebElement _webelement;

        public ClassWaitConditions(IWebElement webelement, int delayMs) : base(delayMs)
        {
            _webelement = webelement;
        }

        public bool ToContain(string className)
        {
            return WaitFor(() => _webelement.GetAttribute("class").Split(' ').Contains(className));
        }
        public bool ToNotContain(string className)
        {
            return WaitFor(() => !ToContain(className));
        }
    }
}