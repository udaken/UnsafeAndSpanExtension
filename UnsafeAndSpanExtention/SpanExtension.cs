using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace UnsafeAndSpanExtension
{
    public static class SpanExtension
    {
        public static int GetAnsiStringLength(this Span<sbyte> source)
            => ReadOnlySpanExtension.GetAnsiStringLength(source);

        public static string ToAnsiString(this Span<sbyte> source)
         => ReadOnlySpanExtension.ToAnsiString(source);

        public static int GetAnsiStringLength(this Span<byte> source)
            => ReadOnlySpanExtension.GetAnsiStringLength(source);
        public static string ToAnsiString(this Span<byte> source)
         => ReadOnlySpanExtension.ToAnsiString(source);

        public static int GetNullTerminateStringLength(this Span<char> source)
            => ReadOnlySpanExtension.GetNullTerminateStringLength(source);

        public static string ToNullTerminateString(this Span<char> source)
         => ReadOnlySpanExtension.ToNullTerminateString(source);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Span<T> Cast<T>(this Span<byte> span) where T : struct
         => MemoryMarshal.Cast<byte, T>(span);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ref T AsRef<T>(this Span<byte> span) where T : struct
         => ref MemoryMarshal.GetReference(span.Cast<T>());

    }
}
