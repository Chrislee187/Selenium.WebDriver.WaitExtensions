using System.IO;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;

namespace Selenium.WebDriver.WaitExtensions.Tests
{
    [SetUpFixture]
    public class MySetUpClass
    {
        public static ChromeDriver Driver;

        [OneTimeSetUp]
        public static void RunBeforeAnyTests()
        {
            // TODO: Not sure why we need to supply the directory, worked with the default service previously
            Driver = new ChromeDriver(ChromeDriverService.CreateDefaultService(Utils.AssemblyDirectory));
            NavigateToTestPage();
        }

        public static void NavigateToTestPage()
        {
            Driver.Navigate().GoToUrl(Path.Combine(Utils.AssemblyDirectory, "Test.html"));
        }

        [OneTimeTearDown]
        public static void RunAfterAnyTests()
        {
            Driver.Close();
            Driver.Quit();
        }
    }
}
