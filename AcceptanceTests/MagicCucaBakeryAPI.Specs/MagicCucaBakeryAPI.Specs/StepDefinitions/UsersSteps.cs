using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting.Logging;
using System.Text.Json;
using TechTalk.SpecFlow;

namespace MagicCucaBakeryAPI.Specs.StepDefinitions
{
    [Binding]
    [Scope(Scenario = @"Retrieve list of registered users")]
    [Scope(Scenario = @"Retrieve list of registered users not being logged on the system")]
    public class UsersSteps : CommonSteps
    {
        [When(@"I request users from the users endpoint")]
        public void IRequestUsersFromTheUsersEndpoint()
        {
            context.Service.GetUsers(context.Token);
            Logger.LogMessage($"Retrieve users");
        }

        [Then(@"I receive an user list")]
        public void IReceiveAnUserList()
        {
            JsonDocument json = JsonDocument.Parse(context.LastResult.Result);
            json.RootElement.GetArrayLength().Should().BeGreaterThan(0);
            json.RootElement[0].GetProperty("login").GetString().Should().BeEquivalentTo("Admin");
            Logger.LogMessage($"Retrieve users");
        }
    }
}
