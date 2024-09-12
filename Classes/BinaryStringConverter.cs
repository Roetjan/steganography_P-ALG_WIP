using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace simple_steganography.Classes
{
    internal class BinaryStringConverter
    {
        public static string BinaryToString(string binary)
        {
            // List to hold the bytes after conversion from binary string
            List<byte> byteList = new List<byte>();

            for (int i = 0; i < binary.Length; i += 8)
            {
                byteList.Add(Convert.ToByte(binary.Substring(i, 8), 2));
            }

            return Encoding.ASCII.GetString(byteList.ToArray());
        }

    }
}
