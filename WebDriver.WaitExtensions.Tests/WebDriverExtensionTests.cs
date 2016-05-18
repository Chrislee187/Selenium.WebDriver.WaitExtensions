using System.IO;
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
        public void ShouldWaitForClassToContains()
        {
            var element = _driver.FindElement(By.Id("addClassText"));
            _driver.FindElement(By.Id("addClassButton")).Click();

            element.Wait(2500).ForClasses().ToContain("backred");
        }

        [Test]
        public void ShouldTimeoutWaitingForClassToNotContain()
        {
            var element = _driver.FindElement(By.Id("addClassText"));

            Assert.Throws<WebDriverTimeoutException>( () => element.Wait(2500).ForClasses().ToNotContain("class-that-never-existss"));
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
            
            element.Wait(2500).ForAttributes().ToContainWithValue("test","MyTest");
        }

        [Test]
        public void ShouldTimeoutWaitingForAttributeToNotContainValue()
        {
            var element = _driver.FindElement(By.Id("addAttributeElement"));
            Assert.Throws<WebDriverTimeoutException>( ()=> element.Wait(2500).ForAttributes().ToContainWithoutValue("test", "never-set-value"));
        }
        [Test]
        public void ShouldTimeoutWaitingForAttributeToBeAdded()
        {
            var element = _driver.FindElement(By.Id("addAttributeElement"));
Assert.Throws<WebDriverTimeoutException>(() => element.Wait(25).ForAttributes().ToNotContain("attribute-that-never-exists"));

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

            element.Wait(2500).ForElement().ToNotBeVisible();
        }

        [Test]
        public void ShouldTimeoutWaitingElementToNotBeVisible()
        {
            var element = _driver.FindElement(By.Id("alwaysVisibleElement"));

            element.Wait(2500).ForElement().ToNotBeVisible();
        }


    }
}
