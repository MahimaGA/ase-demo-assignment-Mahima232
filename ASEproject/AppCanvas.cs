using BOOSE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASEproject
{
    internal class AppCanvas : ICanvas
    {
        private int xPos, yPos; //pen position
        private Color penColour;
        private Pen Pen;
        private int penSize = 5;
        int XCanvasSize, YCanvasSize;
        const int XSIZE = 640; //standard size of canvas
        const int YSIZE = 480;
        
        Bitmap bm = new Bitmap(XSIZE, YSIZE);

        Graphics g;

        public AppCanvas()
        {
            Set(XSIZE, YSIZE);
        }

        public int Xpos 
        { 
            get => xpos; 
            set => xpos = value; 
        }

        public int Ypos 
        { 
            get => ypos; 
            set => ypos = value; 
        }
        public object PenColour 
        { 
            get => penColour; 
            set => penColour=(Color)value; 
        }

        public void Circle(int radius, bool filled)
        {
           if (radius < 0)
            {
                throw new CanvasException("Invalid circle radius" + radius);
            }
           if (g!= null)
           {
                if (!filled)
                {
                    g.DrawEllipse(Pen, xPos - radius, yPos - radius, radius * 2, radius * 2);
                }
           }
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public void DrawTo(int toX, int toY)
        {
            if (toX < 0 || toX > XCanvasSize || toX < 0 || toY > YCanvasSize)
            {
                throw new CanvasException("Invalid screen position drawto " + toX + "," + toY);
            }
            if (g != null)
            {
                g.DrawLine(Pen, Xpos, Ypos, toX, toY); //draw the line
            }
            xPos = toX;
            yPos = toY; //update pen position


        }

        public object getBitmap()
        {
            throw new NotImplementedException();
        }

        public void MoveTo(int x, int y)
        {
           if (x<0 || x >XCanvasSize || y<0 || y >YCanvasSize)
            {
                throw new CanvasException("Invalid screen position CMoveTo" + x + "," + y);
            }
           xPos = x;
           yPos = y;
        }

        public void Rect(int width, int height, bool filled)
        {
            throw new NotImplementedException();
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }

        public void Set(int xsize, int ysize)
        {
            XCanvasSize = xsize;
            YCanvasSize = ysize;
            xpos = ypos= 0;
            XCanvasSize = xsize;
            g = Graphics.FromImage(bm);
        }

        public void SetColour(int red, int green, int blue)
        {
            if (red > 255 || green > 255 || blue > 255)
            { 
            throw new ArgumentException("Invalid colour" + red + "," + green + "," + blue);
            }
            penColour = Color.FromArgb(red, green, blue); //alpha of 255
            Pen = new Pen(penColour, penSize);
            
        }

        public void Tri(int width, int height)
        {
            throw new NotImplementedException();
        }

        public void WriteText(string text)
        {
            throw new NotImplementedException();
        }
    }
}
