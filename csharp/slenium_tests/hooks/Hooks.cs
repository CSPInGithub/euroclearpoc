using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;

namespace selenium_tests.Hooks
{
    [Binding]
    public class Hooks
    {
        // WebDriver shared instance
        private IWebDriver? _driver;

        // Initialize WebDriver before each scenario
        [BeforeScenario]
        public void StartBrowser()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Window.Maximize();
        }

        // Cleanup WebDriver after each scenario
        [AfterScenario]
        public void CloseBrowser()
        {
            _driver?.Quit();
        }

        // Expose WebDriver to Step Definitions
        public IWebDriver GetDriver() => _driver!;
    }
}
