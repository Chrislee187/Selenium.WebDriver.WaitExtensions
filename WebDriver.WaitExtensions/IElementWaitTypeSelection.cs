namespace WebDriver.WaitExtensions
{
    public interface IElementWaitTypeSelection
    {
        ITextWaitConditions ForText(string attrName);
    }
}