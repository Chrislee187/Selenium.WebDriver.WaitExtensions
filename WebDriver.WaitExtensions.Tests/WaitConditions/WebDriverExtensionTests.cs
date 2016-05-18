using NUnit.Framework;
using OpenQA.Selenium;

namespace WebDriver.WaitExtensions.Tests.WaitConditions
{
    [TestFixture]
    public class WebDriverExtensionTests
    {
        private readonly IWebDriver Driver = MySetUpClass.Driver;

        [SetUp]
        public void SetUp()
        {
            Driver.Navigate().Refresh();
        }
        [Test]
        public void ShouldWaitForElementToExist()
        {
            Driver.FindElement(By.Id("createdSpanTestButton")).Click();

            var element = Driver.Wait(2500).ForElement(By.Id("createdSpan")).ToExist();

            Assert.That(element.TagName, Is.EqualTo("span"));
            Assert.That(element.GetAttribute("id"), Is.EqualTo("createdSpan"));
        }

        [Test]
        public void ShouldThrowWhenTimeoutWaitingForElementToExist()
        {
            Assert.Throws<WebDriverTimeoutException>(() => Driver.Wait().ForElement(By.Id("non-existing-element")).ToExist());
        }

        [Test]
        public void ShouldWaitForElementToNotExist()
        {
            Driver.FindElement(By.Id("removedSpanTestButton")).Click();
            Driver.Wait(2500).ForElement(By.Id("elementToBeRemoved")).ToNotExist();
        }

        [Test]
        public void ShouldThrowWhenTimeoutWaitingForElementToNotExist()
        {
            Assert.Throws<WebDriverTimeoutException>(() => Driver.Wait().ForElement(By.TagName("HEAD")).ToNotExist());
        }
    }
}
