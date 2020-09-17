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

namespace PathfindingMisc
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
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
            StrokeWidth = 10,
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

        public MainPage()
        {
            InitializeComponent();
        }

        private void canvas_PaintSurface(object sender, SKPaintSurfaceEventArgs e)
        {
            SKSurface surface = e.Surface;
            SKCanvas canvas = surface.Canvas;

            int width = e.Info.Width;
            int height = e.Info.Height;

            SKPoint endP = new SKPoint(width * 0.25f, height * 0.25f);
            SKPoint startP = new SKPoint(width * 0.75f, height * 0.75f);

            canvas.Scale(1,1);
            canvas.Save();

            // 
            setFloorPlan((int)(width), (int)(height));

            canvas.DrawBitmap(image, new SKRect(0, 0, width, height));

            canvas.DrawPoint(startP, redStroke);
            canvas.DrawPoint(endP, redStroke);

            List<SKPoint> points = new List<SKPoint>();
            points.Add(startP);

            SKPoint routeP = startP;
            
            // currently can't handle walls
            while (Math.Floor(routeP.X) != Math.Floor(endP.X) && Math.Floor(routeP.Y) != Math.Floor(endP.Y))
            {
                // don't know if it's faster to constantly call function or store the pixel data
                //      -- would be a lot of data to store however
                bool endX = false;
                bool endY = false;
                while (true)
                {
                    if (Math.Floor(routeP.X) < Math.Floor(endP.X))
                    {
                        if (image.GetPixel((int)routeP.X + 1, (int)routeP.Y) != SKColors.Black && routeP.X != endP.X)
                        {
                            routeP.X++;
                        }
                        else
                        {
                            points.Add(routeP);
                            break;
                        }
                    }
                    else if(routeP.X > endP.X)
                    {
                        if (image.GetPixel((int)routeP.X - 1, (int)routeP.Y) != SKColors.Black && routeP.X != endP.X)
                        {
                            routeP.X--;
                        }
                        else
                        {
                            points.Add(routeP);
                            break;
                        }
                    }
                    else
                    {
                        points.Add(routeP);
                        break;
                    }
                    //image.GetPixel((int)routeP.X +1, (int)routeP.Y) != SKColors.Black
                }
                while (true)
                {
                    if(Math.Floor(routeP.Y) < Math.Floor(endP.Y))
                    { 
                        if (image.GetPixel((int)routeP.X, (int)routeP.Y + 1) != SKColors.Black && routeP.Y != endP.Y)
                        {
                            routeP.Y++;
                        }
                        else
                        {
                            points.Add(routeP);
                            break;
                        }
                    }
                    else if (routeP.Y > endP.Y)
                    {
                        if (image.GetPixel((int)routeP.X, (int)routeP.Y - 1) != SKColors.Black && routeP.Y != endP.Y)
                        {
                            routeP.Y--;
                        }
                        else
                        {
                            points.Add(routeP);
                            break;
                        }
                    }
                    else
                    {
                        points.Add(routeP);
                        break;
                    }
                }
            }

            //points.Add(endP); // not sure if this will be needed

            for (int i = 0; i < points.Count -1;  i++) // count produces higher value than max index
            {
                canvas.DrawLine(points[i], points[i + 1], redStroke);
                canvas.DrawPoint(points[i + 1], blackStroke); // not super necessary, illustrating where points are
            }
            
        }

        // try to call only when loading new floor
        // (currently the same static image)
        private void setFloorPlan(int width, int height)
        {
            // Bitmap
            Assembly assembly = GetType().GetTypeInfo().Assembly;
            String resourceID = "PathfindingMisc.test.bmp";
            using (Stream stream = assembly.GetManifestResourceStream(resourceID))
            {
                image = SKBitmap.Decode(stream);
                SKImageInfo sKImageInfo = new SKImageInfo(width, height);
                image = image.Resize(sKImageInfo, SKFilterQuality.High);
            }
        }

    }
}
