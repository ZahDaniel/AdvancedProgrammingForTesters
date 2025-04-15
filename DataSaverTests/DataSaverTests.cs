namespace DataSaverTests
{
    public class DataSaverTests
    {
        [Fact]
        public void Save_WritesDataToStream()
        {
            var writableStream = new WritableMemoryStream();
            var saver = new DataSaver(writableStream);

            saver.Save();
        }
    }
}
