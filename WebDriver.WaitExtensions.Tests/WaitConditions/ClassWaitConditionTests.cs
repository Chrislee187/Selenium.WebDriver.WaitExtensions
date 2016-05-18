using System.IO;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace WebDriver.WaitExtensions.Tests.WaitConditions
{
    [TestFixture]
    public class ClassWaitConditionTests
    {
        private ChromeDriver _driver;
        private string _htmlFolder;

        [OneTimeSetUp]
        public void SetUp()
        {
            _driver = new ChromeDriver();
            _htmlFolder = Utils.AssemblyDirectory;
            _driver.Navigate().GoToUrl(Path.Combine(_htmlFolder, "Test.html"));
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            _driver.Close();
            _driver.Quit();
        }
        
        [Test]
        public void ShouldWaitForClassToContains()
        {
            var element = _driver.FindElement(By.Id("addClassText"));
            _driver.FindElement(By.Id("addClassButton")).Click();

            element.Wait(2500).ForClasses().ToContain("backred");
        }

        [Test]
        public void ShouldTimeoutWaitingForClassToNotContain()
        {
            var element = _driver.FindElement(By.Id("addClassText"));

            Assert.Throws<WebDriverTimeoutException>( () => element.Wait(2500).ForClasses().ToNotContain("class-that-never-existss"));
        }
        [Test]
        public void ShouldTimeoutWaitingForClassToBeAdded()
        {
            var element = _driver.FindElement(By.Id("addClassText"));
            
            Assert.Throws<WebDriverTimeoutException>(() => element.Wait(2500).ForClasses().ToContain("backred"));
        }
    }
}
