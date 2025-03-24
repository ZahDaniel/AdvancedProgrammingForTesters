namespace CourseClassLibrary
{
    public struct PageCount
    {
        public int Value { get; }

        public PageCount(int value)
        {
            Value = value;
        }

        public string GetPageCount() => $"{Value} pages";
    }
}
