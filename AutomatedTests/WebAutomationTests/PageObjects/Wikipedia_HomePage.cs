// Author       : Inde Panesar
// Date         : Feb 2017
// Description  : Page object for Wikipedia Home page.
//                Inherits the WikipediaHome_PageLocators

using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using TechTalk.SpecFlow;
using WebAutomationTests.PageLocators;
using WebdriverCore.WebDriverCoreFunctionality;
using WebdriverCore.ExtensionMethods;
using System;
using System.Configuration;

namespace WebAutomationTests.PageObjects
{
    public class WikipediaHomePage : WikipediaHome_PageLocators
    {
        private const string PageTitle = "Wikipedia";
        private Uri _pageuri;

        public WikipediaHomePage()
        {
            PageFactory.InitElements(Browser.SearchContext, this);
            _pageuri = new Uri(new Uri(ConfigurationManager.AppSettings["Wikipedia_URL"]), "/");
        }

        /// <summary>
        /// Gets the current page URL as string
        /// </summary>
        /// <returns>Page Url</returns>
        public string GetPageURL()
        {
            return _pageuri.ToString();
        }

        /// <summary>
        /// Set the Wikipedia home page language
        /// </summary>
        /// <param name="p_Language"></param>
        public void SelectSearchLanguage(string p_Language)
        {
            var selectElement = new SelectElement(_select_searchlanguage);
            selectElement.SelectByText(p_Language);
        }

        /// <summary>
        /// Enter the search text into the Wikipedia seach text box.
        /// </summary>
        /// <param name="p_SearchFor"></param>
        public void EnterSearchText(string p_SearchFor)
        {
            _input_searchInput.SendKeysWithClear(p_SearchFor);
        }

        /// <summary>
        /// Submit the search on the Wikipedia Home page
        /// </summary>
        public void SubmitSearch()
        {
            _submit_search.Click();
        }

        /// <summary>
        /// Gets the title of the page
        /// </summary>
        /// <returns>Page title</returns>
        public string GetPageTitle()
        {
            return ScenarioContext.Current.ContainsKey("SEARCH_TEXT") ?
                    $"{(string) ScenarioContext.Current["SEARCH_TEXT"]} - Wikipedia" :
                    PageTitle;
        }
    }
}
