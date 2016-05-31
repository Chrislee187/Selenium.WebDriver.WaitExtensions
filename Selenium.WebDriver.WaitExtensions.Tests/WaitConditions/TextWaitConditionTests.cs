using NUnit.Framework;
using OpenQA.Selenium;

namespace Selenium.WebDriver.WaitExtensions.Tests.WaitConditions
{
    [TestFixture]
    public class TextWaitConditionTests
    {
        private readonly IWebDriver Driver = MySetUpClass.Driver;

        [SetUp]
        public void SetUp()
        {
            Driver.Navigate().Refresh();
        }

        [Test]
        public void ShouldWaitForTextToEqual()
        {
            var element = Driver.FindElement(By.Id("changeText"));
            Driver.FindElement(By.Id("changeTextButton")).Click();

            element.Wait(2500).ForText().ToEqual("New Text");

        }

        [Test]
        public void ShouldTimeoutWaitingForTextToEqual()
        {
            var element = Driver.FindElement(By.Id("changeText"));

            Assert.Throws<WebDriverTimeoutException>(() => element.Wait().ForText().ToEqual("Text That Never Appears"));
        }

        [Test]
        public void ShouldWaitForTextToNotEqual()
        {
            Driver.Navigate().Refresh();

            var element = Driver.FindElement(By.Id("changeText"));
            Driver.FindElement(By.Id("changeTextButton")).Click();

            element.Wait(2500).ForText().ToNotEqual("Original Text");
        }

        [Test]
        public void ShouldTimeoutWaitingForTextToNotEqual()
        {
            var element = Driver.FindElement(By.Id("changeText"));

            Assert.Throws<WebDriverTimeoutException>(() => element.Wait().ForText().ToEqual("will never equal this"));

        }
        [Test]
        public void ShouldWaitForTextToContain()
        {
            Driver.Navigate().Refresh();

            var element = Driver.FindElement(By.Id("changeText"));
            Driver.FindElement(By.Id("changeTextButton")).Click();

            element.Wait(2500).ForText().ToContain("ew T");

        }

        [Test]
        public void ShouldTimeoutWaitingForTextToContain()
        {
            Driver.Navigate().Refresh();

            var element = Driver.FindElement(By.Id("changeText"));

            Assert.Throws<WebDriverTimeoutException>(() => element.Wait(2500).ForText().ToContain("xy"));
        }
        [Test]
        public void ShouldWaitForTextToNotContains()
        {
            Driver.Navigate().Refresh();

            var element = Driver.FindElement(By.Id("changeText"));

            element.Wait(2500).ForText().ToNotContain("New");
        }

        [Test]
        public void ShouldTimeoutWaitingForTextToNotContain()
        {
            Driver.Navigate().Refresh();
            var element = Driver.FindElement(By.Id("changeText"));

            Assert.Throws<WebDriverTimeoutException>(() => element.Wait(2500).ForText().ToNotContain("Original"));
        }

        [Test]
        public void ShouldWaitForTextToMatch()
        {
            Driver.Navigate().Refresh();

            var element = Driver.FindElement(By.Id("changeText"));
            Driver.FindElement(By.Id("changeTextButton")).Click();

            element.Wait(2500).ForText().ToMatch("New.*");
        }

        [Test]
        public void ShouldTimeoutWaitingForTextToMatch()
        {
            var element = Driver.FindElement(By.Id("textThatNeverChanges"));
            Assert.Throws<WebDriverTimeoutException>( ()=>element.Wait(2500).ForText().ToMatch(".*ABC.*"));
        }


        [Test]
        public void ShouldWaitForTextToNotMatch()
        {
            Driver.Navigate().Refresh();

            var element = Driver.FindElement(By.Id("changeText"));
            Driver.FindElement(By.Id("changeTextButton")).Click();

            element.Wait(2500).ForText().ToNotMatch("Original.*");
        }

        [Test]
        public void ShouldTimeoutWaitingForTextToNotMatch()
        {
            var element = Driver.FindElement(By.Id("textThatNeverChanges"));
            Assert.Throws<WebDriverTimeoutException>(() => element.Wait(2500).ForText().ToNotMatch("Text.*"));

        }
    }
}
