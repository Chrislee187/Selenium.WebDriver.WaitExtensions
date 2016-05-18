using System.IO;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace WebDriver.WaitExtensions.Tests.WaitConditions
{
    [TestFixture]
    public class AttributeWaitConditionTests
    {
        private readonly IWebDriver Driver = MySetUpClass.Driver;

        [Test]
        public void ShouldWaitForAttributeToBeAdded()
        {
            var element = Driver.FindElement(By.Id("addAttributeElement"));
            Driver.FindElement(By.Id("addAttributeButton")).Click();

            element.Wait(2500).ForAttributes().ToContain("test");
        }

        [Test]
        public void ShouldWaitForAttributeToContainValue()
        {
            var element = Driver.FindElement(By.Id("addAttributeElement"));
            Driver.FindElement(By.Id("addAttributeButton")).Click();
            
            element.Wait(2500).ForAttributes().ToContainWithValue("test","MyTest");
        }

        [Test]
        public void ShouldTimeoutWaitingForAttributeToNotContainValue()
        {
            var element = Driver.FindElement(By.Id("addAttributeElement"));
            Assert.Throws<WebDriverTimeoutException>( ()=> element.Wait(2500).ForAttributes().ToContainWithoutValue("test", "never-set-value"));
        }
        [Test]
        public void ShouldTimeoutWaitingForAttributeToBeAdded()
        {
            var element = Driver.FindElement(By.Id("addAttributeElement"));
Assert.Throws<WebDriverTimeoutException>(() => element.Wait(25).ForAttributes().ToNotContain("attribute-that-never-exists"));

        }
    }
}
