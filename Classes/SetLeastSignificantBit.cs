using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace simple_steganography.Classes
{
    internal class SetLeastSignificantBit
    {
        public static int setLeastSignificantBit(int colorValue, char bit)
        {
            int mask = 1;  // 00000001
            int bitValue = bit == '1' ? 1 : 0;

            // Set LSB 
            return colorValue & ~mask | bitValue;
        }
    }
}
