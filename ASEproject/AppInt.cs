using BOOSE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASEproject
{
    /// <summary>
    /// Represents the 'Int' command in the application.
    /// Inherits from the <see cref="Int"/> class and modifies its behavior.
    /// Implements the <see cref="ICommand"/> interface.
    /// </summary>
    public class AppInt : Int, ICommand
    {
        /// <summary>
        /// This method is intended to define any restrictions for the 'Int' command.
        /// Currently, it does not add any restrictions, but it can be extended in the future.
        /// </summary>
        public override void Restrictions()
        {
        }
    }
}
