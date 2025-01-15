using BOOSE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASEproject
{
    /// <summary>
    /// Represents the 'End' command in the application.
    /// Inherits from the <see cref="End"/> class and modifies its behavior.
    /// </summary>
    public class AppEnd : End
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AppEnd"/> class.
        /// </summary>
        public AppEnd()
        {
            ReduceRestrictions();
        }

        /// <summary>
        /// This method is intended to define any restrictions for the 'End' command.
        /// Currently, it does not add any restrictions, but it can be extended in the future.
        /// </summary>
        public override void Restrictions()
        {
            // No specific restrictions are defined in this class, but can be implemented later.
        }
    }
}
