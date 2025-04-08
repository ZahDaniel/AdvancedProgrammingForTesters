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

            controls.Add("passwordInput",
                    new ControlMetadata(
                        controlType: "input",
                        isVisible: true,
                        isDisabled: false,
                        locators: new List<string>
                        {
                            "//input[@name='paswd']",
                            "//password-input"
                        }));
            PrintControlMetadata(controls, "Controls after update:");

            // Requirement 2: Use TryAdd to add a new control "rememberMeCheckbox"

            controls.TryAdd("rememberMeCheckbox",
                    new ControlMetadata(
                        controlType: "checkbox",
                        isVisible: true,
                        isDisabled: false,
                        locators: new List<string>
                        {
                            "//input[@type='checkbox']",
                            "//label[@name='rememberMeCheckbox']"
                        }));
            PrintControlMetadata(controls, "Controls after update with TryAdd:");

            // Requirement 3: Use indexer to retrieve locators of "loginButton"

            var locators = controls["loginButton"];
            DisplayText($"The locators for login button are: {string.Join(" | ", locators.Locators)}");

            // Requirement 4: Use TryGetValue to safely read data for a key (e.g., "usernameInput")

            if (controls.TryGetValue("usernameInput", out var usernameLocator))
                DisplayText($"The locators for username input are: {string.Join(" | ", usernameLocator.Locators)}");
            else
                DisplayText("TryGetValue failed");

            // Requirement 5: Check if a key exists using ContainsKey

            bool containsPasswordKey = controls.ContainsKey("passwordInput");
            DisplayText(containsPasswordKey ? "Input password control was found" : "Input password control was not found");

            // Requirement 6: Search for a locator and return the control it belongs to

            string locatorToFind = "//password-input";
            string? matchingControl = controls.FirstOrDefault(kpv => kpv.Value.Locators.Contains(locatorToFind)).Key;

            DisplayText(matchingControl != null
                ? $"Locator '{locatorToFind}' belongs to control: {matchingControl}"
                : $"Locator '{locatorToFind}' does not belong to any control");

            // Requirement 7: Add a locator to the "usernameInput" control

            controls["usernameInput"].Locators.Add("//input[@id='username']");
            PrintControlMetadata(controls, "Control locators mapping after adding new locator for usernameInput: ");

            // Requirement 8: Remove a locator from the "loginButton"

            controls["loginButton"].Locators.Remove("//app-login-button");
            PrintControlMetadata(controls, "Control locators mapping after removing //app-login-button from loginButton:");

            // Requirement 9: Remove an entire control by key

            controls.Remove("rememberMeCheckbox");
            PrintControlMetadata(controls, "Control locators mapping after removing rememberMeCheckbox control:");

            // Requirement 10: Display only the keys

            DisplayText("All the existing keys: " + string.Join(", ", controls.Keys));

            // Requirement 11: Display all locators from all controls

            DisplayText("All locators: " + string.Join(" | ", controls.SelectMany(x => x.Value.Locators)));

            // Requirement 12: Count how many controls remain

            DisplayText($"Total controls after all the tests from above: {controls.Count}");

            // Requirement 13: Set the visibility of 'usernameInput' to false

            controls["usernameInput"].SetVisibility(false);

            _output.WriteLine($"The value of isVisible of usernameInput after changing isVisible to false is: {controls["usernameInput"].IsVisible}");

            // Requirement 14: Set the disabled state of 'passwordInput' to true
            controls["passwordInput"].SetDisabled(true);

            _output.WriteLine($"The value of isDisabled of passwordInput after changing isDisabled to true is: {controls["passwordInput"].IsDisabled}");

            // Requirement 15: Display all controls that are disabled

            var disabledControls = controls
            .Where(kpv => kpv.Value.IsDisabled)
            .Select(kpv => kpv.Key)
            .ToList();  

            _output.WriteLine($"The disabled controls are: ");


            foreach ( var disabledControl in disabledControls)
            {
                DisplayText(disabledControl != null
                ? $"{disabledControl}"
                : string.Empty);
            }

            // Requirement 16: Display all controls that are NOT visible

            var controlsNotVisible = controls
            .Where(kpv => kpv.Value.IsVisible == false)
            .Select(kpv => kpv.Key)
            .ToList();

            string displayText = controlsNotVisible.Any()
            ? $"The disabled controls are: {string.Join(", ", controlsNotVisible)}"
            : "There are no disabled controls.";

            DisplayText(displayText);

            // Requirement 17: Count controls that are visible AND not disabled

            var controlsVisibleAndEnabled = controls
            .Where(kpv => kpv.Value.IsDisabled == false && kpv.Value.IsVisible == true)
            .Select(kpv => kpv.Key)
            .ToList();

            int numberOfControls = controlsVisibleAndEnabled.Count;

            _output.WriteLine($"The number of controls visible and enabled is: {numberOfControls}");

            // Requirement 18: Clear the dictionary and verify it's empty

            controls.Clear();
            DisplayText($"The number of controls is: {controls.Count}");
        }
    }
}
