using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace simple_steganography.Classes
{
    internal class MessageExtracter
    {
        public static string ExtractMessage(Bitmap bitmap, int messageLength)
        {
            StringBuilder binaryMessage = new StringBuilder();

            int width = bitmap.Width;
            int height = bitmap.Height;

            int messageIndex = 0;
            bool messageExtracted = false;

            for (int i = 0; i < height && !messageExtracted; i++)
            {
                for (int j = 0; j < width && !messageExtracted; j++)
                {

                    Color pixel = bitmap.GetPixel(j, i);

                    int lsb = pixel.R & 1;
                    binaryMessage.Append(lsb);

                    messageIndex++;
                    // If we've extracted the required number of bits, stop the process
                    if (messageIndex >= messageLength * 8)
                    {
                        messageExtracted = true;
                    }
                }
            }

            // Make sure the binary message has a length that is a multiple of 8
            string binaryString = binaryMessage.ToString();
            if (binaryString.Length % 8 != 0)
            {
                throw new ArgumentException("The binary message length is not a multiple of 8, which may lead to errors.");
            }

            // Convert binary message back to a string
            string message = BinaryStringConverter.BinaryToString(binaryString);
            return message;
        }

    }
}
