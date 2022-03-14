using PluginTest.Common;
using SixLabors.Fonts;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Drawing.Processing;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;

namespace PluginTest.Plugin.ImageSharp
{
    public class ImageSharpModule : IModule
    {
        public void DoSomething()
        {
            using (var image = new Image<Rgba32>(300, 300))
            {
                var fontCollection = new FontCollection();
                fontCollection.AddSystemFonts();

                var arialFont = fontCollection.Get("Arial").CreateFont(72);

                image.Mutate(x => {
                    x.DrawText("Test", arialFont, Color.Red, new PointF(0, 0));
                });

                image.SaveAsPng("test.png");
            }
        }
    }
}