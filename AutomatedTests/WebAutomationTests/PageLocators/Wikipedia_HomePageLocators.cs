// Author       : Inde Panesar
// Date         : Feb 2017
// Description  : Page element locatiors for Wikipedia Home page.
//                To be inherited by the HomePage object

using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium;

namespace WebAutomationTests.PageLocators
{
    public class WikipediaHome_PageLocators
    {
        [FindsBy(How = How.Id, Using = "searchInput")]
        protected IWebElement _input_searchInput { get; set; }

        [FindsBy(How = How.CssSelector, Using = "i.sprite.svg-search-icon")]
        protected IWebElement _submit_search { get; set; }

        [FindsBy(How = How.Id, Using = "searchLanguage")]
        protected IWebElement _select_searchlanguage { get; set; }

        //[FindsBy(How = How.CssSelector, Using = "#searchLanguage option")]
        //private IList<IWebElement> _select_languageoptions { get; set; }

        //[FindsBy(How = How.CssSelector, Using = ".pure-button.pure-button-primary-progressive")]
        //private IWebElement _button_submit { get; set; }
    }
}
