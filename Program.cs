using System;
using System.IO;
using SixLabors.Fonts;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;
using SixLabors.Primitives;
using SixLabors.Shapes;

namespace Overmapper
{
    class Program
    {
        static void Main(string[] args)
        {
            var raw = @"ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";


            using var img = new Image<Rgba32>(144, 144);
            var font = SystemFonts.CreateFont("Consolas", 24, FontStyle.Regular);
            var size = TextMeasurer.Measure("H", new RendererOptions(font));

            var tgo = new TextGraphicsOptions
            {
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Top,
                DpiX = 72,
                DpiY = 72,
            };

            var go = new GraphicsOptions
            {
            };


            var y = 0;
            for (var i = 0; i < raw.Length; i++)
            {
                var x = (i%6)*24;
                if (i % 6 == 0)
                {
                    y = (int)(i / 6 * 24);
                }
                var i1 = i;
                var y1 = y;
                img.Mutate(ctx => ctx
                    .Fill(go, Color.Green, new RectangleF(x, y1, 24, 24))
                    .DrawText(tgo, raw[i1].ToString(), font, Color.Black, new PointF(x, y1)));
            }

            
            img.Save("temp.png");
        }
    }
}
