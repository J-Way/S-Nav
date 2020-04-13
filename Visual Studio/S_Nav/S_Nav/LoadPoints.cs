using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace S_Nav
{
    // will later include loading points from file, using hardcoded for now
    class LoadPoints
    {

        public List<MapPoint> loadPoints(int width, int height)
        {
            List<MapPoint> points = new List<MapPoint>();
            // hallway points
            points.Add(new MapPoint("hallTopLeft", new SKPoint(width * .37f, height * .30f)));
            points.Add(new MapPoint("hallTopRight", new SKPoint(width * .73f, height * .30f)));
            points.Add(new MapPoint("hallCurvedStart", new SKPoint(width * .73f, height * .36f)));
            points.Add(new MapPoint("hallCurvedMid", new SKPoint(width * .68f, height * .43f)));
            points.Add(new MapPoint("hallMidLeft", new SKPoint(width * .37f, height * .53f)));
            points.Add(new MapPoint("hallBottomLeft", new SKPoint(width * .37f, height * .73f)));
            points.Add(new MapPoint("hallBottomRight", new SKPoint(width * .57f, height * .53f)));

            // floor traversal
            points.Add(new MapPoint("stairsTopLeft", new SKPoint(width * .24f, height * .25f)));//topleft stairs 
            points.Add(new MapPoint("elevatorTopLeft",new SKPoint(width * .21f, height * .25f)));//topleft elevator
            points.Add(new MapPoint("stairsTopRight",new SKPoint(width * .885f, height * .30f))); //topRight stairs
            points.Add(new MapPoint("stairsBottomLeft", new SKPoint(width * .36f, height * .96f))); //bottom left stairs

            //Bathrooms
            points.Add(new MapPoint("bathroomGirls",new SKPoint(width * .48f, height * .52f))); //girls bathroom
            points.Add(new MapPoint("bathroomHandicap", new SKPoint(width * .78f, height * .32f)));  //handicap bathroom
            points.Add(new MapPoint("bathroomMen",new SKPoint(width * .6f, height * .50f))); //mens bathroom

            //E200
            points.Add(new MapPoint("E208",new SKPoint(width * .265f, height * .31f))); // E208
            points.Add(new MapPoint("E209", new SKPoint(width * .265f, height * .31f))); // E208
            points.Add(new MapPoint("E200", new SKPoint(width * .50f, height * .31f))); //E200 Door
            points.Add(new MapPoint("E200F", new SKPoint(width * .50f, height * .36f))); //E200F
            points.Add(new MapPoint("E200E", new SKPoint(width * .555f, height * .36f))); //E200E
            points.Add(new MapPoint("E200D", new SKPoint(width * .57f, height * .36f))); //E200D
            points.Add(new MapPoint("E200C", new SKPoint(width * .62f, height * .36f))); //E200C
            points.Add(new MapPoint("E200B", new SKPoint(width * .67f, height * .36f))); //E200B
            points.Add(new MapPoint("E200A", new SKPoint(width * .67f, height * .36f))); //E200A
            points.Add(new MapPoint("E200F", new SKPoint(width * .50f, height * .36f))); //E200F
            points.Add(new MapPoint("E200G", new SKPoint(width * .50f, height * .42f))); //E200G
            points.Add(new MapPoint("E200H", new SKPoint(width * .50f, height * .44f))); //E200H
            points.Add(new MapPoint("E200I", new SKPoint(width * .525f, height * .44f))); //E200I
            points.Add(new MapPoint("E200J", new SKPoint(width * .55f, height * .44f))); //E200J
            points.Add(new MapPoint("E200K", new SKPoint(width * .58f, height * .44f))); //E200K

            //E207
            points.Add(new MapPoint("E207", new SKPoint(width * .36f, height * .60f))); //E207
            points.Add(new MapPoint("E207C", new SKPoint(width * .36f, height * .76f))); //E207C
            points.Add(new MapPoint("E207E", new SKPoint(width * .25f, height * .60f))); //E207E
            points.Add(new MapPoint("E207U", new SKPoint(width * .25f, height * .60f))); //E207U
            points.Add(new MapPoint("E207A", new SKPoint(width * .275f, height * .56f))); //E207A
            points.Add(new MapPoint("E207B", new SKPoint(width * .275f, height * .63f))); //E207B
            points.Add(new MapPoint("E207D", new SKPoint(width * .275f, height * .63f))); //E207D
            points.Add(new MapPoint("E207G", new SKPoint(width * .275f, height * .555f))); //E207G
            points.Add(new MapPoint("E207F", new SKPoint(width * .26f, height * .54f))); //E207F

            points.Add(new MapPoint("E206", new SKPoint(width * .36f, height * .87f))); //E206
            points.Add(new MapPoint("E205", new SKPoint(width * .385f, height * .94f))); //E205
            points.Add(new MapPoint("E204", new SKPoint(width * .385f, height * .84f))); //E204
            points.Add(new MapPoint("E203", new SKPoint(width * .385f, height * .74f))); //E203

            points.Add(new MapPoint("E210", new SKPoint(width * .385f, height * .42f))); //E210
            points.Add(new MapPoint("E211", new SKPoint(width * .385f, height * .50f))); //E211
            points.Add(new MapPoint("E212", new SKPoint(width * .42f, height * .52f))); //E212

            return points;
        }

        // loadFromFile()
        // loadFromServer()
    }
}
