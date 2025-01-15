using BOOSE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASEproject
{
    /// <summary>
    /// Represents the "Poke" command in the application.
    /// Inherits from the <see cref="AppArray"/> class and implements the command functionality.
    /// </summary>
    public class AppPoke : AppArray
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
        /// Compiles the "Poke" command by processing array parameters.
        /// </summary>
        public override void Compile()
        {
            ProcessArrayParametersCompile(peekOrPoke: true);
        }

        /// <summary>
        /// Executes the "Poke" command, updating the array values as necessary.
        /// </summary>
        public override void Execute()
        {
            ProcessArrayParametersExecute(peekOrPoke: true);
        }

        /// <summary>
        /// Sets the program and parameters for the "Poke" command.
        /// </summary>
        /// <param name="Program">The stored program to set.</param>
        /// <param name="Params">The parameters for the command.</param>
        public override void Set(StoredProgram Program, string Params)
        {
            base.Set(Program, Params);
        }
    }
}
