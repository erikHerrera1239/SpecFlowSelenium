using FluentAssertions;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using SpecFlowSelenium.Drivers;
using SpecFlowSelenium.PageObjects;
using SpecFlowSelenium.Support;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace SpecFlowSelenium.StepDefinitions
{
    [Binding]
    public class AmazonLoginStepDefinitions : BaseStepsDefinition<LoginPage>
    {
        public AmazonLoginStepDefinitions(ScenarioContext scenarioContext) : base(scenarioContext)
        {
        }

        [When(@"I enter ""([^""]*)"" in the email box")]
        public void WhenIEnterInTheEmailBox(string email)
        {
            Assert.IsTrue(Utilities.GenericWait(
                () => this.BasePage.EmailInput.Displayed
                    && this.BasePage.ContinueButton.Displayed,
                TimeSpan.FromSeconds(10))
            );
            this.BasePage.EmailInput.SendKeys(email);
            this.BasePage.ContinueButton.Click();
        }

        [Then(@"An error should be prompted on the top of the login form")]
        public void ThenAnErrorShouldBeProptedOnTheTopOfTheLoginForm()
        {
            var displayed = this.BasePage.NonExistingEmailErrorMessage.Displayed;
            Assert.That(displayed, Is.True);
        }

        [Then(@"An alert message should be prompted below the email input")]
        public void AnAlertMessageShouldBePromptedBelowTheEmailInput(string item)
        {
            var displayed = this.BasePage.EmailMissingAlertMessage.Displayed;
            Assert.That(displayed, Is.True);
            Assert.That(this.BasePage.EmailMissingAlertMessage.Text, Is.EqualTo(item));
        }

        [When(@"I look for help in the page")]
        public void WhenILookForHelpInThePage()
        {
            var elementClickable = this.BasePage.IsNeedHelpDropdownClickable();
            Assert.That(elementClickable, Is.True);
            this.BasePage.NeedHelpDropDown.Click();
        }

        [Then(@"I see the next two available options of help")]
        public void ThenISeeTheNextTwoAvailableOptionsOfHelp(List<string> expectedOptions)
        {
            this.BasePage.NeedHelpOptionsDisplayed.Should().Be(true);
        }

    }
}
