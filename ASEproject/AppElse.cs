using BOOSE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASEproject
{
    /// <summary>
    /// Represents the 'Else' command in the application.
    /// Inherits from the <see cref="Else"/> class and modifies its behavior.
    /// </summary>
    public class AppElse : Else
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AppElse"/> class.
        /// Calls the <see cref="ReduceRestrictions"/> method to reduce restrictions for this command.
        /// </summary>
        public AppElse()
        {
            ReduceRestrictions();
        }

        /// <summary>
        /// This method is intended to define any restrictions for the 'Else' command.
        /// Currently, it does not add any restrictions, but it can be extended in the future.
        /// </summary>
        public override void Restrictions()
        {
        }
    }
}
