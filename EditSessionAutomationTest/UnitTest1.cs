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
    public class UnitTest1 : IDisposable
    {
        public readonly IWebDriver driver;
        private readonly Thread server;

        public UnitTest1()
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
                driver.FindElement(By.Name("Input.Email")).SendKeys("m.campen@cimsolutions.nl");
                driver.FindElement(By.Name("Input.Password")).SendKeys("Marco123!" + Keys.Enter);
                driver.Navigate().GoToUrl("https://localhost:5001/sessies");
                //Verander deze ID naar de ID die je wilt aanpassen
                wait.Until(e => e.FindElement(By.Id("71"))).Click();
                wait.Until(e => e.FindElement(By.Id("Name"))).Clear();
                wait.Until(e => e.FindElement(By.Id("Name"))).SendKeys("Test Name 2");
                wait.Until(e => e.FindElement(By.Id("Location"))).Clear();
                wait.Until(e => e.FindElement(By.Id("Location"))).SendKeys("Test Location 2");
                wait.Until(e => e.FindElement(By.Id("Date"))).SendKeys("12262021");
                wait.Until(e => e.FindElement(By.Id("Time"))).SendKeys("1835");
                driver.FindElement(By.Id("Wijzig")).Click();
                Thread.Sleep(2000);
                IWebElement bodyTag = wait.Until(e => e.FindElement(By.TagName("tbody")));
                Assert.Contains("Test Name 2", bodyTag.Text);
                Assert.Contains("Test Location 2", bodyTag.Text);
                Assert.Contains("26-12-2021", bodyTag.Text);
                Assert.Contains("18:35:00", bodyTag.Text);
            }
        }
    }
}
