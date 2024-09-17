Feature: Open Selenium Website and Verify Title

  Scenario: Open Selenium website and verify the title
    Given I navigate to the Selenium website
    Then the title of the page should be "Selenium"
