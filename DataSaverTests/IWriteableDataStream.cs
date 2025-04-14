namespace DataSaverTests
{
    public interface IWriteableDataStream : IDataStream
    {
        void Write(byte[] data);
    }
}