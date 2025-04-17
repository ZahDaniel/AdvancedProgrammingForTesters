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

            PrintControlMetadata(controls, "Controls after adding password input:");

            // Requirement 2: Use TryAdd to add a new control "rememberMeCheckbox"
            bool added = controls.TryAdd("rememberMeCheckbox", new ControlMetadata(
                controlType: "checkbox",
                isVisible: true,
                isDisabled: false,
                locators: new List<string>
                {
                    "//input[@name='rememberMe']",
                    "//app-remember-me-checkbox"
                }));

            if (added)
                PrintControlMetadata(controls, "Controls after adding checkbox:");
            else
                DisplayText("TryAdd operation failed");

            // Requirement 3: Use indexer to retrieve locators of "loginButton"
            var locators = controls["loginButton"].Locators;
            DisplayText($"Locators for loginButton: {string.Join(", ", locators)}");

            // Requirement 4: Use TryGetValue to safely read data for a key (e.g., "usernameInput")
            if (controls.TryGetValue("usernameInput", out var usernameInput))
            {
                DisplayText($"Locators for loginButton: {string.Join(", ", locators)}"); // Correct: DisplayText($"Locators for usernameInput: {string.Join(", ", usernameInput.Locators)}");

            }
            else
            {
                DisplayText("Key not found/");
            }

            // Requirement 5: Check if a key exists using ContainsKey
            var loginButtonExists = controls.ContainsKey("loginButton");
            DisplayText(loginButtonExists ? "Key exists in the dictionary" : "Searched key does not exist.");

            // Requirement 6: Search for a locator and return the control it belongs to
            var locatorToSearch = "//input[@name='rememberMe']";
            string? controlFound = controls.FirstOrDefault(c => c.Value.Locators.Contains(locatorToSearch)).Key;

            DisplayText(controlFound != null
                ? $"Locator '{locatorToSearch}' belongs to control: {controlFound}"
                : $"Locator '{locatorToSearch}' not found in any control.");

            // Requirement 7: Add a locator to the "usernameInput" control
            var usernameLocator = "//input[@id='username']";
            controls["usernameInput"].AddLocator(usernameLocator);
            PrintControlMetadata(controls, "Controls after adding locator to usernameInput:");

            // Requirement 8: Remove a locator from the "loginButton"
            controls["loginButton"].RemoveLocator("//app-login-button");
            PrintControlMetadata(controls, "Controls after removing locator from loginButton:");

            // Requirement 9: Remove an entire control by key
            var keyToRemove = "rememberMeCheckbox";
            controls.Remove(keyToRemove);
            PrintControlMetadata(controls, $"Controls after removing {keyToRemove}:");

            // Requirement 10: Display only the keys
            DisplayText("All control keys: " + string.Join(", ", controls.Keys));

            // Requirement 11: Display all locators from all controls
            DisplayText("All control locators: " + string.Join(" | ", controls.SelectMany(x => x.Value.Locators)));

            // Requirement 12: Count how many controls remain
            DisplayText($"Number of controls: {controls.Count}");

            // Requirement 13: Set the visibility of 'usernameInput' to false
            controls["usernameInput"].SetVisibility(false);
            PrintControlMetadata(controls, "Controls after changing visibility of usernameInput:");

            // Requirement 14: Set the disabled state of 'passwordInput' to true
            controls["passwordInput"].SetDisabled(true);
            PrintControlMetadata(controls, "Controls after changing disabled state of passwordInput:");

            // Requirement 15: Display all controls that are disabled
            DisplayText("Disabled controls: " +
                string.Join(", ", controls.Where(c => c.Value.IsDisabled).Select(c => c.Key)));

            // Requirement 16: Display all controls that are NOT visible
            DisplayText("Controls that are not visible: " +
                string.Join(", ", controls.Where(c => !c.Value.IsVisible).Select(c => c.Key)));

            // Requirement 17: Count controls that are visible AND not disabled
            DisplayText($"Number of controls that are visible and not disabled: " +
                $"{controls.Count(c => c.Value.IsVisible && !c.Value.IsDisabled)}");

            // Requirement 18: Clear the dictionary and verify it's empty
            controls.Clear();
            PrintControlMetadata(controls, "Controls after clearing:");
        }
    }
}
