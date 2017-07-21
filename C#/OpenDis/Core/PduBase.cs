using System;

namespace OpenDis.Core
{
    public abstract class PduBase
    {
        /// <summary>
        /// Gets or sets a value indicating whether exceptions caught in PDU classes are written via <see cref="System.Diagnostics.Trace"/> instrumetnation infrastructure.
        /// </summary>
        /// <value><c>true</c> if caught exceptions are traced; otherwise, <c>false</c>.</value>
        public static bool TraceExceptions { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether exceptions caught in PDU classes are rethrown.
        /// </summary>
        /// <value><c>true</c> if caught exceptions are rethrown; otherwise, <c>false</c>.</value>
        public static bool ThrowExceptions { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether exceptions caught in PDU classes fire <see cref="IPdu.ExceptionOccured"/> event.
        /// </summary>
        /// <value><c>true</c> if events are fired when exception is caught; otherwise, <c>false</c>.</value>
        public static bool FireExceptionEvents { get; set; }
    }
}
