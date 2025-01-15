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
    /// Represents the "Clear" command that clears the canvas and sets the background to grey.
    /// </summary>
    public class Clear : CommandOneParameter
    {
        private string[] parameters;

        /// <summary>
        /// Initializes a new instance of the <see cref="Clear"/> class.
        /// </summary>
        public Clear()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Clear"/> class with a specified canvas.
        /// </summary>
        /// <param name="canvas">The canvas to clear.</param>
        public Clear(Canvas canvas) : base(canvas)
        {
        }

        /// <summary>
        /// Executes the clear command, which clears the canvas and displays a notification.
        /// </summary>
        public override void Execute()
        {
            // Clears the canvas
            canvas.Clear();

            // Displays a message box to notify the user
            string message = "Canvas cleared successfully!";
            MessageBox.Show(message, "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Validates the parameters provided for the "Clear" command.
        /// The clear command does not require any parameters.
        /// </summary>
        /// <param name="Parameters">The parameters to validate.</param>
        /// <exception cref="ArgumentException">Thrown when parameters are provided.</exception>
        public override void CheckParameters(string[] Parameters)
        {
            // Ensure that no parameters are provided
            if (Parameters[0] != "")
                throw new ArgumentException("Clear command does not require any parameters.");
        }
    }
}
