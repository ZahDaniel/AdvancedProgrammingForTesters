using DataSaverTests.Interfaces;

namespace DataSaverTests
{
    public class DataSaverTests
    {
        [Fact]
        public void Save_WritesDataToStream()
        {
            IWriteDataStream stream = new DataStream();
            var saver = new DataSaver(stream);
            saver.Save();
        }
    }
}
