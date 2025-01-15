using BOOSE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASEproject;


namespace ASEproject
{
    /// <summary>
    /// CommandFactory class for adding more commands
    /// </summary>
    public class AppCommandFactory : CommandFactory , ICommandFactory
    {
        /// <summary>
        /// Creates instance of commandType 
        /// </summary>
        /// <param name="commandType">To call the new command</param>
        /// <returns>an instance of the implemented class</returns>
        /// <exception cref="Exception">thrown if the commandType doesn't exist</exception>
        
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
            if (commandType == "clear")
            {
                return new Clear();
            }
            if (commandType == "reset")
            {
                return new Reset();
            }
            if (commandType == "int")
            {
                return new AppInt();
            }
            if (commandType == "real")
            {
                return new AppReal();
            }
            if (commandType == "peek")
            {
                return new AppPeek();
            }
            if (commandType == "poke")
            {
                return new AppPoke();
            }
            if (commandType == "array")
            {
                return new AppArray();
            }
            if (commandType == "if")
            {
                return new AppIf();
            }
            if (commandType == "else")
            {
                return new AppElse();
            }
            if (commandType == "for")
            {
                return new AppFor();
            }
            if (commandType == "while")
            {
                return new AppWhile();
            }
            if (commandType == "end")
            {
                return new AppEnd();
            }
            if (commandType == "method")
            {
                return new AppMethod();
            }


            try
            {
                return base.MakeCommand(commandType);
            }
            catch (FactoryException ex)
            {
                //throws when given invalid command
                throw new Exception($"Error in AppCommandFactory: Unknown command '{commandType}'", ex);
            }

        }
    }
}
