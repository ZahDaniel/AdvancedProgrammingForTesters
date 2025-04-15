namespace DataSaverTests
{
    public class ReadOnlyMemoryStream : DataStream
    {
        private readonly byte[] _buffer;

        public ReadOnlyMemoryStream(byte[] buffer)
        {
            _buffer = buffer ?? throw new ArgumentNullException(nameof(buffer));
        }

        //public override void Write(byte[] data)
        //{
        //    throw new InvalidOperationException("Cannot write to a read-only stream.");
        //}

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
