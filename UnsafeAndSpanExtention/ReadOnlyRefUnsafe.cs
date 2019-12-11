using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace UnsafeAndSpanExtention
{
    public static class ReadOnlyRefUnsafe
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ReadOnlySpan<T> CreateReadOnlySpan<T>(in T reference, int length)
            where T : unmanaged
            => AltMemoryMarshal.CreateReadOnlySpan(ref Unsafe.AsRef(in reference), length);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ref readonly T Add<T>(in T source, int elementOffset)
            => ref Unsafe.Add(ref Unsafe.AsRef(in source), elementOffset);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ref readonly T Add<T>(in T source, IntPtr elementOffset)
            => ref Unsafe.Add(ref Unsafe.AsRef(in source), elementOffset);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ref readonly T AddByteOffset<T>(in T source, IntPtr byteOffset)
            => ref Unsafe.AddByteOffset(ref Unsafe.AsRef(in source), byteOffset);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AreSame<T>(in T left, in T right)
            => Unsafe.AreSame(ref Unsafe.AsRef(in left), ref Unsafe.AsRef(in right));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ref readonly TTo As<TFrom, TTo>(in TFrom source)
            => ref Unsafe.As<TFrom, TTo>(ref Unsafe.AsRef(in source));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IntPtr ByteOffset<T>(in T origin, in T target)
            => Unsafe.ByteOffset(ref Unsafe.AsRef(in origin), ref Unsafe.AsRef(in target));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsAddressGreaterThan<T>(in T left, in T right)
            => Unsafe.IsAddressGreaterThan(ref Unsafe.AsRef(in left), ref Unsafe.AsRef(in right));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsAddressLessThan<T>(in T left, in T right)
            => Unsafe.IsAddressLessThan(ref Unsafe.AsRef(in left), ref Unsafe.AsRef(in right));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T Read<T>(in byte source)
            => As<byte, T>(in source);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ref readonly T Subtract<T>(in T source, int elementOffset)
            => ref Unsafe.Subtract(ref Unsafe.AsRef(in source), elementOffset);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ref readonly T Subtract<T>(in T source, IntPtr elementOffset)
            => ref Unsafe.Subtract(ref Unsafe.AsRef(in source), elementOffset);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ref readonly T SubtractByteOffset<T>(in T source, IntPtr byteOffset)
            => ref Unsafe.SubtractByteOffset(ref Unsafe.AsRef(in source), byteOffset);
    }
}
