using BOOSE;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//// <summary>
//// Contains the main classes and logic for the ASEproject application.
//// </summary>
namespace ASEproject
{
    /// <summary>
    /// Represents the canvas where drawings are made.
    /// </summary>
    public class AppCanvas : ICanvas
    {
        private int xPos, yPos; // Pen position
        private Color penColour;
        private Pen pen;
        private SolidBrush brush;
        private int penSize = 5;
        public int xCanvasSize, yCanvasSize;
        const int XSIZE = 640; // Standard size of canvas
        const int YSIZE = 480;

        Bitmap bm = new Bitmap(XSIZE, YSIZE);

        private Graphics? g; // Declaring g as nullable if it can remain nullable temporarily

        public event EventHandler<(int X, int Y)>? PenPositionChanged;

        /// <summary>
        /// Initializes a new instance of the <see cref="AppCanvas"/> class.
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
        /// Gets or sets the X position of the pen.
        /// </summary>
        public int Xpos
        {
            get => xPos;
            set => xPos = value;
        }

        /// <summary>
        /// Gets or sets the Y position of the pen.
        /// </summary>
        public int Ypos
        {
            get => yPos;
            set => yPos = value;
        }

        /// <summary>
        /// Gets or sets the color of the pen.
        /// </summary>
        public object PenColour
        {
            get => penColour;
            set => penColour = (Color)value;
        }

        /// <summary>
        /// Draws a circle using the pen position as the center.
        /// </summary>
        /// <param name="radius">The radius of the circle.</param>
        /// <param name="filled">Indicates whether the circle should be filled or not.</param>
        /// <exception cref="CanvasException">Thrown if the radius is invalid.</exception>
        public void Circle(int radius, bool filled)
        {
            if (radius < 0)
            {
                throw new CanvasException("Invalid circle radius " + radius);
            }

            if (g != null)
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
        /// Clears the canvas by filling the background with white.
        /// </summary>
        /// <exception cref="InvalidOperationException">Thrown when the object is not initialized.</exception>
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
        /// Draws a line from the current pen position to the specified position.
        /// </summary>
        /// <param name="toX">The X-coordinate of the destination.</param>
        /// <param name="toY">The Y-coordinate of the destination.</param>
        /// <exception cref="CanvasException">Thrown if the destination coordinates are invalid.</exception>
        public void DrawTo(int toX, int toY)
        {
            if (toX < 0 || toX > xCanvasSize || toY < 0 || toY > yCanvasSize)
            {
                throw new CanvasException("Invalid screen position drawto " + toX + "," + toY);
            }

            if (g != null)
            {
                g.DrawLine(pen, Xpos, Ypos, toX, toY); // Draw the line
            }

            xPos = toX;
            yPos = toY; // Update pen position

            OnPenPositionChanged();  // Notify listeners of position change
        }

        private void OnPenPositionChanged()
        {
            PenPositionChanged?.Invoke(this, (xPos, yPos));
        }

        /// <summary>
        /// Gets the bitmap representation of the canvas.
        /// </summary>
        /// <returns>The bitmap object representing the canvas.</returns>
        public object getBitmap()
        {
            return bm;
        }

        /// <summary>
        /// Moves the pen to the specified position.
        /// </summary>
        /// <param name="x">The X-coordinate of the new position.</param>
        /// <param name="y">The Y-coordinate of the new position.</param>
        /// <exception cref="CanvasException">Thrown if the coordinates are invalid.</exception>
        public void MoveTo(int x, int y)
        {
            if (x < 0 || x > xCanvasSize || y < 0 || y > yCanvasSize)
            {
                throw new CanvasException("Invalid screen position CMoveTo " + x + "," + y);
            }

            xPos = x;
            yPos = y;
            OnPenPositionChanged();  // Notify listeners of position change
        }

        /// <summary>
        /// Draws a rectangle at the current pen position.
        /// </summary>
        /// <param name="width">The width of the rectangle.</param>
        /// <param name="height">The height of the rectangle.</param>
        /// <param name="filled">Indicates whether the rectangle should be filled or not.</param>
        /// <exception cref="CanvasException">Thrown if the dimensions are invalid.</exception>
        public void Rect(int width, int height, bool filled)
        {
            if (width < 0 || height < 0)
            {
                throw new CanvasException("Invalid rectangle dimensions " + width + "," + height);
            }

            if (g != null)
            {
                if (filled)
                {
                    g.FillRectangle(brush, xPos, yPos, width, height);
                }
                else
                {
                    g.DrawRectangle(pen, xPos, yPos, width, height);
                }
            }
        }

        /// <summary>
        /// Resets the pen position and color to their initial state.
        /// </summary>
        public void Reset()
        {
            xPos = yPos = 0;
            penColour = Color.Black;
        }

        /// <summary>
        /// Sets the size of the canvas.
        /// </summary>
        /// <param name="xsize">The width of the canvas.</param>
        /// <param name="ysize">The height of the canvas.</param>
        public void Set(int xsize, int ysize)
        {
            xCanvasSize = xsize;
            yCanvasSize = ysize;
            xPos = yPos = 0;
            g = Graphics.FromImage(bm);
        }

        /// <summary>
        /// Sets the pen and brush color using RGB values.
        /// </summary>
        /// <param name="red">The red component of the color.</param>
        /// <param name="green">The green component of the color.</param>
        /// <param name="blue">The blue component of the color.</param>
        /// <exception cref="CanvasException">Thrown if any component is out of range.</exception>
        public void SetColour(int red, int green, int blue)
        {
            if (red > 255 || green > 255 || blue > 255)
            {
                throw new CanvasException("Invalid colour " + red + "," + green + "," + blue);
            }

            penColour = Color.FromArgb(red, green, blue); // Alpha of 255
            pen = new Pen(penColour, penSize);
            brush = new SolidBrush(penColour);
        }

        /// <summary>
        /// Draws a triangle at the current pen position.
        /// </summary>
        /// <param name="width">The width of the triangle.</param>
        /// <param name="height">The height of the triangle.</param>
        /// <exception cref="CanvasException">Thrown if the dimensions are invalid.</exception>
        public void Tri(int width, int height)
        {
            try
            {
                if (width < 0 || height < 0)
                {
                    throw new CanvasException("Invalid triangle dimensions " + width + "," + height);
                }

                if (g != null)
                {
                    Point[] p = new Point[3];
                    p[0] = new Point((xPos + width) / 2, yPos);
                    p[1] = new Point(xPos, yPos + height);
                    p[2] = new Point(xPos + width, yPos + height);
                    g.DrawPolygon(pen, p);
                }
            }
            catch (CanvasException e)
            {
                throw;
            }
        }

        /// <summary>
        /// Writes text at the current pen position.
        /// </summary>
        /// <param name="text">The text to be written.</param>
        public void WriteText(string text)
        {
            Font font = new Font("Arial", 10);
            g.DrawString(text, font, brush, Xpos, Ypos);
        }
    }
}
