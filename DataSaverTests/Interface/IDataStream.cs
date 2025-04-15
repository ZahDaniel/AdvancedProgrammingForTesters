namespace DataSaverTests.Interface
{
    public interface IDataStream
    {
        byte[] Read(int count);
        void Close();
    }
}
