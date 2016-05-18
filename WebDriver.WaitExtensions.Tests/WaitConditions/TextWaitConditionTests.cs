using System.IO;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace WebDriver.WaitExtensions.Tests.WaitConditions
{
    [TestFixture]
    public class TextWaitConditionTests
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
        public void ShouldWaitForTextToEqual()
        {
            var element = _driver.FindElement(By.Id("changeText"));
            _driver.FindElement(By.Id("changeTextButton")).Click();

            element.Wait(2500).ForText().ToEqual("New Text");

        }

        [Test]
        public void ShouldTimeoutWaitingForTextToEqual()
        {
            var element = _driver.FindElement(By.Id("changeText"));

            Assert.Throws<WebDriverTimeoutException>(() => element.Wait().ForText().ToEqual("Text That Never Appears"));
        }

        [Test]
        public void ShouldWaitForTextToNotEqual()
        {
            _driver.Navigate().Refresh();

            var element = _driver.FindElement(By.Id("changeText"));
            _driver.FindElement(By.Id("changeTextButton")).Click();

            element.Wait(2500).ForText().ToNotEqual("Original Text");
        }

        [Test]
        public void ShouldTimeoutWaitingForTextToNotEqual()
        {
            var element = _driver.FindElement(By.Id("changeText"));

            Assert.Throws<WebDriverTimeoutException>(() => element.Wait().ForText().ToEqual("will never equal this"));

        }
        [Test]
        public void ShouldWaitForTextToContain()
        {
            _driver.Navigate().Refresh();

            var element = _driver.FindElement(By.Id("changeText"));
            _driver.FindElement(By.Id("changeTextButton")).Click();

            element.Wait(2500).ForText().ToContain("ew T");

        }

        [Test]
        public void ShouldTimeoutWaitingForTextToContain()
        {
            _driver.Navigate().Refresh();

            var element = _driver.FindElement(By.Id("changeText"));

            Assert.Throws<WebDriverTimeoutException>(() => element.Wait(2500).ForText().ToContain("xy"));
        }
        [Test]
        public void ShouldWaitForTextToNotContains()
        {
            _driver.Navigate().Refresh();

            var element = _driver.FindElement(By.Id("changeText"));

            element.Wait(2500).ForText().ToNotContain("New");
        }

        [Test]
        public void ShouldTimeoutWaitingForTextToNotContain()
        {
            _driver.Navigate().Refresh();
            var element = _driver.FindElement(By.Id("changeText"));

            Assert.Throws<WebDriverTimeoutException>(() => element.Wait(2500).ForText().ToNotContain("Original"));
        }

        [Test]
        public void ShouldWaitForTextToMatch()
        {
            _driver.Navigate().Refresh();

            var element = _driver.FindElement(By.Id("changeText"));
            _driver.FindElement(By.Id("changeTextButton")).Click();

            element.Wait(2500).ForText().ToMatch("New.*");
        }

        [Test]
        public void ShouldTimeoutWaitingForTextToMatch()
        {
            var element = _driver.FindElement(By.Id("textThatNeverChanges"));
            Assert.Throws<WebDriverTimeoutException>( ()=>element.Wait(2500).ForText().ToMatch(".*ABC.*"));
        }


        [Test]
        public void ShouldWaitForTextToNotMatch()
        {
            _driver.Navigate().Refresh();

            var element = _driver.FindElement(By.Id("changeText"));
            _driver.FindElement(By.Id("changeTextButton")).Click();

            element.Wait(2500).ForText().ToNotMatch("Original.*");
        }

        [Test]
        public void ShouldTimeoutWaitingForTextToNotMatch()
        {
            var element = _driver.FindElement(By.Id("textThatNeverChanges"));
            Assert.Throws<WebDriverTimeoutException>(() => element.Wait(2500).ForText().ToNotMatch("Text.*"));

        }
    }
}
