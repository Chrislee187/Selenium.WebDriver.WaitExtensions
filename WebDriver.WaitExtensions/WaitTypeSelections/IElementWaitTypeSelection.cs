using WebDriver.WaitExtensions.WaitConditions;

namespace WebDriver.WaitExtensions.WaitTypeSelections
{
    public interface IElementWaitTypeSelection
    {
        ITextWaitConditions ForText();
        IClassWaitConditions ForClasses();
        IAttributeWaitConditions ForAttributes();
        IElementWaitConditions ForElement();
    }
}