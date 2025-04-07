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
            bool added = controls.TryAdd("rememberMeCheckbox", new ControlMetadata(
                controlType: "checkbox",
                isVisible: true,
                isDisabled: false,
                locators: new List<string>
                {
                    "//input[@type='checkbox']",
                    "//app-remember-me-checkbox"
                }));

            // Requirement 3: Use indexer to retrieve locators of "loginButton"
            var loginButtonLocators = controls["loginButton"];
            DisplayText($"Button locators are: {string.Join(" | ", loginButtonLocators.Locators)}");

            // Requirement 4: Use TryGetValue to safely read data for a key (e.g., "usernameInput")
            if (controls.TryGetValue("usernameInput", out var usernameInput))
            {
                DisplayText($"Control Type: {usernameInput.ControlType}, Is Visible: {usernameInput.IsVisible}, Is Disabled: {usernameInput.IsDisabled}, Locators: {string.Join(" | ", usernameInput.Locators)}");
            }
            else
            {
                DisplayText("'usernameInput' not found.");
            }

            // Requirement 5: Check if a key exists using ContainsKey
            if (controls.ContainsKey("loginButton"))
            {
                DisplayText("'loginButton' exists in the dictionary.");
            }
            else
            {
                DisplayText("'loginButton' does not exist in the dictionary.");
            }

            // Requirement 6: Search for a locator and return the control it belongs to
            string searchLocator = "//input[@name='username']";
            var foundControl = controls.FirstOrDefault(kvp => kvp.Value.Locators.Contains(searchLocator));
            if (foundControl.Key != null)
            {
                DisplayText($"Locator '{searchLocator}' belongs to control '{foundControl.Key}'.");
            }
            else
            {
                DisplayText($"Locator '{searchLocator}' not found in any control.");
            }

            // Requirement 7: Add a locator to the "usernameInput" control
            if (controls.TryGetValue("usernameInput", out var usernameInputControl))
            {
                usernameInputControl.AddLocator("//app-username-input-new");
                DisplayText($"New locator added to 'usernameInput': {string.Join(", ", usernameInputControl.Locators)}");
            }
            else
            {
                DisplayText("'usernameInput' not found.");
            }

            // Requirement 8: Remove a locator from the "loginButton"
            if (controls.TryGetValue("loginButton", out var loginButtonControl))
            {
                loginButtonControl.RemoveLocator("//app-login-button");
                DisplayText($"Locator removed from 'loginButton': {string.Join(", ", loginButtonControl.Locators)}");
            }
            else
            {
                DisplayText("'loginButton' not found.");
            }

            // Requirement 9: Remove an entire control by key
            if (controls.Remove("rememberMeCheckbox"))
            {
                DisplayText("'rememberMeCheckbox' removed from the dictionary.");
            }
            else
            {
                DisplayText("'rememberMeCheckbox' not found.");
            }

            // Requirement 10: Display only the keys
            var controlKeys = controls.Keys.ToList();
            DisplayText($"Control keys: {string.Join(", ", controlKeys)}");
            foreach (var key in controlKeys) {
                if (controls.TryGetValue(key, out var control))
                {
                    DisplayText($"Control '{key}' => {control.GetSummary()}");
                }
            }

            // Requirement 11: Display all locators from all controls
            var allLocators = controls.SelectMany(kvp => kvp.Value.Locators).Distinct().ToList();
            DisplayText($"All locators: {string.Join(", ", allLocators)}");

            // Requirement 12: Count how many controls remain
            int controlCount = controls.Count;
            DisplayText($"Total number of controls: {controlCount}");

            // Requirement 13: Set the visibility of 'usernameInput' to false
            if (controls.TryGetValue("usernameInput", out var usernameInputControl2))
            {
                usernameInputControl2.SetVisibility(false);
                DisplayText($"'usernameInput' visibility set to false.");
            }
            else
            {
                DisplayText("'usernameInput' not found.");
            }

            // Requirement 14: Set the disabled state of 'passwordInput' to true
            if (controls.TryGetValue("passwordInput", out var passwordInputControl))
            {
                passwordInputControl.SetDisabled(true);
                DisplayText($"'passwordInput' disabled state set to true.");
            }
            else
            {
                DisplayText("'passwordInput' not found.");
            }

            // Requirement 15: Display all controls that are disabled
            var disabledControls = controls.Where(kvp => kvp.Value.IsDisabled).ToList();
            DisplayText("Disabled controls:");
            foreach (var kvp in disabledControls)
            {
                DisplayText($"{kvp.Key} => {kvp.Value.GetSummary()}");
            }

            // Requirement 16: Display all controls that are NOT visible
            var notVisibleControls = controls.Where(kvp => !kvp.Value.IsVisible).ToList();
            DisplayText("Controls that are NOT visible:");
            foreach (var kvp in notVisibleControls)
            {
                DisplayText($"{kvp.Key} => {kvp.Value.GetSummary()}");
            }

            // Requirement 17: Count controls that are visible AND not disabled
            var visibleAndNotDisabledCount = controls.Count(kvp => kvp.Value.IsVisible && !kvp.Value.IsDisabled);
            DisplayText($"Number of controls that are visible AND not disabled: {visibleAndNotDisabledCount}");

            // Requirement 18: Clear the dictionary and verify it's empty
            controls.Clear();
            if (controls.Count == 0)
            {
                DisplayText("Controls dictionary cleared. It is now empty.");
            }
            else
            {
                DisplayText("Controls dictionary is not empty.");
            }
        }
    }
}