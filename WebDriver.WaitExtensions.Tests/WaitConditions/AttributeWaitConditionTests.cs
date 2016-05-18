using System.IO;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace WebDriver.WaitExtensions.Tests.WaitConditions
{
    [TestFixture]
    public class AttributeWaitConditionTests
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
        public void ShouldWaitForAttributeToBeAdded()
        {
            var element = _driver.FindElement(By.Id("addAttributeElement"));
            _driver.FindElement(By.Id("addAttributeButton")).Click();

            element.Wait(2500).ForAttributes().ToContain("test");
        }

        [Test]
        public void ShouldWaitForAttributeToContainValue()
        {
            var element = _driver.FindElement(By.Id("addAttributeElement"));
            _driver.FindElement(By.Id("addAttributeButton")).Click();
            
            element.Wait(2500).ForAttributes().ToContainWithValue("test","MyTest");
        }

        [Test]
        public void ShouldTimeoutWaitingForAttributeToNotContainValue()
        {
            var element = _driver.FindElement(By.Id("addAttributeElement"));
            Assert.Throws<WebDriverTimeoutException>( ()=> element.Wait(2500).ForAttributes().ToContainWithoutValue("test", "never-set-value"));
        }
        [Test]
        public void ShouldTimeoutWaitingForAttributeToBeAdded()
        {
            var element = _driver.FindElement(By.Id("addAttributeElement"));
Assert.Throws<WebDriverTimeoutException>(() => element.Wait(25).ForAttributes().ToNotContain("attribute-that-never-exists"));

        }
    }
}
