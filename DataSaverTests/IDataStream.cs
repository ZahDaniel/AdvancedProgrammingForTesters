namespace DataSaverTests
{
    public interface IDataStream
    {
        byte[] Read(int count);

        void Close();
    }
}