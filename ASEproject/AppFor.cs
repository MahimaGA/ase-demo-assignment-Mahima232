using BOOSE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASEproject
{
    /// <summary>
    /// Represents the 'For' command in the application.
    /// Inherits from the <see cref="For"/> class and modifies its behavior.
    /// </summary>
    public class AppFor : For
    {
        /// <summary>
        /// This method is intended to define any restrictions for the 'For' command.
        /// Currently, it does not add any restrictions, but it can be extended in the future.
        /// </summary>
        public override void Restrictions()
        {
        }
    }
}
