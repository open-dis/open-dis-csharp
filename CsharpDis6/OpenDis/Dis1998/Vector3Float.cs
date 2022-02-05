using System;

namespace OpenDis.Dis1998
{
    /// <summary>
    /// Section 5.2.33. Three floating point values, x, y, and z
    /// </summary>
    public partial class Vector3Float
    {
        /// <summary>
        /// Calculates the length of the vector.
        /// </summary>
        /// <returns>The length of the vector.</returns>
        public double CalculateLength() => Math.Sqrt(Math.Pow(X, 2) + Math.Pow(Y, 2) + Math.Pow(Z, 2));
    }
}
