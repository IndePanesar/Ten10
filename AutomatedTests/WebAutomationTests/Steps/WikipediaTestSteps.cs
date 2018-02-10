// Author       : Inde Panesar
// Date         : Feb 2017
// Description  : Test steps for the Wikipedia Test feature

using TechTalk.SpecFlow;
using WebdriverCore.WebDriverCoreFunctionality;
using System.Configuration;
using WebAutomationTests.PageObjects;

namespace AutomatedTests.WebAutomationTests.Steps
{
    [Binding]
    public class WikipediaTestSteps
    {
        private WikipediaHomePage _wikipediahomepage;
        private Wikipedia_SearchResultsPage _wikipediasearchresultspage;

        [Given(@"I am on the Wikipedia home page")]
        public void GivenIAmOnTheWikipediaHomePage()
        {
            Browser.GoToUrl(ConfigurationManager.AppSettings["TT_Url"]);
        }

        [When(@"I enter search text '(.*)'")]
        public void WhenIEnterSearchText(string p_SearchText)
        {

        }

        [When(@"I choose language '(.*)'")]
        public void WhenIChooseLanguage(string p0)
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"I submit the search")]
        public void WhenISubmitTheSearch()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"the Wikipedia search results page is displayed")]
        public void ThenTheWikipediaSearchResultsPageIsDisplayed()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"the main header text contains my search text")]
        public void ThenTheMainHeaderTextContainsMySearchText()
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"I change the search result page language to '(.*)'")]
        public void WhenIChangeTheSearchResultPageLanguageTo(string p0)
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"the link to my prvious language page is available")]
        public void ThenTheLinkToMyPrviousLanguagePageIsAvailable()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
