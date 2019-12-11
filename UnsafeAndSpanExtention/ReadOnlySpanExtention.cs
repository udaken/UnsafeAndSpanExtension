using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

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

        public static int GetAnsiStringLength(this ReadOnlySpan<sbyte> source)
        {
            var length = source.IndexOf((sbyte)0);
            return (length == -1) ? source.Length : length;
        }

        public static string ToAnsiString(this ReadOnlySpan<sbyte> source)
         => System.Text.Encoding.Default.GetString(MemoryMarshal.AsBytes(source.Slice(0, source.GetAnsiStringLength())));

        public static int GetAnsiStringLength(this ReadOnlySpan<byte> source)
        {
            var length = source.IndexOf((byte)0);
            return (length == -1) ? source.Length : length;
        }

        public static string ToAnsiString(this ReadOnlySpan<byte> source)
         => GetString(System.Text.Encoding.Default, source.Slice(0, source.GetAnsiStringLength()));

        public static int GetNullTerminateStringLength(this ReadOnlySpan<char> source)
        {
            var length = source.IndexOf('\0');
            return (length == -1) ? source.Length : length;
        }

        public static string ToNullTerminateString(this ReadOnlySpan<char> source)
         => source.Slice(0, source.GetNullTerminateStringLength()).ToString();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ReadOnlySpan<T> Cast<T>(this ReadOnlySpan<byte> span) where T : struct
         => MemoryMarshal.Cast<byte, T>(span);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ref readonly T AsRef<T>(this ReadOnlySpan<byte> span) where T : struct
         => ref MemoryMarshal.GetReference(span.Cast<T>());

#if NETSTANDARD2_0
        public unsafe static int GetByteCount(this System.Text.Encoding encoding, ReadOnlySpan<char> chars)
        {
            fixed (char* p = chars)
            {
                return encoding.GetByteCount(p, chars.Length);
            }

        }

        public unsafe static int GetBytes(this System.Text.Encoding encoding, ReadOnlySpan<char> chars, Span<byte> bytes)
        {
            fixed (byte* p = bytes)
            fixed (char* s = chars)
            {
                return encoding.GetBytes(s, chars.Length, p, bytes.Length);
            }
        }

        public unsafe static int GetCharCount(this System.Text.Encoding encoding, ReadOnlySpan<byte> bytes)
        {
            fixed (byte* p = bytes)
            {
                return encoding.GetCharCount(p, bytes.Length);
            }
        }

        public unsafe static int GetChars(this System.Text.Encoding encoding, ReadOnlySpan<byte> bytes, Span<char> chars)
        {
            fixed (byte* p = bytes)
            fixed (char* s = chars)
            {
                return encoding.GetChars(p, bytes.Length, s, chars.Length);
            }
        }

        public unsafe static string GetString(this System.Text.Encoding encoding, ReadOnlySpan<byte> bytes)
        {
            fixed (byte* p = bytes)
            {
                return encoding.GetString(p, bytes.Length);
            }
        }
    }
#endif
}
