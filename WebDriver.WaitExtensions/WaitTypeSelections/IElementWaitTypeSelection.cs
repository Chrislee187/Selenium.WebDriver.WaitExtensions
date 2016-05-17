using WebDriver.WaitExtensions.WaitConditions;

namespace WebDriver.WaitExtensions.WaitTypeSelections
{
    public interface IElementWaitTypeSelection
    {
        ITextWaitConditions ForText(string attrName);
    }
}