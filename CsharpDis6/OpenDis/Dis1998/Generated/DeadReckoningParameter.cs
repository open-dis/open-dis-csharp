// Copyright (c) 1995-2009 held by the author(s).  All rights reserved.
// Redistribution and use in source and binary forms, with or without
// modification, are permitted provided that the following conditions
// are met:
// * Redistributions of source code must retain the above copyright
//    notice, this list of conditions and the following disclaimer.
// * Redistributions in binary form must reproduce the above copyright
//   notice, this list of conditions and the following disclaimer
//   in the documentation and/or other materials provided with the
//   distribution.
// * Neither the names of the Naval Postgraduate School (NPS)
//   Modeling Virtual Environments and Simulation (MOVES) Institute
//   (http://www.nps.edu and http://www.MovesInstitute.org)
//   nor the names of its contributors may be used to endorse or
//   promote products derived from this software without specific
//   prior written permission.
// 
// THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS
// AS IS AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT
// LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS
// FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE
// COPYRIGHT OWNER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT,
// INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING,
// BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES;
// LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER
// CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT
// LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN
// ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE
// POSSIBILITY OF SUCH DAMAGE.
//
// Copyright (c) 2008, MOVES Institute, Naval Postgraduate School. All 
// rights reserved. This work is licensed under the BSD open source license,
// available at https://www.movesinstitute.org/licenses/bsd.html
//
// Author: DMcG
// Modified for use with C#:
//  - Peter Smith (Naval Air Warfare Center - Training Systems Division)
//  - Zvonko Bostjancic (Blubit d.o.o. - zvonko.bostjancic@blubit.si)

using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Text;
using System.Xml.Serialization;
using OpenDis.Core;

namespace OpenDis.Dis1998
{
    /// <summary>
    /// represents values used in dead reckoning algorithms
    /// </summary>
    [Serializable]
    [XmlRoot]
    [XmlInclude(typeof(Vector3Float))]
    public partial class DeadReckoningParameter : IEquatable<DeadReckoningParameter>, IReflectable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DeadReckoningParameter"/> class.
        /// </summary>
        public DeadReckoningParameter()
        {
        }

        /// <summary>
        /// Implements the operator !=.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>
        ///    <c>true</c> if operands are not equal; otherwise, <c>false</c>.
        /// </returns>
        public static bool operator !=(DeadReckoningParameter left, DeadReckoningParameter right) => !(left == right);

        /// <summary>
        /// Implements the operator ==.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>
        ///    <c>true</c> if both operands are equal; otherwise, <c>false</c>.
        /// </returns>
        public static bool operator ==(DeadReckoningParameter left, DeadReckoningParameter right)
            => ReferenceEquals(left, right) || (left is not null && right is not null && left.Equals(right));

        public virtual int GetMarshalledSize()
        {
            int marshalSize = 0;

            marshalSize += 1;  // this._deadReckoningAlgorithm
            marshalSize += 15 * 1;  // _otherParameters
            marshalSize += EntityLinearAcceleration.GetMarshalledSize();  // this._entityLinearAcceleration
            marshalSize += EntityAngularVelocity.GetMarshalledSize();  // this._entityAngularVelocity
            return marshalSize;
        }

        /// <summary>
        /// Gets or sets the enumeration of what dead reckoning algorighm to use
        /// </summary>
        [XmlElement(Type = typeof(byte), ElementName = "deadReckoningAlgorithm")]
        public byte DeadReckoningAlgorithm { get; set; }

        /// <summary>
        /// Gets or sets the other parameters to use in the dead reckoning algorithm
        /// </summary>
        [XmlArray(ElementName = "otherParameters")]
        public byte[] OtherParameters { get; set; } = new byte[15];

        /// <summary>
        /// Gets or sets the Linear acceleration of the entity
        /// </summary>
        [XmlElement(Type = typeof(Vector3Float), ElementName = "entityLinearAcceleration")]
        public Vector3Float EntityLinearAcceleration { get; set; } = new Vector3Float();

        /// <summary>
        /// Gets or sets the angular velocity of the entity
        /// </summary>
        [XmlElement(Type = typeof(Vector3Float), ElementName = "entityAngularVelocity")]
        public Vector3Float EntityAngularVelocity { get; set; } = new Vector3Float();

        /// <summary>
        /// Occurs when exception when processing PDU is caught.
        /// </summary>
        public event EventHandler<PduExceptionEventArgs> ExceptionOccured;

        /// <summary>
        /// Called when exception occurs (raises the <see cref="Exception"/> event).
        /// </summary>
        /// <param name="e">The exception.</param>
        protected void RaiseExceptionOccured(Exception e)
        {
            if (PduBase.FireExceptionEvents && ExceptionOccured != null)
            {
                ExceptionOccured(this, new PduExceptionEventArgs(e));
            }
        }

        /// <summary>
        /// Marshal the data to the DataOutputStream. Note: Length needs to be set before calling this method
        /// </summary>
        /// <param name="dos">The DataOutputStream instance to which the PDU is marshaled.</param>
        [SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Justification = "Due to ignoring errors.")]
        public virtual void Marshal(DataOutputStream dos)
        {
            if (dos != null)
            {
                try
                {
                    dos.WriteUnsignedByte(DeadReckoningAlgorithm);

                    for (int idx = 0; idx < OtherParameters.Length; idx++)
                    {
                        dos.WriteByte(OtherParameters[idx]);
                    }

                    EntityLinearAcceleration.Marshal(dos);
                    EntityAngularVelocity.Marshal(dos);
                }
                catch (Exception e)
                {
                    if (PduBase.TraceExceptions)
                    {
                        Trace.WriteLine(e);
                        Trace.Flush();
                    }

                    RaiseExceptionOccured(e);

                    if (PduBase.ThrowExceptions)
                    {
                        throw;
                    }
                }
            }
        }

        [SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Justification = "Due to ignoring errors.")]
        public virtual void Unmarshal(DataInputStream dis)
        {
            if (dis != null)
            {
                try
                {
                    DeadReckoningAlgorithm = dis.ReadUnsignedByte();

                    for (int idx = 0; idx < OtherParameters.Length; idx++)
                    {
                        OtherParameters[idx] = dis.ReadByte();
                    }

                    EntityLinearAcceleration.Unmarshal(dis);
                    EntityAngularVelocity.Unmarshal(dis);
                }
                catch (Exception e)
                {
                    if (PduBase.TraceExceptions)
                    {
                        Trace.WriteLine(e);
                        Trace.Flush();
                    }

                    RaiseExceptionOccured(e);

                    if (PduBase.ThrowExceptions)
                    {
                        throw;
                    }
                }
            }
        }

        ///<inheritdoc/>
        [SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Justification = "Due to ignoring errors.")]
        public virtual void Reflection(StringBuilder sb)
        {
            sb.AppendLine("<DeadReckoningParameter>");
            try
            {
                sb.AppendLine("<deadReckoningAlgorithm type=\"byte\">" + DeadReckoningAlgorithm.ToString(CultureInfo.InvariantCulture) + "</deadReckoningAlgorithm>");
                for (int idx = 0; idx < OtherParameters.Length; idx++)
                {
                    sb.AppendLine("<otherParameters" + idx.ToString(CultureInfo.InvariantCulture) + " type=\"byte\">" + OtherParameters[idx] + "</otherParameters" + idx.ToString(CultureInfo.InvariantCulture) + ">");
                }

                sb.AppendLine("<entityLinearAcceleration>");
                EntityLinearAcceleration.Reflection(sb);
                sb.AppendLine("</entityLinearAcceleration>");
                sb.AppendLine("<entityAngularVelocity>");
                EntityAngularVelocity.Reflection(sb);
                sb.AppendLine("</entityAngularVelocity>");
                sb.AppendLine("</DeadReckoningParameter>");
            }
            catch (Exception e)
            {
                if (PduBase.TraceExceptions)
                {
                    Trace.WriteLine(e);
                    Trace.Flush();
                }

                RaiseExceptionOccured(e);

                if (PduBase.ThrowExceptions)
                {
                    throw;
                }
            }
        }

        /// <inheritdoc/>
        public override bool Equals(object obj) => this == obj as DeadReckoningParameter;

        ///<inheritdoc/>
        public bool Equals(DeadReckoningParameter obj)
        {
            bool ivarsEqual = true;

            if (obj.GetType() != GetType())
            {
                return false;
            }

            if (DeadReckoningAlgorithm != obj.DeadReckoningAlgorithm)
            {
                ivarsEqual = false;
            }

            if (obj.OtherParameters.Length != 15)
            {
                ivarsEqual = false;
            }

            if (ivarsEqual)
            {
                for (int idx = 0; idx < 15; idx++)
                {
                    if (OtherParameters[idx] != obj.OtherParameters[idx])
                    {
                        ivarsEqual = false;
                    }
                }
            }

            if (!EntityLinearAcceleration.Equals(obj.EntityLinearAcceleration))
            {
                ivarsEqual = false;
            }

            if (!EntityAngularVelocity.Equals(obj.EntityAngularVelocity))
            {
                ivarsEqual = false;
            }

            return ivarsEqual;
        }

        /// <summary>
        /// HashCode Helper
        /// </summary>
        /// <param name="hash">The hash value.</param>
        /// <returns>The new hash value.</returns>
        private static int GenerateHash(int hash) => hash << (5 + hash);

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            int result = 0;

            result = GenerateHash(result) ^ DeadReckoningAlgorithm.GetHashCode();

            for (int idx = 0; idx < 15; idx++)
            {
                result = GenerateHash(result) ^ OtherParameters[idx].GetHashCode();
            }

            result = GenerateHash(result) ^ EntityLinearAcceleration.GetHashCode();
            result = GenerateHash(result) ^ EntityAngularVelocity.GetHashCode();

            return result;
        }
    }
}
