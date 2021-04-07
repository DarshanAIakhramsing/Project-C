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
                driver.Navigate().GoToUrl("https://localhost:5001/medewerkers");
                wait.Until(e => e.FindElement(By.Id("Textbox"))).SendKeys("darshan@cimsolutions.nl");
            }
        }
    }
}
