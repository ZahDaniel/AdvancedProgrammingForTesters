using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataSaverTests
{

    public class WritableMemoryStream : IWritableStream
    {
        public void Write(byte[] data)
        {
            Console.WriteLine($"Writing {data.Length} bytes to the stream.");
        }

        public void Close()
        {
            Console.WriteLine("Stream closed.");
        }
    }
}
