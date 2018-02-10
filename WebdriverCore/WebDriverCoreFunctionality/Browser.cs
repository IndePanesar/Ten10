// Author       : Inde Panesar
// Date         : Feb 2017
// Description  : Static class for driving Browser and other simple methods

using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System;
using System.Configuration;

namespace WebdriverCore.WebDriverCoreFunctionality
{
    public static class Browser
    {
        private static IWebDriver _webDriver;

        // Define the interface used to search for elements
        public static ISearchContext SearchContext => Driver;

        public static IJavaScriptExecutor JavaScriptExecutor => Driver as IJavaScriptExecutor;

        private static IWebDriver Driver => _webDriver ?? (_webDriver = Initialize());

        /// <summary>
        /// Navigate to given Url
        /// </summary>
        /// <param name="p_Url"></param>
        public static void GoToUrl(string p_Url)
        {
            Driver.Navigate().GoToUrl(p_Url);
        }

        /// <summary>
        /// Intorduce an implicit wait on the driver
        /// </summary>
        public static void IntroduceWaitFor()
        {
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
        }

        /// <summary>
        /// Delete browser cookies
        /// </summary>
        public static void DeleteCookies()
        {
            try
            {
                Driver.Manage().Cookies.DeleteAllCookies();
            }
            catch
            {
                // Ignored
            }
        }

        /// <summary>
        /// Refreshes the current web page
        /// </summary>
        public static void RefreshPage()
        {
            Driver.Navigate().Refresh();
        }

        /// <summary>
        /// Go to previous web page
        /// </summary>
        public static void GoToPreviousPage()
        {
            Driver.Navigate().Back();
        }

        /// <summary>
        /// Get the current driver held Url
        /// </summary>
        /// <returns>Returns the browser Url</returns>
        public static string GetCurrentUrl()
        {
            return Driver.Url;
        }

        /// <summary>
        /// Get the current page title
        /// </summary>
        /// <returns>Returns the current page tTitle</returns>
        public static string GetTitle()
        {
            return Driver.Title;
        }

        /// <summary>
        /// Waits for an element to appear
        /// </summary>
        /// <param name="p_ElementSpecification"></param>
        /// <param name="p_Timeout"></param>
        public static void WaitForElementToAppear(By p_ElementSpecification, int p_Timeout)
        {
            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(p_Timeout));
            wait.Until(ExpectedConditions.ElementIsVisible(p_ElementSpecification));
        }

        /// <summary>
        /// Wait for page load to complete
        /// </summary>
        /// <param name="p_Timeout"></param>
        public static void WaitForPageLoadComplete(int p_Timeout = 5)
        {
            Driver.Manage().Timeouts().PageLoad = new TimeSpan(p_Timeout * 10000000); // 1 tick = one 10 millionth of a second so multiply to resolve back

            IWait<IWebDriver> wait = GetWaitDriver(p_Timeout);
            wait.Until(p_Driver => ((IJavaScriptExecutor)Driver).ExecuteScript("return document.readyState").Equals("complete"));
        }

        /// <summary>
        /// Closes the browser
        /// </summary>
        public static void Close()
        {
            Driver.Quit();

            if (_webDriver != null)
            {
                _webDriver.Dispose();
                _webDriver = null;
            }
        }

        /// <summary>
        /// Action to move to element
        /// </summary>
        /// <param name="p_Element"></param>
        /// <returns>Returns the element after moving to it</returns>
        public static IWebElement MoveToElement(IWebElement p_Element)
        {
            Actions act = new Actions(Driver);
            act.MoveToElement(p_Element);
            act.Perform();
            return p_Element;
        }

        /// <summary>
        /// Javascript scroll to an element
        /// </summary>
        /// <param name="p_Element"></param>
        public static void ScrollToElement(IWebElement p_Element)
        {
            try
            {
                var position = p_Element.Location.Y.ToString();
                var script = $"('#main-container').scrollTop({position})";
                ((IJavaScriptExecutor)Driver).ExecuteScript(script);
            }
            catch
            {
                // Ignored
            }
        }

        /// <summary>
        /// Get an instance of the Webdriver wait default the wait time to 5 seconds
        /// </summary>
        /// <param name="p_Seconds"></param>
        /// <returns>Returns an instance of WebDriverWait with the given timeout period or default 5 second</returns>
        private static WebDriverWait GetWaitDriver(int p_Seconds = 5)
        {
            var waitDriver = new WebDriverWait(Driver, TimeSpan.FromSeconds(p_Seconds));
            return waitDriver;
        }

        /// <summary>
        /// Gets an instance of the Webdriver and set an implicit wait of 10 seconds and maximized
        /// </summary>
        /// <param name="p_Browser"></param>
        /// <returns>Returns instance of IWebdriver</returns>
        private static IWebDriver GetWebDriver(BrowserType p_Browser)
        {
            var driver = GetDriver(p_Browser);

            // Implicit wait of up to 10 seconds
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Manage().Window.Maximize();
            return driver;
        }

        /// <summary>
        ///  Main function to create an istance of the sriver and return the Webdriver 
        /// </summary>
        /// <param name="p_Browser"></param>
        /// <returns>Returns an instance of IWebdriver of browser type specified</returns>
        private static IWebDriver GetDriver(BrowserType p_Browser)
        {
            switch (p_Browser)
            {
                case BrowserType.Chrome:
                    var options = new ChromeOptions();
                    options.AddArgument("start-maximized");
                    return new ChromeDriver(options);

                case BrowserType.Firefox:
                    var profile = new FirefoxProfile();
                    profile.SetPreference("acceptUntrustedCerts", true);
                    return new FirefoxDriver(profile);

                case BrowserType.InternetExplorer:
                    return new InternetExplorerDriver(
                        new InternetExplorerOptions
                        {
                            IntroduceInstabilityByIgnoringProtectedModeSettings = true,
                            UnhandledPromptBehavior = UnhandledPromptBehavior.Dismiss,
                            EnsureCleanSession = true
                        });

                default:
                    
                    Assert.Fail($"Browser type {p_Browser} not handled.");
                    break;

            }

            // Default
            return new ChromeDriver();
        }

        /// <summary>
        ///  Initialize an instance of the Browser
        /// </summary>
        /// <returns>Returns an instanceof webdriver</returns>
        private static IWebDriver Initialize()
        {
            var browser = (BrowserType)Enum.Parse(typeof(BrowserType), ConfigurationManager.AppSettings["Browser"], true);
            return GetWebDriver(browser);
        }
    }
}
