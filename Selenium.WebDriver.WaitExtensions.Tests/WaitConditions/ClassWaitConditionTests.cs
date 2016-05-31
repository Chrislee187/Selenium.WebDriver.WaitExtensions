using NUnit.Framework;
using OpenQA.Selenium;

namespace Selenium.WebDriver.WaitExtensions.Tests.WaitConditions
{
    [TestFixture]
    public class ClassWaitConditionTests
    {
        private readonly IWebDriver Driver = MySetUpClass.Driver;

        [SetUp]
        public void SetUp()
        {
            Driver.Navigate().Refresh();
        }
        [Test]
        public void ShouldWaitForClassToContains()
        {
            var element = Driver.FindElement(By.Id("addClassText"));
            Driver.FindElement(By.Id("addClassButton")).Click();

            element.Wait(2500).ForClasses().ToContain("backred");
        }

        [Test]
        public void ShouldTimeoutWaitingForClassToNotContain()
        {
            var element = Driver.FindElement(By.Id("addClassText"));

            Assert.Throws<WebDriverTimeoutException>( () => element.Wait(2500).ForClasses().ToNotContain("class-that-never-existss"));
        }
        [Test]
        public void ShouldTimeoutWaitingForClassToBeAdded()
        {
            var element = Driver.FindElement(By.Id("addClassText"));
            
            Assert.Throws<WebDriverTimeoutException>(() => element.Wait(2500).ForClasses().ToContain("backred"));
        }

        [Test]
        public void ShouldWaitForClassToContainMatch()
        {
            var element = Driver.FindElement(By.Id("addClassText"));
            Driver.FindElement(By.Id("addClassButton")).Click();

            element.Wait(2500).ForClasses().ToContainMatch(".*red");
        }

        [Test]
        public void ShouldTimeoutWaitingForClassToContainMatch()
        {
            var element = Driver.FindElement(By.Id("addClassText"));

            Assert.Throws<WebDriverTimeoutException>(() =>   element.Wait(2500).ForClasses().ToContainMatch(".*red"));
        }


        [Test]
        public void ShouldWaitForClassToNotContainMatch()
        {
            var element = Driver.FindElement(By.Id("addClassText"));

            element.Wait(2500).ForClasses().ToNotContainMatch(".*red");
        }

        [Test]
        public void ShouldTimeoutWaitingForClassToNotContainMatch()
        {
            var element = Driver.FindElement(By.Id("removeClass"));

            Assert.Throws<WebDriverTimeoutException>(() => element.Wait(2500).ForClasses().ToNotContainMatch(".*to-be-removed.*"));
        }

    }
}
