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

            element.Wait(2500).ForText("text").ToEqual("New Text");

        }

        [Test]
        public void ShouldTimeoutWaitingForTextToEqual()
        {
            var element = _driver.FindElement(By.Id("changeText"));

            Assert.Throws<WebDriverTimeoutException>(() => element.Wait().ForText("text").ToEqual("Text That Never Appears"));
        }

        [Test]
        public void ShouldWaitForTextToNotEqual()
        {
            _driver.Navigate().Refresh();

            var element = _driver.FindElement(By.Id("changeText"));
            _driver.FindElement(By.Id("changeTextButton")).Click();

            element.Wait(2500).ForText("text").ToNotEqual("Original Text");
        }

        [Test]
        public void ShouldTimeoutWaitingForTextToNotEqual()
        {
            var element = _driver.FindElement(By.Id("changeText"));

            Assert.Throws<WebDriverTimeoutException>(() => element.Wait().ForText("text").ToEqual("will never equal this"));

        }
        [Test]
        public void ShouldWaitForTextToContain()
        {
            _driver.Navigate().Refresh();

            var element = _driver.FindElement(By.Id("changeText"));
            _driver.FindElement(By.Id("changeTextButton")).Click();

            element.Wait(2500).ForText("text").ToContain("ew T");

        }

        [Test]
        public void ShouldTimeoutWaitingForTextToContain()
        {
            _driver.Navigate().Refresh();

            var element = _driver.FindElement(By.Id("changeText"));

            Assert.Throws<WebDriverTimeoutException>(() => element.Wait(2500).ForText("text").ToContain("xy"));
        }
        [Test]
        public void ShouldWaitForTextToNotContains()
        {
            _driver.Navigate().Refresh();

            var element = _driver.FindElement(By.Id("changeText"));

            element.Wait(2500).ForText("text").ToNotContain("New");
        }

        [Test]
        public void ShouldTimeoutWaitingForTextToNotContain()
        {
            _driver.Navigate().Refresh();
            var element = _driver.FindElement(By.Id("changeText"));

            Assert.Throws<WebDriverTimeoutException>(() => element.Wait(2500).ForText("text").ToNotContain("Original"));
        }
    }
}
