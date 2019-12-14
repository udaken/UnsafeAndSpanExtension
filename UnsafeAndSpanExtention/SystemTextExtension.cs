using System;

namespace UnsafeAndSpanExtension
{
#if NETSTANDARD2_0
    public static class SystemTextExtension
    {
        public unsafe static System.Text.StringBuilder Append(this System.Text.StringBuilder stringBuilder, ReadOnlySpan<char> chars)
        {
            fixed (char* p = chars)
            {
                return stringBuilder.Append(p, chars.Length);
            }
        }

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
