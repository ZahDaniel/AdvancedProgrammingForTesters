using DataSaverTests.Interface;

namespace DataSaverTests
{
    public class DataSaver
    {
        //private readonly DataStream _stream;
        private readonly IWriteDataStream _writeDataStream;

        public DataSaver(IWriteDataStream writeDataStream)
        {
            _writeDataStream = writeDataStream;
        }

        public void Save()
        {
            Console.WriteLine("Saving data...");
            _writeDataStream.Write(new byte[] { 1, 2, 3 });
            _writeDataStream.Close();
            Console.WriteLine("Save completed.");
        }
    }
}
