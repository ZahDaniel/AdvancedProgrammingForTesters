namespace DataSaverTests
{
    public interface IWritableStream
    {
        void Close();
        void Write(byte[] data);
    }
}