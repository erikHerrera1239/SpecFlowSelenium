using NUnit.Framework;
using OpenQA.Selenium.DevTools.V105.Target;
using SpecFlowSelenium.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace SpecFlowSelenium.StepDefinitions
{
    public abstract class BaseStepsDefinition<TBasePage> where TBasePage : BasePage
    {
        private readonly ScenarioContext _scenarioContext;

        protected TBasePage BasePage => _scenarioContext.Get<TBasePage>();

        protected BaseStepsDefinition(ScenarioContext scenarioContext)
        {
            this._scenarioContext = scenarioContext;
            TBasePage instance = CreateBasePageInstance();
            this._scenarioContext.Set(instance);
        }

        private TBasePage CreateBasePageInstance()
        {
            Type type = typeof(TBasePage);
            return Activator.CreateInstance(type, _scenarioContext) as TBasePage;
        }
    }
}
