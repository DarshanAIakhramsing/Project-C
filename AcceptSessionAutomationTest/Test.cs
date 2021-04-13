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
                driver.FindElement(By.Name("Input.Email")).SendKeys("m.campen@cimsolutions.nl");
                driver.FindElement(By.Name("Input.Password")).SendKeys("Marco123!" + Keys.Enter);
                driver.Navigate().GoToUrl("https://localhost:5001/sessieoverzicht");
                Thread.Sleep(1000);
                //driver.FindElement(By.Id("Header"));
                IWebElement acceptClick = wait.Until(e => e.FindElement(By.Id("55")));
                acceptClick.Click();
                Thread.Sleep(1000);
                bool exist = driver.FindElements(By.Id("61")).Count == 1;
                bool nonExist = driver.FindElements(By.Id("55")).Count == 0;
                Assert.True(exist);
                Assert.True(nonExist);


            }
        }
    }
}