using System;

namespace OpenDis.Core
{
    public class CetBase
    {
        /// <summary>
        /// Verifies the string if it contains only numerical characters (0-9).
        /// </summary>
        /// <param name="value">The value to be verified.</param>
        /// <param name="allowNullOrEmpty">if set to <c>true</c> allow null or empty value does not result
        /// in an exception.</param>
        /// <exception cref="ArgumentNullException">When the <c>allowNullOrEmpty</c> is false and value is
        /// null or empty.</exception>
        /// <exception cref="ArgumentOutOfRangeException">When the value is not null or empty and contains 
        /// non-numerical character.</exception>
        protected void VerifyNumericString(string value, bool allowNullOrEmpty)
        {
            if (!allowNullOrEmpty &&
                string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException("Value must be greater or equal to 0.");
            }

            if (value != null)
            {
                for (int i = 0; i < value.Length; i++)
                {
                    if (value[i] < '0' || value[i] > '9')
                    {
                        throw new ArgumentOutOfRangeException("Value must be greater or equal to 0.");
                    }
                }
            }
        }
    }
}