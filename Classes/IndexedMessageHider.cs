using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace simple_steganography.Classes
{
    internal class IndexedMessageHider
    {
        public static void HideMessageArgb(Bitmap bitmap, string message)
        {
            // Convert the message to a binary string
            string binaryMessage = StringToBinary.stringToBinary(message);

            int width = bitmap.Width;
            int height = bitmap.Height;

            int messageIndex = 0;
            bool messageHidden = false;

            for (int i = 0; i < height && !messageHidden; i++)
            {
                for (int j = 0; j < width && !messageHidden; j++)
                {
                    Color pixel = bitmap.GetPixel(j, i);

                    if (messageIndex < binaryMessage.Length)
                    {
                        // Get the bit of the message (0 or 1)
                        int messageBit = binaryMessage[messageIndex++] == '1' ? 1 : 0;

                        // Modify the LSB of the red channel
                        int newR = (pixel.R & ~1) | messageBit;
                        int newG = pixel.G;
                        int newB = pixel.B;
                        int newA = pixel.A;

                        Color newPixel = Color.FromArgb(newA, newR, newG, newB);
                        bitmap.SetPixel(j, i, newPixel);
                    }
                    else
                    {
                        messageHidden = true;
                    }
                }
            }
        }

    }
}
