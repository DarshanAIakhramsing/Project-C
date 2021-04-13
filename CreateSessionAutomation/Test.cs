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
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
                driver.Navigate().GoToUrl("https://localhost:5001/");
                driver.FindElement(By.Name("Input.Email")).SendKeys("darshan@cimsolutions.nl");
                driver.FindElement(By.Name("Input.Password")).SendKeys("Darshan12345!" + Keys.Enter);
                driver.Navigate().GoToUrl("https://localhost:5001/sessies");
                wait.Until(e => e.FindElement(By.Id("Sessie Aanmaken"))).Click();
                wait.Until(e => e.FindElement(By.Id("Name"))).SendKeys("Test Name 1");
                wait.Until(e => e.FindElement(By.Id("Location"))).SendKeys("Test Location 1");
                wait.Until(e => e.FindElement(By.Id("Date"))).SendKeys("12252021");
                wait.Until(e => e.FindElement(By.Id("Time"))).SendKeys("1725");
                driver.FindElement(By.Id("Verstuur")).Click();
                Thread.Sleep(2000);
                IWebElement bodyTag = wait.Until(e => e.FindElement(By.TagName("tbody")));
                Assert.Contains("Test Name 1", bodyTag.Text);
                Assert.Contains("Test Location 1", bodyTag.Text);
                Assert.Contains("25-12-2021", bodyTag.Text);
                Assert.Contains("17:25:00", bodyTag.Text);
            }
        }
    }
}