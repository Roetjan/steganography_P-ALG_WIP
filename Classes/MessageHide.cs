using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace simple_steganography.Classes
{
    public class MessageHide
    {
        public static Bitmap HideMessage(Bitmap bitmap, string message)
        {
            // Check if the bitmap has an indexed pixel format
            if (bitmap.PixelFormat == System.Drawing.Imaging.PixelFormat.Format8bppIndexed ||
                bitmap.PixelFormat == System.Drawing.Imaging.PixelFormat.Indexed)
            {
                // Convert the image to a non-indexed format like Format32bppArgb
                Bitmap newBitmap = new Bitmap(bitmap.Width, bitmap.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
                using (Graphics g = Graphics.FromImage(newBitmap))
                {
                    g.DrawImage(bitmap, 0, 0, bitmap.Width, bitmap.Height);
                }
                bitmap = newBitmap;
            }

            // Convert the message to a binary string
            string binaryMessage = StringToBinary.stringToBinary(message);

            // Get dimensions of the image
            int width = bitmap.Width;
            int height = bitmap.Height;

            int messageIndex = 0;
            bool messageHidden = false;

            for (int i = 0; i < height && !messageHidden; i++)
            {
                for (int j = 0; j < width && !messageHidden; j++)
                {
                    // Get pixel at (i, j)
                    Color pixel = bitmap.GetPixel(j, i);

                    if (messageIndex < binaryMessage.Length)
                    {
                        int newR = SetLeastSignificantBit.setLeastSignificantBit(pixel.R, binaryMessage[messageIndex++]);
                        int newG = pixel.G;
                        int newB = pixel.B;

                        Color newPixel = Color.FromArgb(newR, newG, newB);
                        bitmap.SetPixel(j, i, newPixel);
                    }
                    else
                    {
                        messageHidden = true;
                    }
                }
            }
            return bitmap;
        }

    }
}
