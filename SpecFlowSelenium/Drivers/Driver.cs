using Microsoft.VisualBasic;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using SpecFlowSelenium.Support;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace SpecFlowSelenium.Drivers
{
    public class Driver
    {
        private ScenarioContext _scenarioContext;

        public Driver(ScenarioContext scenarioContext)
        {
            this._scenarioContext = scenarioContext;

            var webDriver = new ChromeDriver();
            webDriver.Manage().Window.Maximize();
            webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            this._scenarioContext.Set(webDriver, ContextKeys.WebDriverKey);
        }
    }
}
