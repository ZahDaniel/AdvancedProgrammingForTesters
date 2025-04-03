using CourseClassLibrary;
using Xunit.Abstractions;

namespace Session2
{
    public class ControlsDictionaryTests
    {
        private readonly ITestOutputHelper _output;

        public ControlsDictionaryTests(ITestOutputHelper output)
        {
            _output = output;
        }

        private void PrintControlMetadata(Dictionary<string, ControlMetadata> controls, string? header = null)
        {
            if (!string.IsNullOrEmpty(header))
                _output.WriteLine(header);

            foreach (var kvp in controls)
                _output.WriteLine($"{kvp.Key} => {kvp.Value.GetSummary()}");

            _output.WriteLine(Environment.NewLine);
        }

        private void DisplayText(string text)
        {
            _output.WriteLine(text);
            _output.WriteLine(Environment.NewLine);
        }

        [Fact]
        public void ControlsDictionary_Operations()
        {
            var controls = new Dictionary<string, ControlMetadata>
            {
                {
                    "loginButton",
                    new ControlMetadata(
                        controlType: "button",
                        isVisible: true,
                        isDisabled: false,
                        locators: new List<string>
                        {
                            "//button[@id='login']",
                            "//app-login-button"
                        })
                },
                {
                    "usernameInput",
                    new ControlMetadata(
                        controlType: "input",
                        isVisible: true,
                        isDisabled: false,
                        locators: new List<string>
                        {
                            "//input[@name='username']",
                            "//app-username-input"
                        })
                }
            };

            // Display initial controls
            PrintControlMetadata(controls, "Initial controls:");

            // Requirement 1: Add a new control named "passwordInput" with relevant data

            // Requirement 2: Use TryAdd to add a new control "rememberMeCheckbox"

            // Requirement 3: Use indexer to retrieve locators of "loginButton"

            // Requirement 4: Use TryGetValue to safely read data for a key (e.g., "usernameInput")

            // Requirement 5: Check if a key exists using ContainsKey

            // Requirement 6: Search for a locator and return the control it belongs to

            // Requirement 7: Add a locator to the "usernameInput" control

            // Requirement 8: Remove a locator from the "loginButton"

            // Requirement 9: Remove an entire control by key

            // Requirement 10: Display only the keys

            // Requirement 11: Display all locators from all controls

            // Requirement 12: Count how many controls remain

            // Requirement 13: Set the visibility of 'usernameInput' to false

            // Requirement 14: Set the disabled state of 'passwordInput' to true

            // Requirement 15: Display all controls that are disabled

            // Requirement 16: Display all controls that are NOT visible

            // Requirement 17: Count controls that are visible AND not disabled

            // Requirement 18: Clear the dictionary and verify it's empty
        }
    }
}
