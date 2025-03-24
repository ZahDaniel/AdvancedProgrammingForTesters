namespace CourseClassLibrary
{
    public struct PageCount
    {
        public int Value { get; }

        public PageCount(int value)
        {
            Value = value;
        }

        public string GetNumberOfPages() => $"{Value} pages";
    }
}
