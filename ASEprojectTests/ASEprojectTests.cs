using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASEproject;
using BOOSE;


namespace ASEprojectTests
{
    /// <summary>
    /// Contains the AppCAnvas tests
    /// </summary>
    [TestClass]
    public class AppCanvasTests
    {
        private ASEproject.AppCanvas canvas;

        /// <summary>
        /// Initializes a new instance of the AppCanvas class before each test.
        /// </summary>
        [TestInitialize]
        public void Setup()
        {
            canvas = new AppCanvas();
        }

        /// <summary>
        /// Tests setting the canvas size to specific dimensions.
        /// </summary>
        [TestMethod]
        public void Test_SetCanvasSize()
        {
            canvas.Set(800, 600);
            Assert.AreEqual(800, canvas.xCanvasSize);
            Assert.AreEqual(600, canvas.yCanvasSize);
        }

        /// <summary>
        /// Tests moving the pen to a valid position.
        /// </summary>
        [TestMethod]
        public void Test_MoveTo_ValidPosition()
        {
            canvas.MoveTo(200, 250);
            Assert.AreEqual(200, canvas.Xpos);
            Assert.AreEqual(250, canvas.Ypos);
        }
        /// <summary>
        /// Tests moving the pen to a invalid position.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(CanvasException))]
        public void Test_MoveTo_InvalidPosition()
        {
            canvas.MoveTo(-100, -100);
        }
    

        /// <summary>
        /// Tests setting the pen color with valid RGB values.
        /// </summary>
        [TestMethod]
        public void Test_SetColour_ValidValues()
        {
            canvas.SetColour(150, 210, 255);
            Assert.AreEqual(Color.FromArgb(255, 150, 210, 255), canvas.PenColour);
        }

        /// <summary>
        /// Tests setting the pen color with invalid RGB values, expecting an exception.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(CanvasException))]
        public void Test_SetColour_InvalidValues()
        {
            canvas.SetColour(280, 0, 0);
        }

        /// <summary>
        /// Tests drawing a rectangle with valid dimensions.
        /// </summary>
        [TestMethod]
        public void Test_DrawRectangle()
        {
            canvas.MoveTo(100, 100);
            canvas.Rect(200, 100, true);
        }
        /// <summary>
        /// Tests drawing a rectangle with invalid dimensions, expecting an exception.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(CanvasException))]
        public void Test_DrawRectangle_InvalidDimensions()
        {
            canvas.Rect(-20, 40, false);
        }

        /// <summary>
        /// Tests drawing a circle with a valid radius.
        /// </summary>
        [TestMethod]
        public void Test_DrawCircle_Valid()
        {
            canvas.MoveTo(200, 200);
            canvas.Circle(100, false);
        }

        /// <summary>
        /// Tests drawing a circle with an invalid radius, expecting an exception.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(CanvasException))]
        public void Test_DrawCircle_InvalidRadius()
        {
            canvas.Circle(-20, false);
        }

        /// <summary>
        /// Tests clearing the canvas.
        /// </summary>
        [TestMethod]
        public void Test_ClearCanvas()
        {
            canvas.Clear();
        }

        /// <summary>
        /// Tests drawing a triangle with valid dimensions.
        /// </summary>
        [TestMethod]
        public void Test_DrawTriangle_Valid()
        {
            canvas.MoveTo(100, 100);
            canvas.Tri(50, 30);
        }

        /// <summary>
        /// Tests drawing a triangle with invalid dimensions, expecting an exception.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(CanvasException))]
        public void Test_DrawTriangle_InvalidDimensions()
        {
            canvas.Tri(-20, 30);
        }

        /// <summary>
        /// Tests executing a multiline program with multiple MoveTo and DrawTo commands.
        /// Verifies the final pen position.
        /// </summary>
        [TestMethod]
        public void MultilineProgram_ExecutesCorrectly()
        {
            canvas.MoveTo(50, 50);
            canvas.DrawTo(100, 100);
            canvas.MoveTo(200, 200);
            canvas.DrawTo(300, 300);

            Assert.AreEqual(300, canvas.Xpos, "Final X position should be 300.");
            Assert.AreEqual(300, canvas.Ypos, "Final Y position should be 300.");
        }

        /// <summary>
        /// Tests resetting the pen position and pen color to its initial state.
        /// </summary>
        [TestMethod]
        public void Test_Reset()
        {
            canvas.MoveTo(100, 100);
            canvas.SetColour(150, 150, 150);
            canvas.Reset();

            Assert.AreEqual(0, canvas.Xpos, "Pen X position should reset to 0.");
            Assert.AreEqual(0, canvas.Ypos, "Pen Y position should reset to 0.");
            Assert.AreEqual(Color.Black, canvas.PenColour, "Pen color should reset to black.");
        }

        /// <summary>
        /// Tests writing text at the current pen position.
        /// </summary>
        [TestMethod]
        public void Test_WriteText()
        {
            canvas.MoveTo(50, 50);
            canvas.WriteText("Hello, Canvas!");
            // Assuming there's no direct way to verify the written text, 
            // this test checks that no exception is thrown and pen position remains the same.
            Assert.AreEqual(50, canvas.Xpos, "Pen X position should remain unchanged after writing text.");
            Assert.AreEqual(50, canvas.Ypos, "Pen Y position should remain unchanged after writing text.");
        }
    }

}



