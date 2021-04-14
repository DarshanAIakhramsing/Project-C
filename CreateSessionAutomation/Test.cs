using System;
using Xunit;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Reflection;
using System.Threading;

namespace AcceptSessionAutomationTest
{
    public class Test : IDisposable
    {
        //This instantiates the webdriver to use selenium in our code
        public readonly IWebDriver driver;
        //Creates and controls a thread
        private readonly Thread server;

        //This is the function that starts up the project for the test
        public Test()
        {
            //This is a relative path so it can always find Project C no matter the other person's file structure
            var assembly = Assembly.Load("Project_C");

            //This makes a new thread called server
            server = new Thread(() =>
            {
                //Here is where Project C will be called to check if the file exists
                try
                {
                    assembly.EntryPoint.Invoke(null, new object[] { new string[0] });
                }
                catch
                {
                    // Ignore exception
                }
            });
            //The application will be started
            server.Start();

        }

        //This function gives more functionality to the server (for example it could use thread.sleep)
        public void Dispose()
        {

            server.Interrupt();
            server.Join();
            driver?.Dispose();
        }

        [Fact]
        public void Driver()
        {
            //This starts up our project in a chrome webbrowser and tests through that
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
                //Creates a session
                wait.Until(e => e.FindElement(By.Id("Sessie Aanmaken"))).Click();
                wait.Until(e => e.FindElement(By.Id("Name"))).SendKeys("Test Name 1");
                wait.Until(e => e.FindElement(By.Id("Location"))).SendKeys("Test Location 1");
                wait.Until(e => e.FindElement(By.Id("Date"))).SendKeys("12252021");
                wait.Until(e => e.FindElement(By.Id("Time"))).SendKeys("1725");
                driver.FindElement(By.Id("Verstuur")).Click();
                //Let's the application wait for 2 seconds to give the time for new elements to load
                Thread.Sleep(2000);
                IWebElement bodyTag = wait.Until(e => e.FindElement(By.TagName("tbody")));
                //Assert checks if the text that the code filled in is the same with the text we expected
                Assert.Contains("Test Name 1", bodyTag.Text);
                Assert.Contains("Test Location 1", bodyTag.Text);
                Assert.Contains("25-12-2021", bodyTag.Text);
                Assert.Contains("17:25:00", bodyTag.Text);
            }
        }
    }
}