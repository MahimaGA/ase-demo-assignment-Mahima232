using Microsoft.VisualStudio.TestTools.UnitTesting;
using ASEproject;
using System.Drawing;

/// <summary>
/// Contains the main classes and logic for the ASEproject application.
/// </summary>
namespace ASEproject
    {
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
                canvas.MoveTo(100, 150);
                Assert.AreEqual(100, canvas.Xpos);
                Assert.AreEqual(150, canvas.Ypos);
            }
            [TestMethod]
            [ExpectedException(typeof(Exception))]
            public void Test_MoveTo_InvalidPosition()
            {
                canvas.MoveTo(-10, -10);
            }

            /// <summary>
            /// Tests setting the pen color with valid RGB values.
            /// </summary>
            [TestMethod]
            public void Test_SetColour_ValidValues()
            {
                canvas.SetColour(120, 200, 255);
                Assert.AreEqual(Color.FromArgb(255, 120, 200, 255), canvas.PenColour);
            }

            /// <summary>
            /// Tests setting the pen color with invalid RGB values, expecting an exception.
            /// </summary>
            [TestMethod]
            [ExpectedException(typeof(Exception))]
            public void Test_SetColour_InvalidValues()
            {
                canvas.SetColour(300, 0, 0);
            }

            /// <summary>
            /// Tests drawing a rectangle with valid dimensions.
            /// </summary>
            [TestMethod]
            public void Test_DrawRectangle()
            {
                canvas.MoveTo(50, 50);
                canvas.Rect(100, 50, true);
            }
            /// <summary>
            /// Tests drawing a rectangle with invalid dimensions, expecting an exception.
            /// </summary>
            [TestMethod]
            [ExpectedException(typeof(Exception))]
            public void Test_DrawRectangle_InvalidDimensions()
            {
                canvas.Rect(-10, 20, false);
            }

            /// <summary>
            /// Tests drawing a circle with a valid radius.
            /// </summary>
            [TestMethod]
            public void Test_DrawCircle_Valid()
            {
                canvas.MoveTo(100, 100);
                canvas.Circle(50, false);
            }

            /// <summary>
            /// Tests drawing a circle with an invalid radius, expecting an exception.
            /// </summary>
            [TestMethod]
            [ExpectedException(typeof(Exception))]
            public void Test_DrawCircle_InvalidRadius()
            {
                canvas.Circle(-10, false);
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
                canvas.Tri(60, 40);
            }

            /// <summary>
            /// Tests drawing a triangle with invalid dimensions, expecting an exception.
            /// </summary>
            [TestMethod]
            [ExpectedException(typeof(Exception))]
            public void Test_DrawTriangle_InvalidDimensions()
            {
                canvas.Tri(-10, 20);
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
        }
    }



