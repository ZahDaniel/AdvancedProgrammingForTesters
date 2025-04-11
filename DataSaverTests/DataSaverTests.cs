namespace DataSaverTests
{
    public class DataSaverTests
    {
        [Fact]
        public void Save_WritesDataToStream()
        {
            var readOnlyStream = new ReadOnlyMemoryStream(new byte[] { 10, 20, 30 });
            var saver = new DataSaver(readOnlyStream);

            saver.Save();
        }
    }
}
