namespace DataSaverTests
{
    public class DataSaverTests
    {
        [Fact]
        public void Save_WritesDataToStream()
        {
            // Liskov Substitution Principle, fixed by creating a new interface for read-only streams and another interface for writable streams
            var readOnlyStream = new ReadOnlyMemoryStream(new byte[] { 10, 20, 30 });
            var dataStream = new DataStream();
            var saver = new DataSaver(dataStream);

            saver.Save();
        }
    }
}
