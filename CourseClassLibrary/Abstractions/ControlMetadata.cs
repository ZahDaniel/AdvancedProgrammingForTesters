namespace CourseClassLibrary
{
    public class ControlMetadata
    {
        public string ControlType { get; private set; }
        public bool IsVisible { get; private set; }
        public bool IsDisabled { get; private set; }
        public List<string> Locators { get; private set; }
        public DateTime LastUpdated { get; private set; }

        public ControlMetadata(string controlType, bool isVisible, bool isDisabled, List<string> locators)
        {
            ControlType = controlType;
            IsVisible = isVisible;
            IsDisabled = isDisabled;
            Locators = locators ?? new List<string>();
            LastUpdated = DateTime.Now;
        }

        public void SetVisibility(bool isVisible)
        {
            IsVisible = isVisible;
            UpdateTimestamp();
        }

        public void SetDisabled(bool isDisabled)
        {
            IsDisabled = isDisabled;
            UpdateTimestamp();
        }

        public void AddLocator(string locator)
        {
            if (!Locators.Contains(locator))
            {
                Locators.Add(locator);
                UpdateTimestamp();
            }
        }

        public void RemoveLocator(string locator)
        {
            if (Locators.Remove(locator))
                UpdateTimestamp();
        }

        public void UpdateTimestamp()
        {
            LastUpdated = DateTime.Now;
        }

        public string GetSummary()
        {
            var locatorList = Locators.Count > 0 ? string.Join(" | ", Locators) : "No locators";
            return $"ControlType: {ControlType}, Visible: {IsVisible}, Disabled: {IsDisabled}, Locators: [{locatorList}], LastUpdated: {LastUpdated:g}";
        }
    }
}
