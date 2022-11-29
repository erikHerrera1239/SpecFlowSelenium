using OpenQA.Selenium;
using TechTalk.SpecFlow;
using SpecFlowSelenium.PageObjects;
using NUnit.Framework;
using SpecFlowSelenium.Support;
using FluentAssertions;

namespace SpecFlowSelenium.StepDefinitions
{
    [Binding]
    public class AmazonHomeStepDefinitions : BaseStepsDefinition<HomePage>
    {
        public AmazonHomeStepDefinitions(ScenarioContext scenarioContext) : base(scenarioContext)
        {
        }

        [Given(@"I navigate to Amazon\.com site")]
        public void GivenINavigateToAmazonComSite()
        {
            var locationButtonDisplayed = Utilities.GenericWait(() => this.BasePage.DontChangeLocationButton.Displayed, TimeSpan.FromSeconds(10));
            if (locationButtonDisplayed)
            {
                this.BasePage.DontChangeLocationButton.Click();
            }
        }

        [Then(@"Nav buttons number should be ""([^""]*)""")]
        public void ThenNavButtonsNumberShouldBe(int buttonNumber)
        {
            Assert.IsTrue(
                Utilities.GenericWait(
                    () => {
                        var btns = BasePage.NavButtons;
                        return btns.Count == buttonNumber;
                    },
                    TimeSpan.FromSeconds(10)
                )
            );
        }

        [Then(@"One of the Nav Buttons is ""([^""]*)""")]
        public void ThenOneOfTheNavButtonsIs(string buttonName)
        {
            Assert.IsTrue(this.BasePage.NavButtons.Any(b => b.Text.Contains(buttonName, StringComparison.InvariantCultureIgnoreCase)));
        }

        [When(@"I open hamburguer menu")]
        public void WhenIOpenHamburguerMenu()
        {
            Utilities.GenericWait(() => this.BasePage.HamburgerMenuButton.Click(), TimeSpan.FromSeconds(5));
        }

        [When(@"I open the full Shop By Department section")]
        public void WhenIOpenTheFullSection()
        {
            Utilities.GenericWait(() => this.BasePage.ShopByDepartmentSeeAllSectionButton.Click(), TimeSpan.FromSeconds(5));
        }

        [Then(@"All the following items are present in the list of Shop By Department section")]
        public void ThenAllTheFollowingItemsArePresentInTheListOfSection(List<string> listOfTexts)
        {
            List<IWebElement> listOfButtonsInSection = null;
            var listIsValid = Utilities.GenericWait(
                () =>
                {
                    listOfButtonsInSection = this.BasePage.ButtonsInShopByDepartmentSection;
                    return listOfButtonsInSection != null && listOfButtonsInSection.Count > 0;
                },
                TimeSpan.FromSeconds(5)
            );
            listIsValid.Should().NotBe(false);

            Assert.Multiple(
                () =>
                {
                    foreach (var text in listOfTexts)
                    {
                        Assert.IsTrue(listOfButtonsInSection.Any(b => b.Text.Trim() == text));
                    }
                }
            );
        }

        [Given(@"I open the login page")]
        public void GivenIOpenTheLoginPage()
        {
            Utilities.GenericWait(this.BasePage.AccountListButton.Click, TimeSpan.FromSeconds(20));
        }
    }
}
