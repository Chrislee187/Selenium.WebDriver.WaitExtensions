namespace WebDriver.WaitExtensions.WaitConditions
{
    public interface ITextWaitConditions
    {
        bool ToEqual(string newText);
        bool ToContain(string partial);
    }
}