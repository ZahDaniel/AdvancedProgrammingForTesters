namespace DataSaverTests.Interface
{
    public interface IWriteDataStream : IDataStream
    {
        void Write(byte[] data);
    }
}
