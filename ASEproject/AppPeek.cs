using BOOSE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASEproject
{
    public class AppPeek : AppArray
    {

        public override void CheckParameters(string[] parameter)
        {
            if (parameterList.Length != 2 && parameterList.Length != 3)
            {
                throw new CommandException("Invalid parameter");
            }
        }

        public override void Compile()
        {
            ProcessArrayParametersCompile(peekOrPoke: false);
        }

        public override void Execute()
        {
            ProcessArrayParametersExecute(peekOrPoke: false);
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

            throw new CommandException("Invalid datatype");
        }
    }
}
