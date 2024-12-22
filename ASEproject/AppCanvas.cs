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
        private Pen pen;
        private SolidBrush brush;
        private int penSize = 5;
        int xCanvasSize, yCanvasSize;
        const int XSIZE = 640; //standard size of canvas
        const int YSIZE = 480;
        
        Bitmap bm = new Bitmap(XSIZE, YSIZE);

        Graphics g;

        public AppCanvas()
        {
            Set(XSIZE, YSIZE);
            penColour = Color.Black;
            pen = new Pen(penColour, penSize);
            brush = new SolidBrush(penColour);
        }

        public int Xpos 
        { 
            get => xPos; 
            set => xPos = value; 
        }

        public int Ypos 
        { 
            get => yPos; 
            set => yPos = value; 
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
                    g.DrawEllipse(pen, xPos - radius, yPos - radius, radius * 2, radius * 2);
                }
           }
        }

        public void Clear()
        {
            g.Clear(Color.White);     
        }

        public void DrawTo(int toX, int toY)
        {
            if (toX < 0 || toX > xCanvasSize || toX < 0 || toY > yCanvasSize)
            {
                throw new CanvasException("Invalid screen position drawto " + toX + "," + toY);
            }
            if (g != null)
            {
                g.DrawLine(pen, Xpos, Ypos, toX, toY); //draw the line
            }
            xPos = toX;
            yPos = toY; //update pen position
        }

        public object getBitmap()
        {
            return bm;
        }

        public void MoveTo(int x, int y)
        {
           if (x<0 || x >xCanvasSize || y<0 || y >yCanvasSize)
            {
                throw new CanvasException("Invalid screen position CMoveTo" + x + "," + y);
            }
           xPos = x;
           yPos = y;
        }

        public void Rect(int width, int height, bool filled)
        {
            if (width < 0 || height < 0)
            {
                throw new CanvasException("Invalid rectangle dimensions " + width + "," + height);
            }
            if (g != null)
            {
                if (!filled)
                {
                    g.DrawRectangle(pen, xPos, yPos, width, height);
                }
            }
        }

        public void Reset()
        {
            xPos =yPos= 0;
            penColour = Color.Black;
        }

        public void Set(int xsize, int ysize)
        {
            xCanvasSize = xsize;
            yCanvasSize = ysize;
            xPos = yPos= 0;
            g = Graphics.FromImage(bm);
        }

        public void SetColour(int red, int green, int blue)
        {
            if (red > 255 || green > 255 || blue > 255)
            { 
            throw new ArgumentException("Invalid colour" + red + "," + green + "," + blue);
            }
            penColour = Color.FromArgb(red, green, blue); //alpha of 255
            pen = new Pen(penColour, penSize);
            brush = new SolidBrush(penColour);
            
        }

        public void Tri(int width, int height)
        {
            if (width < 0 || height < 0)
            {
                throw new CanvasException("Invalid triangle dimensions " + width + "," + height);
            }
            if (g != null)
            {
                Point[] p = new Point[3];
                p[0] = new Point((xPos+width)/2, yPos);
                p[1] = new Point(xPos, yPos+height);
                p[2] = new Point(xPos+width, yPos+height);

                g.DrawPolygon(pen, p);
            }
        }

        public void WriteText(string text)
        {
            Font font = new Font("Arial", 10);
            g.DrawString(text, font, brush, Xpos, Ypos);
        }
    }
}
