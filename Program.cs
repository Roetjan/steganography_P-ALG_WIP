using System.Drawing;
using System.Drawing.Imaging;
using System.Text;
using System.Text.RegularExpressions;
using simple_steganography.Classes;

namespace simple_steganography
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string imagePath = "D:\\Leerjaar 3 - SD\\P-ALG\\simple_steganography\\Image\\standardImage.png";

            Console.WriteLine("Wil je een foto's kiezen of de standaard foto gebruiken?");
            Console.WriteLine("Geef een pad van de foto die je wilt gebruiken.");
            Console.WriteLine("Als je niks opgeeft gebruiken we een standaard foto");

            var userinput = Convert.ToString(Console.ReadLine());
            if(string.IsNullOrEmpty(userinput) && Path.Exists(userinput))
            {
                imagePath = userinput;
            }
            else
            {
                Console.WriteLine("Pad incorrect of niks ingevuld. Programma gebruikt nu een standaard foto");
                imagePath = @"D:\Leerjaar_3_SD\P-ALG\simple_steganography\Image\standardImage.png";
            }
            
            string outputPath = @$"D:\Leerjaar_3_SD\P-ALG\simple_steganography\Image\Converted\{Path.GetFileName(imagePath)}";

            Bitmap bitmap = new(imagePath);

            Console.WriteLine("Welke tekst wil je converten.");
            var message = Convert.ToString(Console.ReadLine());

            // Embed the message into the image
            var hiddenTextBmp = MessageHide.HideMessage(bitmap, message);
            hiddenTextBmp.Save(outputPath, ImageFormat.Png);
            Console.WriteLine($"Converted image saved to {outputPath}");

            // Extract the message from the saved image
            Bitmap outputBitmap = new(outputPath);
            string extractedMessage = MessageExtract.ExtractMessage(outputBitmap, message.Length);
            Console.WriteLine($"Extracted Hidden message: {extractedMessage}");
        }
    }
}
