using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System.Threading;
using System.Drawing;
using OpenQA.Selenium.Interactions;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        private IWebDriver driver;
        String username;
        String password;
        [TestInitialize]
        public void Setup()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddUserProfilePreference("profile.default_content_setting_values.notifications", 2); // Disable notifications

            driver = new ChromeDriver(options);
          //  driver.Navigate().GoToUrl("https://www.facebook.com/");
            // You can change this to any other browser driver
            username = "pavushettymounika@gmail.com";
            password = "Mounik@93";
        }

       /* [TestMethod]
        public void NavigatURL()
        {
            driver.Navigate().GoToUrl("https://www.facebook.com/");
            Assert.IsTrue(driver.Url.Contains("facebook"), "sucess");
        }*/

        [TestMethod]
        public void LoginTest()
        {
            driver.Navigate().GoToUrl("https://www.facebook.com/");
            driver.Manage().Window.Maximize();
            Thread.Sleep(1000);
            // Find username, password fields and login button, then interact with them
            driver.FindElement(By.Id("email")).SendKeys(username);
            driver.FindElement(By.Id("pass")).SendKeys(password);
            Thread.Sleep(1000);
            driver.FindElement(By.XPath("//button[@name='login']")).Click();
        
           //  driver.SwitchTo().Alert().Dismiss();
            Thread.Sleep(5000);
            driver.FindElement(By.XPath("//div/ul/li/div/a[@href='https://www.facebook.com/mounika.pavushetty']")).Click();
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

