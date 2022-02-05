using System;

namespace OpenDis
{
    internal interface IHashable<T> : IEquatable<T>
    {
        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        ///    A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.
        /// </returns>
        int GetHashCode();
    }
}
