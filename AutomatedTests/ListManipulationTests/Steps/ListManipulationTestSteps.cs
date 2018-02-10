// Author       : Inde Panesar
// Date         : Feb 2017
// Description  : Test steps for the ListManipulation feature

using FluentAssertions;
using NUnit.Framework;
using System;
using System.Linq;
using TechTalk.SpecFlow;
using LL = ListManipulation.Library;

namespace AutomatedTests.ListManipulationTests
{
    [Binding]
    public class ListManipulationTestSteps
    {
        [Given(@"I have a list of unorderd integers '(.*)'")]
        public void GivenIHaveAListOfUnorderdIntegers(string p_List)
        {
            // Extract the list to an array of integers and save in ScenarioContext
            try
            {
                var numlist = (p_List ?? "").Split(',').Select(int.Parse).ToArray();
                if (ScenarioContext.Current.ContainsKey("LIST"))
                    ScenarioContext.Current.Remove("LIST");
                ScenarioContext.Current.Set(numlist, "LIST");
            }
            catch (Exception err)
            {
                Assert.Fail($"Unable to parse the int list error: {err}");
            }
        }

        [When(@"I process the list for the largest orderd list")]
        public void WhenIProcessTheListForTheLargestOrderdList()
        {
            // Get the list saved in the Scenario context
            var intList = (int[]) ScenarioContext.Current["LIST"];

            intList.Should().NotBeNullOrEmpty();

            var ttListOrdering = new LL.ListManipulation();
            var largestOrderList = ttListOrdering.GetLargestOrderList(intList).ToArray();

            largestOrderList.Should().NotBeNullOrEmpty();
            // Extract the list to an array of integers and save in ScenarioContext
            if (ScenarioContext.Current.ContainsKey("LARGEST_LIST"))
                ScenarioContext.Current.Remove("LARGET_LIST");
            ScenarioContext.Current.Set(largestOrderList, "LARGEST_LIST");
        }

        [Then(@"I am given the first largest sublist and its size as '(.*)' '(.*)'")]
        public void ThenIAmGivenTheFirstLargestSublistAndItsSizeAs(string p_LargestSub, int p_Size)
        {
            var expectedlist = (p_LargestSub ?? "").Split(',').Select(int.Parse).ToArray();
            expectedlist.Should().NotBeNullOrEmpty();

            // Get the sublist from ScenarioContext
            var actuallist = (int[])ScenarioContext.Current["LARGEST_LIST"];

            actuallist.Should().NotBeNullOrEmpty();
            actuallist.Should().Equal(expectedlist);
            actuallist.Max().Should().Equals(p_Size);
        }
    }
}
