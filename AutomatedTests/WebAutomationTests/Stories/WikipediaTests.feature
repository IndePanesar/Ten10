Feature: Ten10 Web automation Wikipedia tests

Scenario: Search for an item on Wikipedia website and change the language
	Given I am on the Wikipedia home page
	When I enter search text 'apple'
	And I choose language 'English'
	When I submit the search
	Then the Wikipedia search results page is displayed
	And the main header text contains my search text
	When I change the search result page language to 'Italiano'
	Then the Wikipedia search results page is displayed
	And the main header text contains my search text
	And the link to my prvious language page is available 