namespace DataSaverTests.Interfaces
{
    public interface IWriteDataStream
    {
        void Write(byte[] data);
        void Close();
    }
}
