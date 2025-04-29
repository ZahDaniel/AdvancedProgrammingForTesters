namespace CourseClassLibrary.Delegates
{
    public class FieldProcessor
    {
        public string TransformField(string fieldValue, Func<string, string> transformer)
        {
            return transformer(fieldValue);
        }

        public void LogField(string fieldValue, Action<string> logger)
        {
            logger(fieldValue);
        }
    }
}