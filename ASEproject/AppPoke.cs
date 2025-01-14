using BOOSE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASEproject
{
    public class AppPoke : AppArray
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
            ProcessArrayParametersCompile(peekOrPoke: true);
        }

        public override void Execute()
        {
            ProcessArrayParametersExecute(peekOrPoke: true);
        }

        public override void Set(StoredProgram Program, string Params)
        {
            base.Set(Program, Params);
        }
    }
}
