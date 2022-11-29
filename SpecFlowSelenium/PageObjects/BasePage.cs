using FluentAssertions;
using Microsoft.VisualBasic;
using NUnit.Framework;
using OpenQA.Selenium;
using SpecFlowSelenium.Support;
using TechTalk.SpecFlow;

namespace SpecFlowSelenium.PageObjects
{
    public abstract class BasePage
    {
        protected readonly IWebDriver WebDriver;
        protected readonly string BaseUrl;

        protected BasePage(ScenarioContext scenarioContext, string pageResource)
        {
            this.WebDriver = scenarioContext.Get<IWebDriver>(ContextKeys.WebDriverKey);
            this.BaseUrl = ContextKeys.AppUrl + pageResource;

            var currentUrl = this.WebDriver.Url;
            if (currentUrl.Equals("data:,"))
            {
                this.NavigateToBaseUrl();
            }
            else if (currentUrl.StartsWith(this.BaseUrl))
            {
                return;
            }
            else
            {
                throw new Exception(String.Format("Cannot instantiate page object based on this url: {0}", this.BaseUrl));
            }
        }

        protected void NavigateToBaseUrl()
        {
            this.WebDriver.Navigate().GoToUrl(BaseUrl);
        }

        protected TimeSpan GetPredefinedImplicitWait => this.WebDriver.Manage().Timeouts().ImplicitWait;
    }
}
