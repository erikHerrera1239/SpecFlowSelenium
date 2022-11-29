using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using SpecFlowSelenium.Drivers;
using SpecFlowSelenium.Support;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace SpecFlowSelenium.Hooks
{
    [Binding]
    public class Hooks
    {
        private ScenarioContext _scenarioContext;

        public Hooks(ScenarioContext scenarioContext)
        {
            this._scenarioContext = scenarioContext;
        }

        [BeforeScenario]
        public void InitializeWebDriver()
        {
            Driver _ = new(_scenarioContext);
        }

        [AfterScenario]
        public void DisponseWebDriver()
        {
            this._scenarioContext.Get<IWebDriver>(ContextKeys.WebDriverKey).Quit();
        }
    }
}
