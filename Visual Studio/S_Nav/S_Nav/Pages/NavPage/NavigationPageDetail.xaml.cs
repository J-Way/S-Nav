using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkiaSharp;
using SkiaSharp.Views.Forms;


using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;

namespace S_Nav
{
    [DesignTimeVisible(true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NavigationPageDetail : ContentPage
    {
        // Load temp image in (should look into bitmaps)
        SKPaint routeColour = new SKPaint
        {
            Style = SKPaintStyle.Stroke,
            StrokeWidth = 2,
            Color = SKColors.Black
        };
        SKPaint colour = new SKPaint
        {
            Style = SKPaintStyle.Stroke,
            StrokeWidth = 5,
            Color = SKColors.Magenta // horrible colour, just a placeholder
        };

        SKBitmap image;

        public NavigationPageDetail()
        {
            InitializeComponent();
        }

        private void canvas_PaintSurface(object sender, SKPaintSurfaceEventArgs e)
        {
            SKSurface surface = e.Surface;
            SKCanvas mapCanvas = surface.Canvas;

            int width = e.Info.Width;
            int height = e.Info.Height;

            float heightTrim = height * 0.75f;

            mapCanvas.Scale(1, 0.75f);

            setFloorPlan(width, (int)heightTrim);

            mapCanvas.DrawRect(0, 0, width, height, colour);
            mapCanvas.DrawBitmap(image, new SKRect(0, 0, width, height));

            drawRoute(mapCanvas);
        }


        // try to call only when loading new floor
        // (currently the same static image)
        private void setFloorPlan(int width, int height)
        {
            // Bitmap
            Assembly assembly = GetType().GetTypeInfo().Assembly;
            String resourceID = "S_Nav.TRAE2.jpg";
            using (Stream stream = assembly.GetManifestResourceStream(resourceID))
            {
                image = SKBitmap.Decode(stream);
            }
        }

        // doesn't need to be outside paintSurface, just is for clarity
        private void drawRoute(SKCanvas canvas)
        {
            canvas.DrawLine(0, 0, 50, 100, routeColour);
        }
    }
}