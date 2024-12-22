using BOOSE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASEproject
{
    public class AppCommandFactory : CommandFactory
    {
        public override ICommand MakeCommand(string commandType)
        {
            commandType = commandType.ToLower().Trim();
            if (commandType == "tri")
            {
                return new Tri();
            }
            if (commandType == "write")
            {
                return new Write();
            }

            return base.MakeCommand(commandType);
        }
    }
}
