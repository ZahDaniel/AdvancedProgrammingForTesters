namespace DataSaverTests
{
    public class ReadOnlyMemoryStream : IReadableStream
    {

        private readonly byte[] _buffer;

        public ReadOnlyMemoryStream(byte[] buffer)
        {
            _buffer = buffer;
        }

        public byte[] Read(int count)
        {
            Console.WriteLine($"Reading {count} bytes from read-only memory buffer.");
            return Enumerable.Repeat((byte)1, count).ToArray();
        }

        public void Close()
        {
            Console.WriteLine("Read-only memory stream closed.");
        }
    }
}
