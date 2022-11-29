@Smoke
@Login
Feature: Amazon Login Smoke Tests

Soft Tests small functions of Login Page

Background:
	Given I navigate to Amazon.com site

@NegativeTest
Scenario Outline: Error Message when using non-registered email
		And I open the login page
	When I enter "<email>" in the email box
	Then An error should be prompted on the top of the login form

	Examples:
	| email                      |
	| erik.herrera@unosquare.com |
	| ea1955484511ssas@gmail.com |
	| blablaba@bblablamail.com   |

@NegativeTest
Scenario Outline: Error Message when using empty email
		And I open the login page
	When I enter "" in the email box
	Then An alert message should be prompted below the email input
	| AlertText |
	| Enter your email or mobile phone number |

Scenario Outline: Help Options are available in Login Page
		And I open the login page
	When I look for help in the page
	Then I see the next two available options of help
	| ListItem |
	| Forgot your password? |
	| Other issues with Sign-In |