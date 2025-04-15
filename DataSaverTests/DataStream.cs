using DataSaverTests.Interfaces;

namespace DataSaverTests
{
    public class DataStream : IReadDataStream, IWriteDataStream
    {
        public virtual void Write(byte[] data)
        {
            Console.WriteLine($"Writing {data.Length} bytes to the stream.");
        }

        public virtual byte[] Read(int count)
        {
            Console.WriteLine($"Reading {count} bytes from the stream.");
            return Enumerable.Repeat((byte)0, count).ToArray();
        }

        public virtual void Close()
        {
            Console.WriteLine("Stream closed.");
        }
    }}
