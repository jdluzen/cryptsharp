#region License
/*
Illusory Studios C# Crypto Library (CryptSharp)
Copyright (c) 2011 James F. Bellinger <jfb@zer7.com>

Permission to use, copy, modify, and/or distribute this software for any
purpose with or without fee is hereby granted, provided that the above
copyright notice and this permission notice appear in all copies.

THE SOFTWARE IS PROVIDED "AS IS" AND THE AUTHOR DISCLAIMS ALL WARRANTIES
WITH REGARD TO THIS SOFTWARE INCLUDING ALL IMPLIED WARRANTIES OF
MERCHANTABILITY AND FITNESS. IN NO EVENT SHALL THE AUTHOR BE LIABLE FOR
ANY SPECIAL, DIRECT, INDIRECT, OR CONSEQUENTIAL DAMAGES OR ANY DAMAGES
WHATSOEVER RESULTING FROM LOSS OF USE, DATA OR PROFITS, WHETHER IN AN
ACTION OF CONTRACT, NEGLIGENCE OR OTHER TORTIOUS ACTION, ARISING OUT OF
OR IN CONNECTION WITH THE USE OR PERFORMANCE OF THIS SOFTWARE.
*/
#endregion

using System;
using System.Collections.Generic;

namespace CryptSharp.Utility
{
	public static class UnixBase64
	{
		public static int Decode(char value)
		{
			if (value == '.' || value == '=') { return 0; }
			else if (value == '/') { return 1; }
			else if (value >= 'A' && value <= 'Z') { return 2 + (value - 'A'); }
			else if (value >= 'a' && value <= 'z') { return 28 + (value - 'a'); }
			else if (value >= '0' && value <= '9') { return 54 + (value - '0'); }
			else { return 0; }
		}

        public static byte[] Decode(char[] value)
        {
            return Pow2Base.Decode(6, Decode, value);
        }

		public static byte[] Decode(IEnumerable<char> value, int bitsToDecode)
		{
            return Pow2Base.Decode(6, Decode, value, bitsToDecode);
		}
				
		public static char Encode(int value)
		{
			try { return "./ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789"[value]; }
			catch (IndexOutOfRangeException) { throw new ArgumentException("value"); }
		}
		
		public static char[] Encode(byte[] value)
		{
            return Pow2Base.Encode(6, Encode, value);
		}
		
		public static char[] Encode(byte[] value, int bitsToEncode)
		{
            return Pow2Base.Encode(6, Encode, value, bitsToEncode);
		}
	}
}

