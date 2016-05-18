using System.IO;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;

namespace WebDriver.WaitExtensions.Tests
{
    [SetUpFixture]
    public class MySetUpClass
    {
        public static ChromeDriver Driver;

        [OneTimeSetUp]
        public static void RunBeforeAnyTests()
        {
            Driver = new ChromeDriver();
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
