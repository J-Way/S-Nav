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
using System.Numerics;
using System.Diagnostics;

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
            StrokeWidth = 50,
            Color = SKColors.Magenta
        };

        SKPaint blackStroke = new SKPaint
        {
            Style = SKPaintStyle.Stroke,
            StrokeWidth = 10,
            Color = SKColors.Black
        };
        SKPaint blackFill = new SKPaint
        {
            Style = SKPaintStyle.Fill,
            StrokeWidth = 10,
            Color = SKColors.Black
        };

        SKBitmap image;
        SKColor pixelColor;

        public NavigationPageDetail()
        {
            InitializeComponent();
        }

        private void canvas_PaintSurface(object sender, SKPaintSurfaceEventArgs e)
        {
            SKSurface surface = e.Surface;
            SKCanvas canvas = surface.Canvas;

            int width = e.Info.Width;
            int height = e.Info.Height;

            float heightTrim = height * 0.75f;

            canvas.Scale(1, 0.75f);

            setFloorPlan(width, (int)heightTrim);

            canvas.DrawRect(0, 0, width, height, blackStroke);
            canvas.DrawBitmap(image, new SKRect(0, 0, width, height));

            SKPoint[] test = new SKPoint[2];
            test[0] = new SKPoint(width * 0.33f, heightTrim / 2);
            test[1] = new SKPoint(width * 0.66f, heightTrim / 2);

            canvas.DrawPoint(test[0], blackFill);
            canvas.DrawPoint(test[1], blackFill);

            canvas.DrawPoints(SKPointMode.Lines, test, routeColour);
        }


        // try to call only when loading new floor
        // (currently the same static image)
        private void setFloorPlan(int width, int height)
        {
            // Bitmap
            Assembly assembly = GetType().GetTypeInfo().Assembly;
            String resourceID = "S_Nav.TRAE2_Test.jpg";
            using (Stream stream = assembly.GetManifestResourceStream(resourceID))
            {
                image = SKBitmap.Decode(stream);
            }
        }

        // doesn't need to be outside paintSurface, just is for clarity
        private void drawRoute(SKCanvas canvas)
        {
            canvas.DrawLine(0, 0, 50, 250, routeColour);
        }
    }
}