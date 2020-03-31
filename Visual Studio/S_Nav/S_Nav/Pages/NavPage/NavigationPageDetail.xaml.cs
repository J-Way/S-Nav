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

            SKPoint red = new SKPoint(-1,-1), blue = new SKPoint(-1,-1);

            Debug.WriteLine(SKColors.Blue);

            // horribly inefficent, I know
            for (int x = 0; x < image.Width; x++)
            {
                for (int y = 0; y < 697; y++)
                {                    
                    pixelColor = image.GetPixel(x, y);
                    if (pixelColor ==  SKColor.Parse("#FFFE0000") && red.X == -1)
                    {
                        red = new SKPoint(x, y);
                        Debug.WriteLine(red);
                    }
                    else if (pixelColor == SKColor.Parse("#FF0001FC") && blue.X == -1)
                    {
                        blue = new SKPoint(x, y);
                        Debug.WriteLine(blue);
                    }


                    if (blue.X != -1 && red.X != -1)
                    {
                        x = image.Width;
                        y = image.Height;
                    }

                }
            }

            //image.Width / width;
            //image.Height / height;

            canvas.DrawRect(new SKRect(853, 701, 1734, 697), blackFill);
            //canvas.DrawLine(red, blue, blackStroke);
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