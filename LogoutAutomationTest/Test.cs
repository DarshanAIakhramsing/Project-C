using System;
using Xunit;
using Project_C.Models;
using Project_C.Data;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Threading;

namespace LogoutAutomationTest
{
    public class Test : IDisposable
    {
        public readonly IWebDriver driver;
        private readonly Thread server;

        public Test()
        {
            var assembly = Assembly.Load("Project_C");

            server = new Thread(() =>
            {
                try
                {
                    assembly.EntryPoint.Invoke(null, new object[] { new string[0] });
                }
                catch
                {
                    // Ignore exception
                }
            });
            server.Start();

        }

        public void Dispose()
        {

            server.Interrupt();
            server.Join();
            driver?.Dispose();
        }

        [Fact]
        public void Driver()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                //the wait variable gives the functionality to wait a certain amount of time before executing a task
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
                //Goes to the url from the website
                driver.Navigate().GoToUrl("https://localhost:5001/");
                //Inserts the email in the email field to login
                driver.FindElement(By.Name("Input.Email")).SendKeys("automationtest@cimsolutions.nl");
                //Inserts the password in the password field to login
                driver.FindElement(By.Name("Input.Password")).SendKeys("Testing123!" + Keys.Enter);
                //Gives the application 2 seconds to load in all the new elements
                Thread.Sleep(2000);
                //Makes the user logout of the system
                wait.Until(e => e.FindElement(By.Id("Uitloggen"))).Click();
                //Checks if a certrain element has been found on a different page
                //If this element has been found, the user succesfully logged out
                driver.FindElement(By.Id("forgot-password")).Click();
            }
        }
    }
}
