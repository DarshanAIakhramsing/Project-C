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
                //the wait variable gives the functionality to wait a certain amount of time before executing a task
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
                //Goes to the url from the website
                driver.Navigate().GoToUrl("https://localhost:5001/");
                //Inserts the email in the email field to login
                driver.FindElement(By.Name("Input.Email")).SendKeys("darshan@cimsolutions.nl");
                //Inserts the password in the password field to login
                driver.FindElement(By.Name("Input.Password")).SendKeys("Darshan12345!" + Keys.Enter);
                //Navigates to the desired URL
                driver.Navigate().GoToUrl("https://localhost:5001/medewerkers");
                //Let's the application wait 1 second for new elements to load in
                Thread.Sleep(1000);
                IWebElement tekst = wait.Until(e => e.FindElement(By.Id("tekstbox")));
                tekst.Click();
                tekst.SendKeys("ferdi");
                Thread.Sleep(1000);
                IWebElement bodyTag = wait.Until(e => e.FindElement(By.TagName("tbody")));
                //Checks if the text the test filled in is equal to the text we expect
                Assert.Contains("ferdi@cimsolutions.nl", bodyTag.Text);
                Assert.DoesNotContain("jabba@gmail.com", bodyTag.Text);
                

            }
        }
    }
}
