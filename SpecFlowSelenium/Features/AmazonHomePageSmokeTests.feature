@Smoke
Feature: Smoke tests of Amazon.com
I am a non-registered user of amazon
I should be able to interact with all available items/fucntions of the site
Background:
	Given I navigate to Amazon.com site

Scenario: Validate Nav Buttons are present
	Then Nav buttons number should be "6"
	And One of the Nav Buttons is "Customer Service"

Scenario: Validate Shop By Department Menu Section
	When I open hamburguer menu
		And I open the full Shop By Department section
	Then All the following items are present in the list of Shop By Department section
		| ListItem                |
		| Electronics         |
		| Baby                |
		| Men's Fashion       |
		| Luggage             |
		| Movies & Television |
		| Software            |