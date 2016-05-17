namespace WebDriver.WaitExtensions.WaitTypeSelections
{
    public interface IClassWaitConditions
    {
        bool ToContain(string className);
        bool ToNotContain(string className);
    }
}