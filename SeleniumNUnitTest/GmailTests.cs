using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using NUnit.Framework.Internal;
using OpenQA.Selenium.Firefox;

namespace SeleniumNUnitTest
{
    [TestFixture]
    public class GmailTests
    {
        private IWebDriver driver;
        public GmailTests()
        {

        }

        [SetUp]
        public void LoadDriver()
        {
            driver = new FirefoxDriver();
        }

        [Test]
        public void Login()
        {
            driver.Navigate().GoToUrl("http://gmail.com");
          //  driver.FindElement(By.LinkText("SignIn")).Click();
           driver.FindElement(By.Id("Email")).SendKeys("ioanaaugustapop@gmail.com");
            //By.CssSelector("input[name=tripType][value=oneway]")
           driver.FindElement(By.Id("next")).Click();
           driver.FindElement(By.Id("Passwd")).SendKeys("Abigail_muresan1980");
            driver.FindElement(By.Id("signIn")).Click();
            Assert.True(driver.Title.Contains("Inbox"));
        }
        [TestCase("Google")]
        [TestCase("Bing")]
        public void Search(string searchString)
    {
        driver.Navigate().GoToUrl("http://google.com");
        driver.FindElement(By.Name("q")).SendKeys(searchString);

        Assert.True(driver.Title.Contains("Google"));
    }
        [TearDown]
        public void UnloadDriver()
        {
            driver.Quit();
        }
    }
}
