namespace DataSaverTests
{
    public interface IWriteDataStream : IDataStream
    {
        void Write(byte[] data);
    }
}