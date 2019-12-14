using System;

namespace UnsafeAndSpanExtension
{
#if NETSTANDARD2_0
    public static class SystemIOExtension
    {
        public static int Read(this System.IO.BinaryReader binaryReader, Span<char> buffer)
        {
            var arr = new char[buffer.Length];
            var readBytes = binaryReader.Read(arr, 0, arr.Length);
            arr.AsSpan().CopyTo(buffer);
            return readBytes;
        }

        public static int Read(this System.IO.BinaryReader binaryReader, Span<byte> buffer)
        {
            var arr = new byte[buffer.Length];
            var readBytes = binaryReader.Read(arr, 0, arr.Length);
            arr.AsSpan().CopyTo(buffer);
            return readBytes;
        }

        public static void Write(this System.IO.BinaryWriter binaryWriter, ReadOnlySpan<char> buffer)
        {
            var arr = buffer.ToArray();
            binaryWriter.Write(arr, 0, arr.Length);
        }

        public static void Write(this System.IO.BinaryWriter binaryWriter, ReadOnlySpan<byte> buffer)
        {
            var arr = buffer.ToArray();
            binaryWriter.Write(arr, 0, arr.Length);
        }

        public static int Read(this System.IO.StreamReader streamReader, Span<char> buffer)
        {
            var arr = new char[buffer.Length];
            var readBytes = streamReader.Read(arr, 0, arr.Length);
            arr.AsSpan().CopyTo(buffer);
            return readBytes;
        }

        public static int ReadBlock(this System.IO.StreamReader streamReader, Span<char> buffer)
        {
            var arr = new char[buffer.Length];
            var readBytes = streamReader.ReadBlock(arr, 0, arr.Length);
            arr.AsSpan().CopyTo(buffer);
            return readBytes;
        }
        public static void Write(this System.IO.StreamWriter streamWriter, ReadOnlySpan<char> buffer)
        {
            var arr = buffer.ToArray();
            streamWriter.Write(arr, 0, arr.Length);
        }

        public static int Read(this System.IO.Stream stream, Span<byte> buffer)
        {
            var arr = new byte[buffer.Length];
            var readBytes = stream.Read(arr, 0, arr.Length);
            arr.AsSpan().CopyTo(buffer);
            return readBytes;
        }

        public static void Write(this System.IO.Stream stream, ReadOnlySpan<byte> buffer)
        {
            var arr = buffer.ToArray();
            stream.Write(arr, 0, arr.Length);
        }

    }
#endif
}
