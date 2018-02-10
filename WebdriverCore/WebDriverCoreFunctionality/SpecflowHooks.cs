// Author       : Inde Panesar
// Date         : Feb 2017
// Description  : Static class for specflow hooks

using TechTalk.SpecFlow;

namespace WebdriverCore.WebDriverCoreFunctionality
{
    [Binding]
    public static class SpecflowHooks
    {
        [BeforeTestRun]
        public static void BeforeTestRun()
        {
        }

        [BeforeScenario("ListOrdering")]
        public static void BeforeScenario()
        {
            ScenarioContext.Current.Clear();
        }

        [BeforeStep]
        public static void BeforeStep()
        {

        }

        [AfterStep]
        public static void AfterStep()
        {
        }

        [AfterScenario]
        public static void AfterScenario()
        {
            ScenarioContext.Current.Clear();
            Browser.DeleteCookies();
            Browser.Close();
        }

        [AfterTestRun]
        public static void AfterRunScenario()
        {
        }
    }
}