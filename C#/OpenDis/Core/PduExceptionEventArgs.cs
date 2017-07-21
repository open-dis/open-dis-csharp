using System;

namespace OpenDis.Core
{
    public class PduExceptionEventArgs : EventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PduExceptionEventArgs"/> class.
        /// </summary>
        /// <param name="e">The exception.</param>
        public PduExceptionEventArgs(Exception e)
        {
            this.Exception = e;
        }

        /// <summary>
        /// Gets or sets the exception.
        /// </summary>
        /// <value>The exception.</value>
        public Exception Exception { get; set; }
    }
}
