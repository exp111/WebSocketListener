using System;
using System.Linq;
using vtortola.WebSockets.Rfc6455.Header;
using Xunit;

namespace vtortola.WebSockets.UnitTests
{
    public class EndianBitConverterTests
    {
        [Fact]
        public void UInt32LeTest()
        {
            var buffer = new byte[512];
            var random = new Random(nameof(UInt32LeTest).Sum(c => c));
            for (int i = 0; i < 1000; i++)
            {
                var expected = (uint)random.Next();
                var offset = random.Next(0, 256);

                EndianBitConverter.UInt32CopyBytesLe(expected, buffer, offset);

                var actual = EndianBitConverter.ToUInt32Le(buffer, offset);

                Assert.Equal(expected, actual);
            }
        }

        [Fact]
        public void UInt64LeTest()
        {
            var buffer = new byte[512];
            var random = new Random(nameof(UInt64LeTest).Sum(c => c));
            for (int i = 0; i < 1000; i++)
            {
                var expected = (((ulong)random.Next()) << 32) | (ulong)random.Next();
                var offset = random.Next(0, 256);

                EndianBitConverter.UInt64CopyBytesLe(expected, buffer, offset);

                var actual = EndianBitConverter.ToUInt64Le(buffer, offset);

                Assert.Equal(expected, actual);
            }
        }

        [Fact]
        public void UInt16BeTest()
        {
            var buffer = new byte[512];
            var random = new Random(nameof(UInt16BeTest).Sum(c => c));
            for (int i = 0; i < 1000; i++)
            {
                var expected = (ushort)random.Next();
                var offset = random.Next(0, 256);

                EndianBitConverter.UInt16CopyBytesBe(expected, buffer, offset);

                var actual = EndianBitConverter.ToUInt16Be(buffer, offset);

                Assert.Equal(expected, actual);
            }
        }

        [Fact]
        public void UInt64BeTest()
        {
            var buffer = new byte[512];
            var random = new Random(nameof(UInt64BeTest).Sum(c => c));
            for (int i = 0; i < 1000; i++)
            {
                var expected = (((ulong)random.Next()) << 32) | (ulong)random.Next();
                var offset = random.Next(0, 256);

                EndianBitConverter.UInt64CopyBytesBe(expected, buffer, offset);

                var actual = EndianBitConverter.ToUInt64Be(buffer, offset);

                Assert.Equal(expected, actual);
            }
        }
    }
}
