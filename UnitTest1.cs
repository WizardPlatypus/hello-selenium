using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Selenium
{
    public class Tests
    {
        private IWebDriver driver;
        private string url = "https://www.selenium.dev/selenium/web/web-form.html";

        public IWebElement Get(By by)
        {
            return driver.FindElement(by);
        }

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl(url);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(500);
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
            driver.Dispose();
        }

        [Test]
        public void TextboxColor()
        {
            string green = "#00ff00";

            Get(By.Name("my-text")).SendKeys(green);
            Assert.That(Get(By.Name("my-text")).GetAttribute("value"), Is.EqualTo(green));

            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].value = arguments[1];", Get(By.Name("my-colors")), green);
            Assert.That(Get(By.Name("my-colors")).GetAttribute("value"), Is.EqualTo(green));

            Get(By.CssSelector("button")).Click();
            Assert.That(Get(By.Id("message")).Text, Is.EqualTo("Received!"));
        }

        [Test]
        public void DropdownCheckbox()
        {
            Get(By.Name("my-select")).FindElement(By.CssSelector("option[value='2']")).Click();
            Assert.That(Get(By.Name("my-select")).GetAttribute("value"), Is.EqualTo("2"));

            Get(By.Id("my-check-1")).Click();
            Assert.That(Get(By.Id("my-check-1")).GetAttribute("checked"), Is.Not.Empty);

            Get(By.CssSelector("button")).Click();
            Assert.That(Get(By.Id("message")).Text, Is.EqualTo("Received!"));
        }

        [Test]
        public void DatetimeRadio()
        {
            Get(By.Name("my-date")).SendKeys("2025-05-03");
            Assert.That(Get(By.Name("my-date")).GetAttribute("value"), Is.EqualTo("2025-05-03"));

            Get(By.Id("my-radio-1")).Click();
            Assert.Multiple(() =>
            {
                Assert.That(Get(By.Id("my-radio-1")).GetAttribute("checked"), Is.Not.Empty);
                Assert.That(Get(By.Id("my-radio-2")).GetAttribute("checked"), Is.Null);
            });

            Get(By.CssSelector("button")).Click();
            Assert.That(Get(By.Id("message")).Text, Is.EqualTo("Received!"));
        }
    }
}