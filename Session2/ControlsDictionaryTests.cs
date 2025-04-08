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
                }
                ));

            PrintControlMetadata(controls, "Controls after adding passwordInput:");

            // Requirement 2: Use TryAdd to add a new control "rememberMeCheckbox" -- safe add
            bool added = controls.TryAdd("rememberMeCheckbox", new ControlMetadata(
                controlType: "checkbox",
                isVisible: true,
                isDisabled: false,
                locators: new List<string>
                {
                    "//input[@name='checkbox']",
                    "//app-remember-me-checkbox"
                }
            ));

            if (added)
                PrintControlMetadata(controls, "Controls after adding rememberMeCheckbox:");
            else
                DisplayText("Try add failed");

            // Requirement 3: Use indexer to retrieve locators of "loginButton"
            var loginButonLocators = controls["loginButton"];
            DisplayText($"Button locators are: {string.Join(" | ", loginButonLocators.Locators)}");

            // Requirement 4: Use TryGetValue to safely read data for a key (e.g., "usernameInput")
            if(controls.TryGetValue("abc", out var usernameInput))
                DisplayText($"Username input locators are: {string.Join(" | ", usernameInput.Locators)}");
            else
                DisplayText("Key not found");

            // Requirement 5: Check if a key exists using ContainsKey
            bool hasPasswordInput = controls.ContainsKey("passwordInput");
            DisplayText(hasPasswordInput ? "passwordInput control was found" : "passwordInput was not found");

            // Requirement 6: Search for a locator and return the control it belongs to
            string locatorToFind = "//app-username-input";
            string? controlKey = controls.FirstOrDefault(c => c.Value.Locators.Contains(locatorToFind)).Key;

            DisplayText(controlKey != null
                ? $"Locator '{locatorToFind}' belongs to control '{controlKey}'"
                : $"Locator '{locatorToFind}' does not belong to any control");

            // Requirement 7: Add a locator to the "usernameInput" control
            controls["usernameInput"].AddLocator("//span//span");
            PrintControlMetadata(controls, "Controls after adding a locator to usernameInput:");

            // Requirement 8: Remove a locator from the "loginButton"
            controls["loginButton"].RemoveLocator("//app-login-button");
            PrintControlMetadata(controls, "Controls after removing a locator from loginButton:");

            // Requirement 9: Remove an entire control by key
            controls.Remove("rememberMeCheckbox");
            PrintControlMetadata(controls, "Controls after removing rememberMeCheckbox:");

            // Requirement 10: Display only the keys
            DisplayText("Control keys:" + string.Join(", ", controls.Keys));

            // Requirement 11: Display all locators from all controls
            DisplayText("All locators: " + string.Join(" | ", controls.Values.SelectMany(c => c.Locators)));

            // Requirement 12: Count how many controls remain
            DisplayText($"Total controls: {controls.Count}");

            // Requirement 13: Set the visibility of 'usernameInput' to false
            controls["usernameInput"].SetVisibility(false);
            PrintControlMetadata(controls, "Controls after setting usernameInput visibility to false:");

            // Requirement 14: Set the disabled state of 'passwordInput' to true
            controls["passwordInput"].SetDisabled(true);
            PrintControlMetadata(controls, "Controls after setting passwordInput to disabled:");

            // Requirement 15: Display all controls that are disabled
            var disabledControls = controls.Where(c => c.Value.IsDisabled);
            DisplayText("Disabled controls: " + string.Join(", ", disabledControls.Select(c => c.Key)));

            // Requirement 16: Display all controls that are NOT visible
            var notVisibleControls = controls.Where(c => !c.Value.IsVisible);
            DisplayText("Controls that are not visible: " + string.Join(", ", notVisibleControls.Select(c => c.Key)));

            // Requirement 17: Count controls that are visible AND not disabled
            var visibleAndNotDisabledCount = controls.Count(c => c.Value.IsVisible && !c.Value.IsDisabled);
            DisplayText($"Controls that are visible and not disabled: {visibleAndNotDisabledCount} ");

            // Requirement 18: Clear the dictionary and verify it's empty
            controls.Clear();
            DisplayText($"Controls count after clearing: {controls.Count}");
        }
    }
}
