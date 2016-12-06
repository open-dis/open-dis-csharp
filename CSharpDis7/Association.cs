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
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Xml.Serialization;
using DISnet.DataStreamUtilities;

namespace DISnet
{
    /// <summary>
    /// An entity's associations with other entities and/or locations. For each association, this record shall specify the type of the association, the associated entity's EntityID and/or the associated location's world coordinates. This record may be used (optionally) in a transfer transaction to send internal state data from the divesting simulation to the acquiring simulation (see 5.9.4). This record may also be used for other purposes. Section 6.2.10
    /// </summary>
    [Serializable]
    [XmlRoot]
    [XmlInclude(typeof(EntityID))]
    [XmlInclude(typeof(Vector3Double))]
    public partial class Association
    {
        private byte _associationType;

        private byte _padding4;

        /// <summary>
        /// identity of associated entity. If none, NO_SPECIFIC_ENTITY
        /// </summary>
        private EntityID _associatedEntityID = new EntityID();

        /// <summary>
        /// location, in world coordinates
        /// </summary>
        private Vector3Double _associatedLocation = new Vector3Double();

        /// <summary>
        /// Initializes a new instance of the <see cref="Association"/> class.
        /// </summary>
        public Association()
        {
        }

        /// <summary>
        /// Implements the operator !=.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>
        /// 	<c>true</c> if operands are not equal; otherwise, <c>false</c>.
        /// </returns>
        public static bool operator !=(Association left, Association right)
        {
            return !(left == right);
        }

        /// <summary>
        /// Implements the operator ==.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>
        /// 	<c>true</c> if both operands are equal; otherwise, <c>false</c>.
        /// </returns>
        public static bool operator ==(Association left, Association right)
        {
            if (object.ReferenceEquals(left, right))
            {
                return true;
            }

            if (((object)left == null) || ((object)right == null))
            {
                return false;
            }

            return left.Equals(right);
        }

        public virtual int GetMarshalledSize()
        {
            int marshalSize = 0; 

            marshalSize += 1;  // this._associationType
            marshalSize += 1;  // this._padding4
            marshalSize += this._associatedEntityID.GetMarshalledSize();  // this._associatedEntityID
            marshalSize += this._associatedLocation.GetMarshalledSize();  // this._associatedLocation
            return marshalSize;
        }

        [XmlElement(Type = typeof(byte), ElementName = "associationType")]
        public byte AssociationType
        {
            get
            {
                return this._associationType;
            }

            set
            {
                this._associationType = value;
            }
        }

        [XmlElement(Type = typeof(byte), ElementName = "padding4")]
        public byte Padding4
        {
            get
            {
                return this._padding4;
            }

            set
            {
                this._padding4 = value;
            }
        }

        /// <summary>
        /// Gets or sets the identity of associated entity. If none, NO_SPECIFIC_ENTITY
        /// </summary>
        [XmlElement(Type = typeof(EntityID), ElementName = "associatedEntityID")]
        public EntityID AssociatedEntityID
        {
            get
            {
                return this._associatedEntityID;
            }

            set
            {
                this._associatedEntityID = value;
            }
        }

        /// <summary>
        /// Gets or sets the location, in world coordinates
        /// </summary>
        [XmlElement(Type = typeof(Vector3Double), ElementName = "associatedLocation")]
        public Vector3Double AssociatedLocation
        {
            get
            {
                return this._associatedLocation;
            }

            set
            {
                this._associatedLocation = value;
            }
        }

        /// <summary>
        /// Occurs when exception when processing PDU is caught.
        /// </summary>
        public event Action<Exception> Exception;

        /// <summary>
        /// Called when exception occurs (raises the <see cref="Exception"/> event).
        /// </summary>
        /// <param name="e">The exception.</param>
        protected void OnException(Exception e)
        {
            if (this.Exception != null)
            {
                this.Exception(e);
            }
        }

        /// <summary>
        /// Marshal the data to the DataOutputStream.  Note: Length needs to be set before calling this method
        /// </summary>
        /// <param name="dos">The DataOutputStream instance to which the PDU is marshaled.</param>
        [SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Justification = "Due to ignoring errors.")]
        public virtual void Marshal(DataOutputStream dos)
        {
            if (dos != null)
            {
                try
                {
                    dos.WriteUnsignedByte((byte)this._associationType);
                    dos.WriteUnsignedByte((byte)this._padding4);
                    this._associatedEntityID.Marshal(dos);
                    this._associatedLocation.Marshal(dos);
                }
                catch (Exception e)
                {
#if DEBUG
                    Trace.WriteLine(e);
                    Trace.Flush();
#endif
                    this.OnException(e);
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
                    this._associationType = dis.ReadUnsignedByte();
                    this._padding4 = dis.ReadUnsignedByte();
                    this._associatedEntityID.Unmarshal(dis);
                    this._associatedLocation.Unmarshal(dis);
                }
                catch (Exception e)
                {
#if DEBUG
                    Trace.WriteLine(e);
                    Trace.Flush();
#endif
                    this.OnException(e);
                }
            }
        }

        /// <summary>
        /// This allows for a quick display of PDU data.  The current format is unacceptable and only used for debugging.
        /// This will be modified in the future to provide a better display.  Usage: 
        /// pdu.GetType().InvokeMember("Reflection", System.Reflection.BindingFlags.InvokeMethod, null, pdu, new object[] { sb });
        /// where pdu is an object representing a single pdu and sb is a StringBuilder.
        /// Note: The supplied Utilities folder contains a method called 'DecodePDU' in the PDUProcessor Class that provides this functionality
        /// </summary>
        /// <param name="sb">The StringBuilder instance to which the PDU is written to.</param>
        [SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Justification = "Due to ignoring errors.")]
        public virtual void Reflection(StringBuilder sb)
        {
            sb.AppendLine("<Association>");
            try
            {
                sb.AppendLine("<associationType type=\"byte\">" + this._associationType.ToString(CultureInfo.InvariantCulture) + "</associationType>");
                sb.AppendLine("<padding4 type=\"byte\">" + this._padding4.ToString(CultureInfo.InvariantCulture) + "</padding4>");
                sb.AppendLine("<associatedEntityID>");
                this._associatedEntityID.Reflection(sb);
                sb.AppendLine("</associatedEntityID>");
                sb.AppendLine("<associatedLocation>");
                this._associatedLocation.Reflection(sb);
                sb.AppendLine("</associatedLocation>");
                sb.AppendLine("</Association>");
            }
            catch (Exception e)
            {
#if DEBUG
                    Trace.WriteLine(e);
                    Trace.Flush();
#endif
                    this.OnException(e);
            }
        }

        /// <summary>
        /// Determines whether the specified <see cref="System.Object"/> is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="System.Object"/> to compare with this instance.</param>
        /// <returns>
        /// 	<c>true</c> if the specified <see cref="System.Object"/> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals(object obj)
        {
            return this == obj as Association;
        }

        /// <summary>
        /// Compares for reference AND value equality.
        /// </summary>
        /// <param name="obj">The object to compare with this instance.</param>
        /// <returns>
        /// 	<c>true</c> if both operands are equal; otherwise, <c>false</c>.
        /// </returns>
        public bool Equals(Association obj)
        {
            bool ivarsEqual = true;

            if (obj.GetType() != this.GetType())
            {
                return false;
            }

            if (this._associationType != obj._associationType)
            {
                ivarsEqual = false;
            }

            if (this._padding4 != obj._padding4)
            {
                ivarsEqual = false;
            }

            if (!this._associatedEntityID.Equals(obj._associatedEntityID))
            {
                ivarsEqual = false;
            }

            if (!this._associatedLocation.Equals(obj._associatedLocation))
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
        private static int GenerateHash(int hash)
        {
            hash = hash << (5 + hash);
            return hash;
        }

        /// <summary>
        /// Gets the hash code.
        /// </summary>
        /// <returns>The hash code.</returns>
        public override int GetHashCode()
        {
            int result = 0;

            result = GenerateHash(result) ^ this._associationType.GetHashCode();
            result = GenerateHash(result) ^ this._padding4.GetHashCode();
            result = GenerateHash(result) ^ this._associatedEntityID.GetHashCode();
            result = GenerateHash(result) ^ this._associatedLocation.GetHashCode();

            return result;
        }
    }
}
