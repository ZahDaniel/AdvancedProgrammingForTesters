namespace DataSaverTests
{
    public class DataSaverTests
    {
        [Fact]
        public void Save_WritesDataToStream()
        {
            var writeableStream = new DataStream();
            var saver = new DataSaver(writeableStream);

            saver.Save();
        }
    }
}