using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V105.DOM;
using TechTalk.SpecFlow;

namespace SpecFlowSelenium.PageObjects
{
    public class HomePage : BasePage
    {
        public HomePage(ScenarioContext scenarioContext) : base(scenarioContext, "/")
        {
        }

        public IWebElement GiftCardsNavButton => WebDriver.FindElement(By.XPath("//div[@id='nav-xshop']/a[text()='Gift Cards']"));

        public List<IWebElement> NavButtons => WebDriver.FindElements(By.XPath("//div[@id='nav-xshop']/a")).ToList();

        public IWebElement DontChangeLocationButton => WebDriver.FindElement(By.XPath("//input[@type='submit' and ./following-sibling::*[contains(text(), ' Don')]]"));

        public IWebElement HamburgerMenuButton => WebDriver.FindElement(By.Id("nav-hamburger-menu"));

        public IWebElement ShopByDepartmentSeeAllSectionButton => WebDriver.FindElement(By.XPath("(//*[text()=\"see all\"])[1]"));

        public List<IWebElement> ButtonsInShopByDepartmentSection => WebDriver.FindElements(By.XPath("//li[a[@class='hmenu-item' and div and i] and self::li//preceding::li/child::div[contains(@class, 'hmenu-title') and contains(text(), 'shop by department')] and self::li//following::li/child::div[contains(@class, 'hmenu-title') and contains(text(), 'programs')]]\r\n")).ToList();

        public IWebElement AccountListButton => WebDriver.FindElement(By.Id("nav-link-accountList"));
    }
}
