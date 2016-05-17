﻿using System.IO;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace WebDriver.WaitExtensions.Tests
{
    [TestFixture]
    public class WebDriverExtensionTests
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
        public void ShouldWaitForElementToExist()
        {
            _driver.FindElement(By.Id("createdSpanTestButton")).Click();

            var element = _driver.Wait(2500).ForElement(By.Id("createdSpan")).ToExist();

            Assert.That(element.TagName, Is.EqualTo("span"));
            Assert.That(element.GetAttribute("id"), Is.EqualTo("createdSpan"));
        }

        [Test]
        public void ShouldThrowWhenTimeoutWaitingForElementToExist()
        {
            Assert.Throws<WebDriverTimeoutException>(() => _driver.Wait().ForElement(By.Id("non-existing-element")).ToExist());
        }

        [Test]
        public void ShouldWaitForElementToNotExist()
        {
            _driver.FindElement(By.Id("removedSpanTestButton")).Click();
            _driver.Wait(2500).ForElement(By.Id("elementToBeRemoved")).ToNotExist();
        }

        [Test]
        public void ShouldThrowWhenTimeoutWaitingForElementToNotExist()
        {
            Assert.Throws<WebDriverTimeoutException>(() => _driver.Wait().ForElement(By.TagName("HEAD")).ToNotExist());
        }

        [Test]
        public void ShouldWaitForTextToChange()
        {
            var element = _driver.FindElement(By.Id("changeText"));
            _driver.FindElement(By.Id("changeTextButton")).Click();

            element.Wait(2500).ForText("text").ToEqual("New Text");

        }

        [Test]
        public void ShouldThrowWhenTimeoutWaitingForTextToChange()
        {
            var element = _driver.FindElement(By.Id("changeText"));

            Assert.Throws<WebDriverTimeoutException>(() => element.Wait().ForText("text").ToEqual("Text That Never Appears"));
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
        public void ShouldWaitForClassToBeAdded()
        {
            var element = _driver.FindElement(By.Id("addClassText"));
            _driver.FindElement(By.Id("addClassButton")).Click();

            element.Wait(2500).ForClasses().ToContain("backred");
        }

        [Test]
        public void ShouldTimeoutWaitingForClassToBeAdded()
        {
            var element = _driver.FindElement(By.Id("addClassText"));
            
            Assert.Throws<WebDriverTimeoutException>(() => element.Wait(2500).ForClasses().ToContain("backred"));
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

            element.Wait(2500).ForAttributes().ToContainValue("test","MyTest");
        }

        [Test]
        public void ShouldWaitForAttributeToNotContainValue()
        {
            var element = _driver.FindElement(By.Id("addAttributeElement"));
            element.Wait(2500).ForAttributes().ToNotContainValue("test", "never-set-value");
        }
        [Test]
        public void ShouldTimeoutWaitingForAttributeToBeAdded()
        {
            var element = _driver.FindElement(By.Id("addAttributeElement"));
            element.Wait(25).ForAttributes().ToNotContain("attribute-that-never-exists");

        }
    }
}
