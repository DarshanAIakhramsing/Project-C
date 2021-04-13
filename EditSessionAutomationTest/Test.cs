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

namespace EditSessionAutomationTest
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
                driver.FindElement(By.Name("Input.Email")).SendKeys("darshan@cimsolutions.nl");
                //Inserts the password in the password field to login
                driver.FindElement(By.Name("Input.Password")).SendKeys("Darshan12345!" + Keys.Enter);
                //Navigates to sessie overzicht page
                driver.Navigate().GoToUrl("https://localhost:5001/sessies");
                //Edits the session info
                wait.Until(e => e.FindElement(By.Id("87"))).Click();
                wait.Until(e => e.FindElement(By.Id("Name"))).Clear();
                wait.Until(e => e.FindElement(By.Id("Name"))).SendKeys("Test Name 2");
                wait.Until(e => e.FindElement(By.Id("Location"))).Clear();
                wait.Until(e => e.FindElement(By.Id("Location"))).SendKeys("Test Location 2");
                wait.Until(e => e.FindElement(By.Id("Date"))).SendKeys("26122021");
                wait.Until(e => e.FindElement(By.Id("Time"))).SendKeys("1835");
                driver.FindElement(By.Id("Wijzig")).Click();
                //Let's the application wait for 2 second to give the time for new elements to load
                Thread.Sleep(2000);
                IWebElement bodyTag = wait.Until(e => e.FindElement(By.TagName("tbody")));
                //Assert checks if the text that the code filled in is the same with the text we expected
                Assert.Contains("Test Name 2", bodyTag.Text);
                Assert.Contains("Test Location 2", bodyTag.Text);
                Assert.Contains("26/12/2021", bodyTag.Text);
                Assert.Contains("18:35:00", bodyTag.Text);
            }
        }
    }
}
