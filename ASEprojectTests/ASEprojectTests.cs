using Microsoft.VisualStudio.TestTools.UnitTesting;
using ASEproject;
using System.Drawing;

namespace ASEprojectTests
{
    [TestClass]
    public class AppCanvasTests
    {
        public AppCanvas canvas;

        [TestInitialize]
        public void Setup()
        {
            canvas = new AppCanvas();
        }

        [TestMethod]
        public void TestMoveToCommand()
        {
            // Act
            canvas.MoveTo(100, 150);

            // Assert
            Assert.AreEqual(100, canvas.Xpos, "X position is not updated correctly.");
            Assert.AreEqual(150, canvas.Ypos, "Y position is not updated correctly.");
        }

        [TestMethod]
        public void TestDrawToCommand()
        {
            // Arrange
            canvas.MoveTo(50, 50);

            // Act
            canvas.DrawTo(100, 150);

            // Assert
            Assert.AreEqual(100, canvas.Xpos, "X position is not updated correctly after DrawTo.");
            Assert.AreEqual(150, canvas.Ypos, "Y position is not updated correctly after DrawTo.");
        }

        [TestMethod]
        public void TestMultiLineProgram()
        {
            // Arrange
            canvas.Set(200, 200); // Resize canvas for test
            canvas.MoveTo(10, 10);
            canvas.SetColour(255, 0, 0); // Red color
            canvas.DrawTo(100, 10); // Horizontal line
            canvas.DrawTo(100, 100); // Vertical line
            canvas.DrawTo(10, 100); // Another horizontal line
            canvas.DrawTo(10, 10); // Close the box

            // Assert the final pen position
            Assert.AreEqual(10, canvas.Xpos, "Final X position is not correct.");
            Assert.AreEqual(10, canvas.Ypos, "Final Y position is not correct.");

            // Validate bitmap (basic check for no exceptions/errors)
            Assert.IsNotNull(canvas.getBitmap(), "Bitmap should not be null after drawing.");
        }
    }
}
