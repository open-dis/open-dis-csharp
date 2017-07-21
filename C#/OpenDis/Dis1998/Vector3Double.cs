using System;

namespace OpenDis.Dis1998
{
    /// <summary>
    /// Three floating point values, x, y, and z.
    /// </summary>
    public partial class Vector3Double
    {
        /// <summary>
        /// Calculates the length of the vector.
        /// </summary>
        /// <returns>The length of the vector.</returns>
        public double CalculateLength()
        {
            return Math.Sqrt(Math.Pow(this.X, 2) + Math.Pow(this.Y, 2) + Math.Pow(this.Z, 2));
        }
    }
}
