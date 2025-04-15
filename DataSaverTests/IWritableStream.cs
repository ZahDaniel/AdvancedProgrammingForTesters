namespace DataSaverTests
{
    public interface IWritableStream
    {
        void Write(byte[] data);
        void Close();
    }
}

