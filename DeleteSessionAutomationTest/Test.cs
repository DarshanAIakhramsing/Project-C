using System;
using Xunit;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Reflection;
using System.Threading;

namespace DeleteSessionAutomationTest
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
                //Change this ID to the ID that you want to delete
                wait.Until(e => e.FindElement(By.Id("91"))).Click();
                wait.Until(e => e.FindElement(By.Id("verwijder"))).Click();
                //Let's the application wait for 2 seconds to give the time for new elements to load
                Thread.Sleep(2000);
                //exist checks if element 41 exist
                bool exist = driver.FindElements(By.Id("41")).Count == 1;
                //exist checks if element 61 doesn't exist
                bool nonExist = driver.FindElements(By.Id("91")).Count == 0;
                //Assert checks if the booleans are true
                Assert.True(exist);
                Assert.True(nonExist);
            }
        }
    }
}
