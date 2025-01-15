using BOOSE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASEproject
{
    /// <summary>
    /// Represents a custom implementation of the Array class that also implements ICommand.
    /// This class processes array parameters for commands in the application.
    /// </summary>
    public class AppArray : BOOSE.Array, ICommand
    {
        /// <summary>
        /// Checks the validity of the parameters passed to the array command.
        /// Throws an exception if the parameters are not valid.
        /// </summary>
        /// <param name="parameterList">An array of strings containing the parameters to be checked.</param>
        /// <exception cref="CommandException">Thrown when the number of parameters is not 3 or 4.</exception>
        public override void CheckParameters(string[] parameterList)
        {
            base.Parameters = base.ParameterList.Trim().Split(" ");
            if (base.Parameters.Length != 3 && base.Parameters.Length != 4)
            {
                throw new CommandException("invalid array");
            }
        }

        /// <summary>
        /// Processes the array parameters for compiling, either for a 'peek' or 'poke' operation.
        /// </summary>
        /// <param name="peekOrPoke">A boolean indicating whether the operation is a 'peek' (false) or 'poke' (true) operation.</param>
        /// <exception cref="CommandException">Thrown when the array parameters are invalid or the array does not exist.</exception>
        protected override void ProcessArrayParametersCompile(bool peekOrPoke)
        {
            int num;
            int num2;
            if (!peekOrPoke)
            {
                num = 0;
                num2 = 1;
            }
            else
            {
                num = 1;
                num2 = 0;
            }

            string[] array = parameterList.Split('=');
            if (array.Length > 1)
            {
                pokeValue = array[num].Trim();
                peekVar = pokeValue;
            }

            string[] array2 = array[num2].Trim().Split(" ");
            if (array.Length < 2 || array2.Length < 1)
            {
                throw new CommandException("Invalid array parameters");
            }

            varName = array2[0].Trim();
            if (!program.VariableExists(varName))
            {
                throw new CommandException("Array does not exist");
            }

            rowS = array2[1];
            if (array2.Length == 3)
            {
                columnS = array2[2];
            }
        }
    }
}
