// Author       : Inde Panesar
// Date         : Feb 2017
// Description  : Page object for Wikipedia Search Results page.
//                Inherits the WikipediaSearchResults_PageLocators

using TechTalk.SpecFlow;
using WebdriverCore.WebDriverCoreFunctionality;
using OpenQA.Selenium.Support.PageObjects;
using WebAutomationTests.PageLocators;

namespace WebAutomationTests.PageObjects
{
    public class Wikipedia_SearchResultsPage : WikipediaSearchResults_PageLocators
    {
        private const string PageTitle = "Wikipedia";

        public Wikipedia_SearchResultsPage()
        {
            PageFactory.InitElements(Browser.SearchContext, this);
        }

        public void EnterSearchText(string p_SearchText)
        {
            //txtUsername.Click();
            //txtUsername.Clear();
            //txtUsername.SendKeys(p_SearchText);
        }


        public void SubmitSearch()
        {
            //btnSubmitSearch.Click();
        }

        public string GetPageTitle()
        {
            return ScenarioContext.Current.ContainsKey("SEARCH_TEXT") ?
                    $"{(string) ScenarioContext.Current["SEARCH_TEXT"]} - Wikipedia" :
                    PageTitle;
        }
    }
}
