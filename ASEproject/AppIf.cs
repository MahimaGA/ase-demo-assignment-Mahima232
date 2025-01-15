using BOOSE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASEproject
{
    /// <summary>
    /// Represents the 'If' command in the application.
    /// Inherits from the <see cref="If"/> class and modifies its behavior.
    /// </summary>
    public class AppIf : If
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AppIf"/> class.
        /// </summary>
        public AppIf()
        {
            ReduceRestrictions();
        }

        /// <summary>
        /// This method is intended to define any restrictions for the 'If' command.
        /// Currently, it does not add any restrictions, but it can be extended in the future.
        /// </summary>
        public override void Restrictions()
        {
        }
    }
}
