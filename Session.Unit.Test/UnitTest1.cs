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

namespace Session.Unit.Test
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
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
                driver.Navigate().GoToUrl("https://localhost:5001/");
                driver.FindElement(By.Name("Input.Email")).SendKeys("darshan@cimsolutions.nl");
                driver.FindElement(By.Name("Input.Password")).SendKeys("Darshan12345!" + Keys.Enter);
                wait.Until(webDriver => webDriver.FindElement(By.Name("Cimsolutions planner image")).Displayed);
                IWebElement firstResult = driver.FindElement(By.Name("Cimsolutions planner image"));
                Console.WriteLine(firstResult.GetAttribute("textContent"));

            }
        }
    }
}
