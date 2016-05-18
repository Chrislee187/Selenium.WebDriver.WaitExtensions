namespace WebDriver.WaitExtensions.WaitConditions
{
    public interface IElementWaitConditions
    {
        void ToBeVisible();
        void ToBeInvisible();
        void ToBeDisabled();
        void ToBeEnabled();
    }
}