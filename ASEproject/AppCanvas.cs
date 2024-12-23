using BOOSE;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASEproject
{
    /// <summary>
    /// Represents the canvas
    /// </summary>
    public class AppCanvas : ICanvas
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
        
        private Graphics? g; //declaring g as nullable if it can remain nullable temporarily


        /// <summary>
        /// initializes new instance of the <see cref="AppCanvas"/> class
        /// </summary>
        public AppCanvas()
        {
            Set(XSIZE, YSIZE);
            penColour = Color.Black;
            pen = new Pen(penColour, penSize);
            brush = new SolidBrush(penColour);

            g = Graphics.FromImage(bm);
        }
        /// <summary>
        /// gets sets the X position of pen
        /// </summary>
        public int Xpos 
        { 
            get => xPos; 
            set => xPos = value; 
        }

        /// <summary>
        /// gets sets the Y position of pen
        /// </summary>
        public int Ypos 
        { 
            get => yPos; 
            set => yPos = value; 
        }

        /// <summary>
        /// gets sets color of pen
        /// </summary>
        public object PenColour 
        { 
            get => penColour; 
            set => penColour=(Color)value; 
        }

        /// <summary>
        /// Draws circle using the pen position as the center
        /// </summary>
        /// <param name="radius">radius of circle</param>
        /// <param name="filled">indicates whether the circle should be filled or not</param>
        /// <exception cref="CanvasException">thrown if radius is invalid</exception>
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
                else
                {
                    g.FillEllipse(brush, xPos - radius, yPos - radius, radius * 2, radius * 2);
                }

           }
        }

        /// <summary>
        /// clears canvas by filling background with white
        /// </summary>
        public void Clear()
        {


            if (g == null)
            {
                throw new InvalidOperationException("Graphics object is not initialized. Did you forget to call Set()?");
            }

            g.Clear(Color.Gray); // Clears the canvas with a gray background.
            Debug.WriteLine("Canvas cleared.");
        }

        /// <summary>
        /// draws a line from current pen position to specified position
        /// </summary>
        /// <param name="toX">X-coodinate of the destination</param>
        /// <param name="toY">Y-coodinate of the destination</param>
        /// <exception cref="CanvasException">thrown if the destination coordinates are invalid</exception>
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

        /// <summary>
        /// gets bitmap representation of the canvas
        /// </summary>
        /// <returns>the bitmap object</returns>
        public object getBitmap()
        {
            return bm;
        }

        /// <summary>
        /// moves pen to the specified position
        /// </summary>
        /// <param name="x">the X-coordinate of the new postion</param>
        /// <param name="y">the Y-coordinate of the new postion</param>
        /// <exception cref="CanvasException">thrown if the cooordinates are invalid</exception>
        public void MoveTo(int x, int y)
        {
           if (x<0 || x >xCanvasSize || y<0 || y >yCanvasSize)
            {
                throw new CanvasException("Invalid screen position CMoveTo" + x + "," + y);
            }
           xPos = x;
           yPos = y;
        }

        /// <summary>
        /// draws a rectangle at the current pen position
        /// </summary>
        /// <param name="width">width of the rectangle</param>
        /// <param name="height">height of the rectangle</param>
        /// <param name="filled">indicates whether the rectangle should be filled or not</param>
        /// <exception cref="CanvasException">thrown if the dimensions are invalid</exception>
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

        /// <summary>
        /// resets the pen position and pen colour to its initial state
        /// </summary>
        public void Reset()
        {
            xPos =yPos= 0;
            penColour = Color.Black;
        }

        /// <summary>
        /// sets the size of the canvas
        /// </summary>
        /// <param name="xsize">width of the canvas</param>
        /// <param name="ysize">height of the canvas</param>
        public void Set(int xsize, int ysize)
        {
            xCanvasSize = xsize;
            yCanvasSize = ysize;
            xPos = yPos= 0;
            g = Graphics.FromImage(bm);
        }

        /// <summary>
        /// sets the pen and brush color using RGB values
        /// </summary>
        /// <param name="red">red component of color</param>
        /// <param name="green">green component of color</param>
        /// <param name="blue">blue component of color</param>
        /// <exception cref="ArgumentException">thrown if any component is out of range</exception>
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

        /// <summary>
        /// draws a triangle at the current pen postion
        /// </summary>
        /// <param name="width">width of the triangle</param>
        /// <param name="height">height of the triangle</param>
        /// <exception cref="CanvasException">thrown when the values are invalid</exception>
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

        /// <summary>
        /// writes text at the current pen position
        /// </summary>
        /// <param name="text">the text to be written</param>
        public void WriteText(string text)
        {
            Font font = new Font("Arial", 10);
            g.DrawString(text, font, brush, Xpos, Ypos);
        }
    }
}
