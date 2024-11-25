using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        private IWebDriver driver;

        [TestInitialize]
        public void Setup()
        {
            driver = new ChromeDriver(); // You can change this to any other browser driver
           
        }

        [TestMethod]
        public void LoginTest_ValidCredentials()
        {
            driver.Navigate().GoToUrl("https://www.facebook.com/");
            Assert.IsTrue(driver.Url.Contains("facebook"), "sucess");
        }

        [TestMethod]
        public void LogoutTest()
        {
            // Find username, password fields and login button, then interact with them
            driver.FindElement(By.Id("email")).SendKeys("pavushettymounika@gmail.com");
            driver.FindElement(By.Id("pass")).SendKeys("Mounik@93");
            driver.FindElement(By.Id("u_0_9_XG")).Click();
            driver.FindElement(By.PartialLinkText("mounika.pavushetty")).Click();
            // Assert that login was successful (check if the dashboard is loaded)
            Assert.IsTrue(driver.Url.Contains("mounika.pavushetty"), "Login failed, dashboard not found.");
        }

        [TestCleanup]
        public void TearDown()
        {
            //driver.Quit(); // Close the browser after the test completes
        }
    }
}

