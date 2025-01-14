using BOOSE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASEproject
{
    public class AppArray : BOOSE.Array, ICommand
    {
        public override void CheckParameters(string[] parameterList)
        {
            base.Parameters = base.ParameterList.Trim().Split(" ");
            if (base.Parameters.Length != 3 && base.Parameters.Length != 4)
            {
                throw new CommandException("invalid array");
            }
        }

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
