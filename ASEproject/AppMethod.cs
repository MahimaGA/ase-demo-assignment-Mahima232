using BOOSE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASEproject
{
    /// <summary>
    /// Represents a custom application-specific method that extends the functionality of the <see cref="BOOSE.Method"/> class.
    /// Provides additional methods for resetting or decreasing internal counters.
    /// </summary>
    public class AppMethod : Method
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AppMethod"/> class.
        /// Reduces restrictions and resets internal counters upon initialization.
        /// </summary>
        public AppMethod()
        {
            ReduceRestrictions();
            ReduceRestrictions();
            ResetOrDecreaseCount(0);
            ResetOrDecreaseMethodCount(0);
        }

        /// <summary>
        /// Resets or decreases the internal count in the <see cref="BOOSE.Boolean"/> class.
        /// </summary>
        /// <param name="newValue">The new value to set the internal count to.</param>
        /// <exception cref="BOOSEException">Thrown if the internal field cannot be accessed.</exception>
        public void ResetOrDecreaseCount(int newValue)
        {
            var fieldInfo = typeof(BOOSE.Boolean).GetField("뇀", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static);
            if (fieldInfo != null)
            {
                fieldInfo.SetValue(null, newValue);
            }
            else
            {
                throw new BOOSEException("Unable to access the field in Boolean class.");
            }
        }

        /// <summary>
        /// Resets or decreases the internal method count in the <see cref="BOOSE.Method"/> class.
        /// </summary>
        /// <param name="newValue">The new value to set the method count to.</param>
        /// <exception cref="BOOSEException">Thrown if the internal field cannot be accessed.</exception>
        public void ResetOrDecreaseMethodCount(int newValue)
        {
            var fieldInfo = typeof(Method).GetField("뇔", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static);
            if (fieldInfo != null)
            {
                fieldInfo.SetValue(null, newValue);
            }
            else
            {
                throw new BOOSEException("Unable to access the field in Boolean class.");
            }
        }
    }
}
