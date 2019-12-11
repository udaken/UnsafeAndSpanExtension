using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace UnsafeAndSpanExtention
{
    public static class SpanExtention
    {
        public static int GetAnsiStringLength(this Span<sbyte> source)
            => ReadOnlySpanExtention.GetAnsiStringLength(source);

        public static string ToAnsiString(this Span<sbyte> source)
         => ReadOnlySpanExtention.ToAnsiString(source);

        public static int GetAnsiStringLength(this Span<byte> source)
            => ReadOnlySpanExtention.GetAnsiStringLength(source);
        public static string ToAnsiString(this Span<byte> source)
         => ReadOnlySpanExtention.ToAnsiString(source);

        public static int GetNullTerminateStringLength(this Span<char> source)
            => ReadOnlySpanExtention.GetNullTerminateStringLength(source);

        public static string ToNullTerminateString(this Span<char> source)
         => ReadOnlySpanExtention.ToNullTerminateString(source);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Span<T> Cast<T>(this Span<byte> span) where T : struct
         => MemoryMarshal.Cast<byte, T>(span);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ref T AsRef<T>(this Span<byte> span) where T : struct
         => ref MemoryMarshal.GetReference(span.Cast<T>());

    }
}
