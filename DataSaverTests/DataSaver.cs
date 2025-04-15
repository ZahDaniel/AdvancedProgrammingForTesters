using DataSaverTests.Interfaces;

namespace DataSaverTests
{
    public class DataSaver
    {
        //DIP
        private readonly IWriteDataStream _stream;

        public DataSaver(IWriteDataStream stream)
        {
            _stream = stream;
        }

        public void Save()
        {
            Console.WriteLine("Saving data...");
            _stream.Write(new byte[] { 1, 2, 3 });
            _stream.Close();
            Console.WriteLine("Save completed.");
        }
    }
}
