using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BOOSE;

/// <summary>
/// represents a command that clears the canvas and sets background to grey
/// </summary>
public class Clear : CommandOneParameter
    {
        private string[] parameters;

    /// <summary>
    /// initializes new instance of the <see cref="Clear"/> class 
    /// </summary>
    public Clear()
        {
        }
        public Clear(Canvas canvas) : base(canvas)
        {

        }


    /// <summary>
    /// executes the clear command, which clears the canvas and displays a notification
    /// </summary>
    public override void Execute()
        {
            canvas.Clear();
            string message = "Canvas Clear successfully";
            MessageBox.Show(message, "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


    /// <summary>
    /// initializes new instances of the <see cref="Clear"/> class with specified dimensions
    /// </summary>
    /// <param name="Parameters">parameter to validate</param>
    /// <exception cref="ArgumentException">thrown when parameters are provided</exception>
    public void CheckParameters(string[] Parameters)
        {

            if (Parameters.Length > 0)
                throw new ArgumentException("Clear command does not require any parameters.");
        }
    }
