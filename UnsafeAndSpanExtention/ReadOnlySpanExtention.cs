using System;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;

namespace UnsafeAndSpanExtention
{
    public static class ReadOnlySpanExtention
    {
        public static bool TryRead<T>(this ReadOnlySpan<byte> source, out T value) where T : struct
         => MemoryMarshal.TryRead<T>(source, out value);

        public static bool TryReadByte(this ReadOnlySpan<byte> source, out Byte value)
         => MemoryMarshal.TryRead(source, out value);

        public static bool TryReadUInt16(this ReadOnlySpan<byte> source, out UInt16 value)
         => MemoryMarshal.TryRead(source, out value);

        public static bool TryReadUInt32(this ReadOnlySpan<byte> source, out UInt32 value)
         => MemoryMarshal.TryRead(source, out value);

        public static bool TryReadUInt64(this ReadOnlySpan<byte> source, out UInt64 value)
         => MemoryMarshal.TryRead(source, out value);

        public static bool TryReadSByte(this ReadOnlySpan<byte> source, out SByte value)
         => MemoryMarshal.TryRead(source, out value);

        public static bool TryReadInt16(this ReadOnlySpan<byte> source, out Int16 value)
         => MemoryMarshal.TryRead(source, out value);

        public static bool TryReadInt32(this ReadOnlySpan<byte> source, out Int32 value)
         => MemoryMarshal.TryRead(source, out value);

        public static bool TryReadInt64(this ReadOnlySpan<byte> source, out Int64 value)
         => MemoryMarshal.TryRead(source, out value);

        public static bool TryReadGuid(this ReadOnlySpan<byte> source, out Guid value)
         => MemoryMarshal.TryRead(source, out value);

        public static int GetAnsiStringLength(this ReadOnlySpan<byte> source)
        {
            var length = source.IndexOf((byte)0);
            return (length == -1) ? source.Length : length;
        }

        public static int GetUtf16StringLength(this ReadOnlySpan<byte> source)
         => GetUtf16StringLength(MemoryMarshal.Cast<byte, char>(source));

        public static int GetUtf16StringLength(this ReadOnlySpan<char> source)
        {
            var length = source.IndexOf('\0');
            return (length == -1) ? source.Length : length;
        }

        public static string ToNullTerminateString(this ReadOnlySpan<char> source)
         => source.Slice(0, source.GetUtf16StringLength()).ToString();

        public static Span<T> Cast<T>(this Span<byte> span) where T : struct
         => MemoryMarshal.Cast<byte, T>(span);

        public static ReadOnlySpan<T> Cast<T>(this ReadOnlySpan<byte> span) where T : struct
         => MemoryMarshal.Cast<byte, T>(span);

        public static ref T AsRef<T>(this Span<byte> span) where T : struct
         => ref MemoryMarshal.GetReference(span.Cast<T>());

        public static ref readonly T AsRef<T>(this ReadOnlySpan<byte> span) where T : struct
         => ref MemoryMarshal.GetReference(span.Cast<T>());
    }
}
