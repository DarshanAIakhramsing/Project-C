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
using System.Collections.Generic;

namespace AcceptSessionAutomationTest
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
                //Navigates to sessie overzicht page
                driver.Navigate().GoToUrl("https://localhost:5001/sessieoverzicht");
                Thread.Sleep(1000);
                //Waits until an element has loaded before checking if we have arrived on the page
                IWebElement acceptClick = wait.Until(e => e.FindElement(By.Id("55")));
                acceptClick.Click();
                //Let's the application wait for 1 second to give the time for new elements to load
                Thread.Sleep(1000);
                //exist checks if element 61 exist
                bool exist = driver.FindElements(By.Id("61")).Count == 1;
                //nonExist checks if element 55 doesn't exist
                bool nonExist = driver.FindElements(By.Id("55")).Count == 0;
                //Assert checks if the booleans are true
                Assert.True(exist);
                Assert.True(nonExist);
            }
        }
    }
}
