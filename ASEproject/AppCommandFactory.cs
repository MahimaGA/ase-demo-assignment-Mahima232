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
    /// CommandFactory class for adding more commands
    /// </summary>
    public class AppCommandFactory : CommandFactory
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
