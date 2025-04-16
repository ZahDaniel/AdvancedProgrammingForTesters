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
            controls.Add("passwordInput", new ControlMetadata(
                controlType: "input",
                isVisible: true,
                isDisabled: false,
                locators: new List<string>
                {
                    "//input[@name='password']",
                    "//app-password-input"
                }));

            // Requirement 2: Use TryAdd to add a new control "rememberMeCheckbox"
            controls.TryAdd("rememberMeCheckbox", new ControlMetadata(
                controlType: "checkbox",
                isVisible: true,
                isDisabled: false,
                locators: new List<string>
                {
                    "//input[@name='remember']",
                    "//app-remember-me-checkbox"
                }));

            // Requirement 3: Use indexer to retrieve locators of "loginButton"
            var loginButtonLocators = controls["loginButton"].Locators;
            DisplayText($"Locators for 'loginButton': {string.Join(", ", loginButtonLocators)}");

            // Requirement 4: Use TryGetValue to safely read data for a key (e.g., "usernameInput")
            if (controls.TryGetValue("usernameInput", out var usernameInput))
            {
                DisplayText($"Control 'usernameInput' found: {usernameInput.GetSummary()}");
            }
            else
            {
                DisplayText($"Control 'usernameInput' not found.");
            }

            // Requirement 5: Check if a key exists using ContainsKey
            bool hasLoginButton = controls.ContainsKey("loginButton");
            DisplayText(hasLoginButton ? "LoginButton exists" : "LoginButton does not exist");

            // Requirement 6: Search for a locator and return the control it belongs to
            string searchLocator = "//input[@name='username']";
            var foundControl = controls.FirstOrDefault(c => c.Value.Locators.Contains(searchLocator));
            if (foundControl.Key != null)
            {
                DisplayText($"Locator '{searchLocator}' belongs to control: {foundControl.Key}");
            }
            else
            {
                DisplayText($"Locator '{searchLocator}' not found in any control.");
            }

            // Requirement 7: Add a locator to the "usernameInput" control
            controls["usernameInput"].AddLocator("//input[@id='username']");

            // Requirement 8: Remove a locator from the "loginButton"
            controls["loginButton"].RemoveLocator("//app-login-button");

            // Requirement 9: Remove an entire control by key
            controls.Remove("rememberMeCheckbox");

            // Requirement 10: Display only the keys
            DisplayText($"Control keys: {string.Join(" | ", controls.Keys)}");

            // Requirement 11: Display all locators from all controls
            var allLocators = controls.SelectMany(kvp => kvp.Value.Locators).ToList();
            DisplayText($"All locators: {string.Join(" | ", allLocators)}");

            // Requirement 12: Count how many controls remain   
            int controlCount = controls.Count;

            // Requirement 13: Set the visibility of 'usernameInput' to false
            controls["usernameInput"].SetVisibility(false);

            // Requirement 14: Set the disabled state of 'passwordInput' to true
            controls["passwordInput"].SetDisabled(true);

            // Requirement 15: Display all controls that are disabled
            var disabledControls = controls.Where(kvp => kvp.Value.IsDisabled).Select(kvp => kvp.Key).ToList();
            DisplayText($"Disabled controls: {string.Join(" | ", disabledControls)}");

            // Requirement 16: Display all controls that are NOT visible
            var notVisibleControls = controls.Where(kvp => !kvp.Value.IsVisible).Select(kvp => kvp.Key).ToList();
            DisplayText($"Not visible controls: {string.Join(" | ", notVisibleControls)}");

            // Requirement 17: Count controls that are visible AND not disabled
            var visibleAndNotDisabledCount = controls.Count(kvp => kvp.Value.IsVisible && !kvp.Value.IsDisabled);
            DisplayText($"Visible and not disabled controls count: {visibleAndNotDisabledCount}");

            // Requirement 18: Clear the dictionary and verify it's empty
            controls.Clear();
            DisplayText($"Controls dictionary is {(controls.Count == 0 ? "empty" : "not empty")}");
        }
    }
}
