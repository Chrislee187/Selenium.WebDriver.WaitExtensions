using NUnit.Framework;
using OpenQA.Selenium;

namespace Selenium.WebDriver.WaitExtensions.Tests.WaitConditions
{
    [TestFixture]
    public class ElementWaitConditionTests
    {
        private readonly IWebDriver Driver = MySetUpClass.Driver;

        [SetUp]
        public void SetUp()
        {
            Driver.Navigate().Refresh();
        }
        [Test]
        public void ShouldWaitForElementToBeVisible()
        {
            var element = Driver.FindElement(By.Id("elementToShow"));
            Driver.FindElement(By.Id("showElementButton")).Click();

            element.Wait(2500).ForElement().ToBeVisible();
        }

        [Test]
        public void ShouldTimeoutWaitingForElementToBeVisible()
        {
            var element = Driver.FindElement(By.Id("neverVisibleElement"));

            Assert.Throws<WebDriverTimeoutException>(()=> element.Wait(25).ForElement().ToBeVisible());
        }

        [Test]
        public void ShouldWaitForElementToNotBeVisible()
        {
            var element = Driver.FindElement(By.Id("elementToHide"));
            Driver.FindElement(By.Id("hideElementButton")).Click();

            element.Wait(2500).ForElement().ToBeInvisible();
        }

        [Test]
        public void ShouldTimeoutWaitingElementToNotBeVisible()
        {
            var element = Driver.FindElement(By.Id("alwaysVisibleElement"));

            element.Wait(2500).ForElement().ToBeInvisible();
        }

        [Test]
        public void ShouldWaitForElementToBeDisabled()
        {
            var element = Driver.FindElement(By.Id("elementToDisable"));
            Driver.FindElement(By.Id("disableElementButton")).Click();

            element.Wait(2500).ForElement().ToBeDisabled();
        }

        [Test]
        public void ShouldTimeoutWaitingForElementToBeDisabled()
        {
            var element = Driver.FindElement(By.Id("createdSpanTestButton"));

            Assert.Throws<WebDriverTimeoutException>( () =>
            element.Wait(2500).ForElement().ToBeDisabled());
        }

        [Test]
        public void ShouldWaitForElementToBeEnabled()
        {
            var element = Driver.FindElement(By.Id("elementToEnable"));
            Driver.FindElement(By.Id("enableElementButton")).Click();

            element.Wait(2500).ForElement().ToBeEnabled();
        }

        [Test]
        public void ShouldTimeoutWaitingForElementToBeEnabled()
        {
            var element = Driver.FindElement(By.Id("alwaysDisabledElement"));

            Assert.Throws<WebDriverTimeoutException>( () =>element.Wait(2500).ForElement().ToBeEnabled());
        }

        [Test]
        public void ShouldWaitForElementToBeSelected()
        {
            var element = Driver.FindElement(By.Id("option2"));

            Driver.FindElement(By.Id("selectOption2Button")).Click();

            element.Wait(2500).ForElement().ToBeSelected();
        }
        [Test]
        public void ShouldTimeoutWaitingForElementToBeSelected()
        {
            Driver.Navigate().Refresh();
            var element = Driver.FindElement(By.Id("option2"));

            Assert.Throws<WebDriverTimeoutException>( () => element.Wait(2500).ForElement().ToBeSelected());
        }

        [Test]
        public void ShouldWaitForElementToNotBeSelected()
        {
            Driver.Navigate().Refresh();
            var element = Driver.FindElement(By.Id("option1"));

            Driver.FindElement(By.Id("selectOption2Button")).Click();

            element.Wait(2500).ForElement().ToNotBeSelected();
        }
        [Test]
        public void ShouldTimeoutWaitingForElementToNotBeSelected()
        {
            Driver.Navigate().Refresh();
            var element = Driver.FindElement(By.Id("option1"));

            Assert.Throws<WebDriverTimeoutException>(() => element.Wait(2500).ForElement().ToNotBeSelected());
        }

    }
}
