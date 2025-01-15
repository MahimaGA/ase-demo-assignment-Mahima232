using BOOSE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASEproject
{
    /// <summary>
    /// Represents the "Real" command in the application.
    /// Inherits from the <see cref="Real"/> class and implements the command functionality.
    /// </summary>
    public class AppReal : Real, ICommand
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AppReal"/> class.
        /// </summary>
        public AppReal() { }

        /// <summary>
        /// Defines any restrictions for the "Real" command.
        /// Currently, no restrictions are set.
        /// </summary>
        public override void Restrictions() 
        {
            
        }
    }
}
