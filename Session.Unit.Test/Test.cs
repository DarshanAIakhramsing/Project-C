using System;
using Xunit;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Reflection;
using System.Threading;

namespace Session.Unit.Test
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
                driver.FindElement(By.Name("Input.Email")).SendKeys("automationtestFerdi@cimsolutions.nl");
                //Inserts the password in the password field to login
                driver.FindElement(By.Name("Input.Password")).SendKeys("Testing123!" + Keys.Enter);
                //Checks to see if we can find an element to see if we landed on the desired page
                IWebElement logo = driver.FindElement(By.Id("CIMSOLUTIONS"));
            }
        }
    }
}
