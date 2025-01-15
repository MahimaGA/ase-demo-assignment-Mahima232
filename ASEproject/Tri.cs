using BOOSE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ASEproject
{
    /// <summary>
    /// Represents a command to draw a triangle on the canvas.
    /// Inherits from <see cref="CommandTwoParameters"/>.
    /// </summary>
    public class Tri : CommandTwoParameters
    {
        /// <summary>
        /// The width of the triangle.
        /// </summary>
        private int width;

        /// <summary>
        /// The height of the triangle.
        /// </summary>
        private int height;

        /// <summary>
        /// Initializes a new instance of the <see cref="Tri"/> class.
        /// </summary>
        public Tri()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Tri"/> class with specified dimensions.
        /// </summary>
        /// <param name="c">The canvas on which the triangle will be drawn.</param>
        /// <param name="width">The width of the triangle.</param>
        /// <param name="height">The height of the triangle.</param>
        public Tri(Canvas c, int width, int height)
            : base(c)
        {
            this.width = width;
            this.height = height;
        }

        /// <summary>
        /// Executes the command to draw a triangle on the canvas.
        /// Uses the parameters to define the width and height of the triangle.
        /// </summary>
        public override void Execute()
        {
            base.Execute();
            width = base.Paramsint[0];
            height = base.Paramsint[1];

            base.Canvas.Tri(width, height);
        }

        /// <summary>
        /// Validates the parameters provided for the triangle drawing command.
        /// Ensures that exactly two parameters are provided.
        /// </summary>
        /// <param name="parameterList">The list of parameters to validate.</param>
        /// <exception cref="CommandException">
        /// Thrown if the number of parameters is not equal to 2.
        /// </exception>
        public override void CheckParameters(string[] parameterList)
        {
            if (parameterList.Length != 2)
            {
                throw new CommandException("There must be exactly 2 parameters for the 'Tri' command.");
            }
        }
    }
}