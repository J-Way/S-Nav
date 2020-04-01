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
using System.Collections;

namespace S_Nav
{
    [DesignTimeVisible(true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NavigationPageDetail : ContentPage
    {
        // temporary route colour
        SKPaint routeColour = new SKPaint
        {
            Style = SKPaintStyle.Stroke,
            StrokeWidth = 5,
            Color = SKColors.Magenta
        };

        // spare colours, try to use "strokes" unless
        // you know what you're doing
        SKPaint blackStroke = new SKPaint
        {
            Style = SKPaintStyle.Stroke,
            StrokeWidth = 10,
            Color = SKColors.Black
        };
        SKPaint redStroke = new SKPaint
        {
            Style = SKPaintStyle.Stroke,
            StrokeWidth = 20,
            Color = SKColors.Red
        };
        SKPaint blackFill = new SKPaint
        {
            Style = SKPaintStyle.Fill,
            StrokeWidth = 10,
            Color = SKColors.Black
        };

        // image being loaded
        SKBitmap image;
        
        // creates detail page
        // dont touch this
        public NavigationPageDetail()
        {
            InitializeComponent();
        }

        ///     handles / calls all the drawing
        ///     if you need to refresh / reset, call invalidate in
        ///         NavigationPageDetail()
        private void canvas_PaintSurface(object sender, SKPaintSurfaceEventArgs e)
        {
            SKSurface surface = e.Surface;
            SKCanvas canvas = surface.Canvas;

            int width = e.Info.Width;
            int height = e.Info.Height;

            float heightTrim = height * 0.75f;

            canvas.Scale(1, 0.75f);

            setFloorPlan(width, (int)heightTrim);

            canvas.DrawBitmap(image, new SKRect(0, 0, width, height));

            canvas.Save(); // unnecessary at this moment, but leave in

            ///
            /// code playground
            ///
            SKPoint start, end;
            start = new SKPoint(width * 0.25f, heightTrim * 0.25f);
            end = new SKPoint(width * 0.75f, heightTrim * 0.75f);

            float[] differential = new float[2]; // difference between image and screen size
            differential[0] = (float)image.Width / width; // both ints, one needs to be casted for decimal
            differential[1] = image.Height / heightTrim;

            SKPoint misc = drawRoute(start, end,differential);

            SKPoint[] test = new SKPoint[3];
            test[0] = start;
            test[1] = misc;
            test[2] = end;
            canvas.DrawPoint(start, blackStroke); // start 
            canvas.DrawPoint(end, blackStroke); // end
            canvas.DrawPoint(misc, blackStroke);
            //canvas.DrawPoints(SKPointMode.Lines, test, routeColour);

            ///
            ///
        }


        // try to call only when loading new floor
        // (currently the same static image)
        private void setFloorPlan(int width, int height)
        {
            // Bitmap
            Assembly assembly = GetType().GetTypeInfo().Assembly;
            String resourceID = "S_Nav.TestBitmap.bmp";
            using (Stream stream = assembly.GetManifestResourceStream(resourceID))
            {
                image = SKBitmap.Decode(stream);
            }
        }

        // doesn't need to be outside paintSurface, just is for clarity
        private SKPoint drawRoute(SKPoint start, SKPoint end, float[] differential)
        {
            List<SKPoint> points = new List<SKPoint>();

            int pointX, pointY; // references current scanned pixel

            pointX = (int)(start.X * differential[0]); // technically start.X is a float, test for errors after cast
            pointY = (int)(start.Y * differential[1]);

            float testX = start.X, testY = start.Y;

            bool goRight = true, goDown = true;

            while(pointX != (int)end.X || pointY != (int)end.Y)
            {
                #region placeholder
                /*
                color = image.GetPixel(pointX + 1, pointY);
                if(color != SKColors.Black && pointX != (int)end.X)
                {
                    pointX++;
                }
                else if (image.GetPixel(pointX, pointY + 1) != SKColors.Black && pointY != (int)end.Y)
                {
                    pointY++;
                }

                if (pointX == (int)end.X && pointY == (int)end.Y)
                    return new SKPoint(pointX, pointY);
                */
                #endregion 
            }

            return new SKPoint(0,0); // no route found, currently return garbage
        }
    }
}