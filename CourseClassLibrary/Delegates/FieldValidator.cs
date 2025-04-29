namespace CourseClassLibrary.Delegates
{
    public class FieldValidator
    {
        public bool IsNotEmpty(string input) => !string.IsNullOrWhiteSpace(input);

        public bool HasMinimumLength(string input) => input.Length >= 5;

        public bool IsAllUppercase(string input) => input == input.ToUpper();
    }

    public delegate bool ValidationStrategy(string input);
}
