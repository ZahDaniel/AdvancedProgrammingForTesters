namespace DataSaverTests.Interfaces
{
    public interface IReadDataStream
    {
         byte[] Read(int count);
         void Close();
    }
}