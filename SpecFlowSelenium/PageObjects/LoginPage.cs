using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V105.DOM;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using TechTalk.SpecFlow;

namespace SpecFlowSelenium.PageObjects
{
    public class LoginPage : BasePage
    {
        public LoginPage(ScenarioContext scenarioContext) : base(scenarioContext, "/ap/signin")
        {
        }

        public IWebElement EmailInput => WebDriver.FindElement(By.Id("ap_email"));

        public IWebElement ContinueButton => WebDriver.FindElement(By.Id("continue"));

        public IWebElement NonExistingEmailErrorMessage => WebDriver.FindElement(By.XPath("//h4[text()='There was a problem']"));

        public IWebElement EmailMissingAlertMessage => WebDriver.FindElement(By.Id("auth-email-missing-alert"));

        public IWebElement NeedHelpDropDown => WebDriver.FindElement(NeedHelpDropdownSelector);

        public bool IsNeedHelpDropdownClickable()
        {
            WebDriverWait seleniumWait = new WebDriverWait(this.WebDriver, this.GetPredefinedImplicitWait);
            var element = seleniumWait.Until(ExpectedConditions.ElementToBeClickable(this.NeedHelpDropdownSelector));
            return element != null;
        }

        private By NeedHelpDropdownSelector => By.PartialLinkText("Need help?");

        public bool NeedHelpOptionsDisplayed
        {
            get
            {
                var opt1 = this.WebDriver.FindElement(By.PartialLinkText("Forgot your password?"));
                var opt2 = opt1.FindElement(By.XPath(".//following::a[contains(text(), 'Other issues with Sign-In')]"));
                return opt1.Displayed && opt2.Displayed;
            }
        }
    }
}