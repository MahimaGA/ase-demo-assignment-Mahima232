using BOOSE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASEproject
{
    /// <summary>
    /// Represents a custom implementation of the <see cref="While"/> class for the ASE project.
    /// Inherits from the base <see cref="While"/> class and provides additional functionality.
    /// </summary>
    public class AppWhile : While
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AppWhile"/> class.
        /// This constructor calls the base class method to reduce restrictions.
        /// </summary>
        public AppWhile()
        {
            ReduceRestrictions();
        }

        /// <summary>
        /// Provides custom logic for restrictions in the <see cref="AppWhile"/> class.
        /// This method currently has no restrictions defined.
        /// </summary>
        public override void Restrictions()
        {
        }
    }
}
