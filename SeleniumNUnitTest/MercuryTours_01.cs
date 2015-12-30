using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
//using OpenQA.Selenium.Support.UI;

namespace SeleniumTests
{
    [TestFixture]
    public class MercuryTours
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;
        
        [SetUp]
        public void SetupTest()
        {
            driver = new FirefoxDriver();
            baseURL = "http://newtours.demoaut.com/";
            verificationErrors = new StringBuilder();
        }
        
        [TearDown]
        public void TeardownTest()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Assert.AreEqual("", verificationErrors.ToString());
        }
        
        [Test]
        public void TheMercuryToursTest()
        {
            driver.Navigate().GoToUrl(baseURL + "/");
            Assert.AreEqual("Welcome: Mercury Tours", driver.Title);
            driver.FindElement(By.Name("userName")).Clear();
            driver.FindElement(By.Name("userName")).SendKeys("augustapop");
            driver.FindElement(By.Name("userName")).Clear();
            driver.FindElement(By.Name("userName")).SendKeys("rebecapop");
            driver.FindElement(By.Name("password")).Clear();
            driver.FindElement(By.Name("password")).SendKeys("rebecapop");
            driver.FindElement(By.Name("login")).Click();
            Assert.AreEqual("Sign-on: Mercury Tours", driver.Title);
            driver.FindElement(By.Name("userName")).Clear();
            driver.FindElement(By.Name("userName")).SendKeys("augustapop");
            driver.FindElement(By.Name("password")).Clear();
            driver.FindElement(By.Name("password")).SendKeys("Abigail_muresan1980");
            driver.FindElement(By.Name("password")).Clear();
            driver.FindElement(By.Name("password")).SendKeys("Abigail_muresan1980");
            driver.FindElement(By.Name("login")).Click();
            Assert.AreEqual("Sign-on: Mercury Tours", driver.Title);
            try
            {
                Assert.AreEqual("Sign-on: Mercury Tours", driver.Title);
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
        }
        private bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
        
        private bool IsAlertPresent()
        {
            try
            {
                driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }
        
        private string CloseAlertAndGetItsText() {
            try {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert) {
                    alert.Accept();
                } else {
                    alert.Dismiss();
                }
                return alertText;
            } finally {
                acceptNextAlert = true;
            }
        }
    }
}
