namespace DataSaverTests
{
    public class DataSaver
    {
        private readonly IWriteableDataStream _stream;

        public DataSaver(IWriteableDataStream stream)
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