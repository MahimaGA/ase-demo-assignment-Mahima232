using BOOSE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASEproject
{
    /// <summary>
    /// Represents the "Peek" command in the application.
    /// Inherits from the <see cref="AppArray"/> class and implements the command functionality.
    /// </summary>
    public class AppPeek : AppArray
    {
        /// <summary>
        /// Validates the parameters passed to the command.
        /// Throws an exception if the number of parameters is invalid.
        /// </summary>
        /// <param name="parameter">Array of parameters to be checked.</param>
        /// <exception cref="CommandException">Thrown when the number of parameters is not 2 or 3.</exception>
        public override void CheckParameters(string[] parameter)
        {
            if (parameterList.Length != 2 && parameterList.Length != 3)
            {
                throw new CommandException("Invalid parameter");
            }
        }

        /// <summary>
        /// Compiles the "Peek" command by processing array parameters.
        /// </summary>
        public override void Compile()
        {
            ProcessArrayParametersCompile(peekOrPoke: false);
        }

        /// <summary>
        /// Executes the "Peek" command, updating the variable with the correct type.
        /// </summary>
        public override void Execute()
        {
            ProcessArrayParametersExecute(peekOrPoke: false);

            // Update variable based on type (either "int" or "real")
            if (type.Equals("int"))
            {
                base.Program.UpdateVariable(peekVar, valueInt);
                return;
            }

            if (type.Equals("real"))
            {
                base.Program.UpdateVariable(peekVar, valueReal);
                return;
            }

            // If the type is neither "int" nor "real", throw an exception
            throw new CommandException("Invalid datatype");
        }
    }
}
