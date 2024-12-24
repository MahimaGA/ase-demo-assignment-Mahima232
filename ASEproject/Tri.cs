using BOOSE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Contains the main classes and logic for the ASEproject application.
/// </summary>
namespace ASEproject
{
    /// <summary>
    /// represents a command to draw a triangle on canvas
    /// </summary>
    public class Tri : CommandTwoParameters
    {
        private int width, height;
        /// <summary>
        /// initializes new instance of the <see cref="Tri"/> class 
        /// </summary>
        public Tri()
        {
        }

        /// <summary>
        /// initializes new instances of the <see cref="Tri"/> class with specified dimensions
        /// </summary>
        /// <param name="c">the canvas</param>
        /// <param name="width">the width of the triangle</param>
        /// <param name="height">the height of the triangle</param>
        public Tri(Canvas c, int width, int height)
            : base(c)
        {
            this.width = width;
            this.height = height;
        }

        /// <summary>
        /// executes the triangle drawing command
        /// </summary>
        public override void Execute()
        {
            base.Execute();
            width = base.Paramsint[0];
            height = base.Paramsint[1];

            base.Canvas.Tri(base.Paramsint[0], base.Paramsint[1]);
        }

        /// <summary>
        /// validates the parameters for the triangle drawing command
        /// </summary>
        /// <param name="parameterList">list of parameters to validate</param>
        /// <exception cref="CommandException">thrown if the parameter list is invalid</exception>
        public override void CheckParameters(string[] parameterList)
        {
            if (parameterList.Length != 2)
            {
                throw new CommandException("There must be 2 parameters");
            }
        }
    }
}
