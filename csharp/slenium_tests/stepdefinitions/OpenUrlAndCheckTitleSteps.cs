using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using selenium_tests.Hooks;

namespace selenium_tests.StepDefinitions
{
    [Binding]
    public class OpenUrlAndCheckTitleSteps
    {
        private readonly IWebDriver _driver;
        private readonly string? _baseUrl;



        // Constructor Injection from Hooks
        public OpenUrlAndCheckTitleSteps(Hooks.Hooks hooks)
        {
            _driver = hooks.GetDriver();
            // read url from config.properties

            _baseUrl = PropertiesReader.GetProperty("baseUrl");

            if (_baseUrl == null)
            {
                throw new InvalidOperationException("Base URL is not set in the config.properties file.");
            }
        }

        [Given(@"I navigate to the Selenium website")]
        public void GivenINavigateToTheSeleniumWebsite()
        {

            _driver.Navigate().GoToUrl(_baseUrl);
        }

        [Then(@"the title of the page should be ""(.*)""")]
        public void ThenTheTitleOfThePageShouldBe(string expectedTitle)
        {
            Assert.That(_driver.Title, Is.EqualTo(expectedTitle));
        }
    }
}
