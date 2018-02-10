// Author       : Inde Panesar
// Date         : Feb 2017
// Description  : Some extension method on the IWebElement

using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace WebdriverCore.ExtensionMethods
{
    /// <summary>
    /// Extension methods for the IWebelement inteface
    /// </summary>

    public static class MyWebElementExtension
    {
        /// <summary>
        ///  Is element is displayed
        /// </summary>
        /// <param name="p_Element"></param>
        /// <returns>True if element is displayed</returns>
        public static bool IsDisplayed(this IWebElement p_Element)
        {
            try
            {
                return p_Element.Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        /// <summary>
        /// Scroll to an element in dropdown list with text
        /// </summary>
        /// <param name="p_Element"></param>
        /// <param name="p_Text"></param>
        public static void SelectDropDownListItemByText(this IWebElement p_Element, string p_Text)
        {
            var selectElement = new SelectElement(p_Element);
            selectElement.SelectByText(p_Text);
        }

        /// <summary>
        /// Change focus by clicking element and tabbing
        /// </summary>
        /// <param name="p_Element"></param>
        public static void ChangeFocusByClickingTheInputAndSendingTheTabKey(this IWebElement p_Element)
        {
            p_Element.Click();
            p_Element.SendKeys(Keys.Tab);
        }

        /// <summary>
        /// Element has element class attribute with given class name
        /// </summary>
        /// <param name="p_Element"></param>
        /// <param name="p_ClassName"></param>
        /// <returns>True if element has the class attribute with the given name</returns>
        public static bool HasClass(this IWebElement p_Element, string p_ClassName)
        {
            return p_Element.GetAttribute("class").Contains(p_ClassName);
        }

        /// <summary>
        /// Send keys to element by clearing contents first
        /// </summary>
        /// <param name="p_Element"></param>
        /// <param name="p_Text"></param>
        public static void SendKeysWithClear(this IWebElement p_Element, string p_Text)
        {
            p_Element.Clear();
            p_Element.SendKeys(p_Text);
        }
    }
}
