using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace kioskAssistant.UI
{
    internal static class LogoGradient
    {
        private static readonly Color Start = ColorTranslator.FromHtml("#07d39e");
        private static readonly Color End = ColorTranslator.FromHtml("#f9ff93");

        public static Image Apply(Image source)
        {
            ArgumentNullException.ThrowIfNull(source);
            using var original = new Bitmap(source);
            var result = new Bitmap(original.Width, original.Height, PixelFormat.Format32bppArgb);

            for (int y = 0; y < original.Height; y++)
            {
                float vertical = original.Height <= 1 ? 0 : (float)y / (original.Height - 1);
                Color gradient = Interpolate(Start, End, vertical);
                for (int x = 0; x < original.Width; x++)
                {
                    Color pixel = original.GetPixel(x, y);
                    result.SetPixel(x, y, Color.FromArgb(pixel.A, gradient));
                }
            }

            return result;
        }

        private static Color Interpolate(Color start, Color end, float amount) => Color.FromArgb(
            (int)Math.Round(start.R + (end.R - start.R) * amount),
            (int)Math.Round(start.G + (end.G - start.G) * amount),
            (int)Math.Round(start.B + (end.B - start.B) * amount));
    }
}
