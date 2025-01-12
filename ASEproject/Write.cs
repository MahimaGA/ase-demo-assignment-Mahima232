using BOOSE;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ASEproject
{
    /// <summary>
    /// writes text in canvas
    /// </summary>
    public class Write : CommandOneParameter
    {
        private string text=" ";

        /// <summary>
        /// initializes new instance of the <see cref="Write"/> class
        /// </summary>
        public Write()
        {
        }

        /// <summary>
        /// initializes new instace of <see cref="Write"/> class
        /// </summary>
        /// <param name="c">canvas to write on</param>
        /// <param name="text">text to write</param>
        public Write(Canvas c,string text)
            : base(c)
        {
            this.text = text;
        }

        /// <summary>
        /// executes the write command by writing the text on to the canvas
        /// </summary>
        public override void Execute()
        {
            //base.Execute();
            try
            {
                text = base.Program.EvaluateExpression(base.Parameters[0]);
            }
            catch (StoredProgramException)
            { 
                text = base.Program.EvaluateExpressionWithString(base.Parameters[0]);
            }

            base.Canvas.WriteText(text);
        }

        /// <summary>
        /// validates the paramentes for write command
        /// </summary>
        /// <param name="parameterList">the list of parameters to validate</param>
        /// <exception cref="CommandException">thrown if parameter list is invalid</exception>
        public override void CheckParameters(string[] parameterList)
        {
            if (parameterList.Length < 0)
            {
                throw new CommandException("There must be atleast one parameter");
            }
        }
    }
}
