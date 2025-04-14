namespace DataSaverTests
{
    public interface IReadOnlyStream
    {
        byte[] Read(int count);
        void Close();
    }
}
