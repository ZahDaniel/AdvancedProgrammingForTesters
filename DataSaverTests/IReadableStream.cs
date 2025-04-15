namespace DataSaverTests
{

    public interface IReadableStream
    {
        byte[] Read(int count);
        void Close();
    }

}
