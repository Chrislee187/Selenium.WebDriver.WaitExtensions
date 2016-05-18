using System.IO;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace WebDriver.WaitExtensions.Tests.WaitConditions
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
    }
}
