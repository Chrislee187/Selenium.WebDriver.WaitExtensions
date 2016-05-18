using System.IO;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace WebDriver.WaitExtensions.Tests.WaitConditions
{
    [TestFixture]
    public class ElementWaitConditionTests
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
        public void ShouldWaitForElementToBeVisible()
        {
            var element = _driver.FindElement(By.Id("elementToShow"));
            _driver.FindElement(By.Id("showElementButton")).Click();

            element.Wait(2500).ForElement().ToBeVisible();
        }

        [Test]
        public void ShouldTimeoutWaitingForElementToBeVisible()
        {
            var element = _driver.FindElement(By.Id("neverVisibleElement"));

            Assert.Throws<WebDriverTimeoutException>(()=> element.Wait(25).ForElement().ToBeVisible());
        }

        [Test]
        public void ShouldWaitForElementToNotBeVisible()
        {
            var element = _driver.FindElement(By.Id("elementToHide"));
            _driver.FindElement(By.Id("hideElementButton")).Click();

            element.Wait(2500).ForElement().ToBeInvisible();
        }

        [Test]
        public void ShouldTimeoutWaitingElementToNotBeVisible()
        {
            var element = _driver.FindElement(By.Id("alwaysVisibleElement"));

            element.Wait(2500).ForElement().ToBeInvisible();
        }

        [Test]
        public void ShouldWaitForElementToBeDisabled()
        {
            var element = _driver.FindElement(By.Id("elementToDisable"));
            _driver.FindElement(By.Id("disableElementButton")).Click();

            element.Wait(2500).ForElement().ToBeDisabled();
        }

        [Test]
        public void ShouldTimeoutWaitingForElementToBeDisabled()
        {
            var element = _driver.FindElement(By.Id("createdSpanTestButton"));

            Assert.Throws<WebDriverTimeoutException>( () =>
            element.Wait(2500).ForElement().ToBeDisabled());
        }

        [Test]
        public void ShouldWaitForElementToBeEnabled()
        {
            var element = _driver.FindElement(By.Id("elementToEnable"));
            _driver.FindElement(By.Id("enableElementButton")).Click();

            element.Wait(2500).ForElement().ToBeEnabled();
        }

        [Test]
        public void ShouldTimeoutWaitingForElementToBeEnabled()
        {
            var element = _driver.FindElement(By.Id("alwaysDisabledElement"));

            Assert.Throws<WebDriverTimeoutException>( () =>element.Wait(2500).ForElement().ToBeEnabled());
        }
    }
}
