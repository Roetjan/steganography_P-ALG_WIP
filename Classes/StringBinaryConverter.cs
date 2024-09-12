using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace simple_steganography.Classes
{
    public static class StringBinaryConverter
    {
        public static string stringToBinary(string data)
        {
            string binary = string.Join("", data.Select(
                c => Convert.ToString(c, 2).PadLeft(8, '0')
            ));
            return binary;
        }
    }
}
