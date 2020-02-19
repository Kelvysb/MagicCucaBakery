using MagicCucaBakeryAPI.Automation.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting.Logging;
using TechTalk.SpecFlow;

namespace MagicCucaBakeryAPI.Specs.StepDefinitions
{
    [Binding]
    [Scope(Scenario = @"Login into the system")]
    [Scope(Scenario = @"Login into the system with wrong password")]
    public class LoginSteps : CommonSteps
    {
        [When(@"I Request the login with the following user name: (.*) and the following password: (.*)")]
        public void ResultSuccsses(string userName, string password)
        {
            context.Service.Login(userName, password);           
            Logger.LogMessage($"Login: {userName} - {password}");
        }
    }
}
