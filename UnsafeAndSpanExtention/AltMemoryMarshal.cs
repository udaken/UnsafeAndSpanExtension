using System;
using System.Runtime.CompilerServices;

namespace UnsafeAndSpanExtention
{
    public static class AltMemoryMarshal
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Span<T> CreateSpan<T>(ref T reference, int length)
            where T : unmanaged
        {
#if NETSTANDARD2_0
            unsafe
            {
                return new Span<T>(Unsafe.AsPointer(ref reference), length);
            }
#else
            return MemoryMarshal.CreateSpan(ref reference, length);
#endif
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ReadOnlySpan<T> CreateReadOnlySpan<T>(ref T reference, int length)
            where T : unmanaged
        {
#if NETSTANDARD2_0
            unsafe
            {
                return new ReadOnlySpan<T>(Unsafe.AsPointer(ref reference), length);
            }
#else
            return MemoryMarshal.CreateReadOnlySpan(ref reference, length);
#endif
        }
    }
}
