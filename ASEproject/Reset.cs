using BOOSE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ASEproject
{
    /// <summary>
    /// represents a command that resets pen position and color
    /// </summary>
    public class Reset : CommandOneParameter
    {
        private string[] parameters;
        private Color penColour;

        /// <summary>
        /// initializes a new instance of the <see cref="Reset"/> class
        /// </summary>
        public Reset()
        {

        }

        /// <summary>
        /// initializes a new instance of the <see cref="Reset"/> class with canvas
        /// </summary>
        /// <param name="canvas">the canvas to reset</param>
        public Reset(Canvas canvas) : base(canvas)
        {
                canvas.Reset();
            
        }

        /// <summary>
        /// executes reset command
        /// </summary>
        public override void Execute()
        {
            canvas.Reset();
            string message = "Canvas reset successfully!";
            MessageBox.Show(message, "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// validates that no parameter is provided
        /// </summary>
        /// <param name="Parameters">parameters to validate</param>
        /// <exception cref="ArgumentException">thrown when parameter given for reset</exception>
        public override void CheckParameters(string[] Parameters)
        {

            if (Parameters[0] != "")
                throw new ArgumentException("Reset command does not require any parameters.");
        }
    }
}