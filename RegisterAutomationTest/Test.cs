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

namespace RegisterAutomationTest
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
                driver.Navigate().GoToUrl("https://localhost:5001/Identity/Account/Register");
                driver.FindElement(By.Name("Input.Email")).SendKeys("test@cimsolutions.nl");
                driver.FindElement(By.Name("Input.Password")).SendKeys("Testing123!");
                driver.FindElement(By.Name("Input.ConfirmPassword")).SendKeys("Testing123!" + Keys.Enter);
                IWebElement logo = driver.FindElement(By.Id("CIMSOLUTIONS"));
                System.Console.WriteLine(logo.Enabled);


            }
        }
    }
}
