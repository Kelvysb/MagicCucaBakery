using FluentAssertions;
using MagicCucaBakeryAPI.Automation.Models;
using MagicCucaBakeryAPI.Automation.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting.Logging;
using TechTalk.SpecFlow;

namespace MagicCucaBakeryAPI.Specs.StepDefinitions
{
    [Binding]
    [Scope(Scenario = @"(.*)")]
    public abstract class CommonSteps
    {
        protected readonly ServiceContext context = ServiceContext.GetInstance();

        [Given(@"that I'm logged in the system, with following user:")]
        public void GivenThatImLoggedInTheSystem(Table users)
        {
            string userName;
            string password;
            ApiResult result = null;

            if (string.IsNullOrEmpty(context.Token))
            {
                foreach (TableRow row in users.Rows)
                {
                    row.TryGetValue("UserName", out userName);
                    row.TryGetValue("Password", out password);
                    result = context.Service.Login(userName, password);
                    if(result.ResultCode.Equals("Ok", System.StringComparison.InvariantCultureIgnoreCase))
                    {
                        break;
                    }
                }
                result.ResultCode.Should().BeEquivalentTo("Ok");
            }
        }

        [Given(@"that I'm not logged in the system")]
        public void GivenThatImNotLoggedInTheSystem()
        {
            context.Clear();
        }

        [Then(@"the result should be (.*)")]
        public void ThenTheResultShouldBe(string httpStatus)
        {
            context.LastResult.Should().NotBeNull();

            if(httpStatus.Equals("success", System.StringComparison.InvariantCultureIgnoreCase))
            {
                context.LastResult.ResultCode.Should().BeEquivalentTo("Ok");
            }
            else
            {
                context.LastResult.ResultCode.Should().BeEquivalentTo(httpStatus);
            }

            Logger.LogMessage($"Http status: {httpStatus}");
        }
    }
}
