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
    /// Identity of a communications node. Section 6.2.51
    /// </summary>
    [Serializable]
    [XmlRoot]
    [XmlInclude(typeof(EventIdentifier))]
    [XmlInclude(typeof(Vector3Double))]
    public partial class LaunchedMunitionRecord
    {
        private EventIdentifier _fireEventID = new EventIdentifier();

        private ushort _padding;

        private EventIdentifier _firingEntityID = new EventIdentifier();

        private ushort _padding2;

        private EventIdentifier _targetEntityID = new EventIdentifier();

        private ushort _padding3;

        private Vector3Double _targetLocation = new Vector3Double();

        /// <summary>
        /// Initializes a new instance of the <see cref="LaunchedMunitionRecord"/> class.
        /// </summary>
        public LaunchedMunitionRecord()
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
        public static bool operator !=(LaunchedMunitionRecord left, LaunchedMunitionRecord right)
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
        public static bool operator ==(LaunchedMunitionRecord left, LaunchedMunitionRecord right)
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

            marshalSize += this._fireEventID.GetMarshalledSize();  // this._fireEventID
            marshalSize += 2;  // this._padding
            marshalSize += this._firingEntityID.GetMarshalledSize();  // this._firingEntityID
            marshalSize += 2;  // this._padding2
            marshalSize += this._targetEntityID.GetMarshalledSize();  // this._targetEntityID
            marshalSize += 2;  // this._padding3
            marshalSize += this._targetLocation.GetMarshalledSize();  // this._targetLocation
            return marshalSize;
        }

        [XmlElement(Type = typeof(EventIdentifier), ElementName = "fireEventID")]
        public EventIdentifier FireEventID
        {
            get
            {
                return this._fireEventID;
            }

            set
            {
                this._fireEventID = value;
            }
        }

        [XmlElement(Type = typeof(ushort), ElementName = "padding")]
        public ushort Padding
        {
            get
            {
                return this._padding;
            }

            set
            {
                this._padding = value;
            }
        }

        [XmlElement(Type = typeof(EventIdentifier), ElementName = "firingEntityID")]
        public EventIdentifier FiringEntityID
        {
            get
            {
                return this._firingEntityID;
            }

            set
            {
                this._firingEntityID = value;
            }
        }

        [XmlElement(Type = typeof(ushort), ElementName = "padding2")]
        public ushort Padding2
        {
            get
            {
                return this._padding2;
            }

            set
            {
                this._padding2 = value;
            }
        }

        [XmlElement(Type = typeof(EventIdentifier), ElementName = "targetEntityID")]
        public EventIdentifier TargetEntityID
        {
            get
            {
                return this._targetEntityID;
            }

            set
            {
                this._targetEntityID = value;
            }
        }

        [XmlElement(Type = typeof(ushort), ElementName = "padding3")]
        public ushort Padding3
        {
            get
            {
                return this._padding3;
            }

            set
            {
                this._padding3 = value;
            }
        }

        [XmlElement(Type = typeof(Vector3Double), ElementName = "targetLocation")]
        public Vector3Double TargetLocation
        {
            get
            {
                return this._targetLocation;
            }

            set
            {
                this._targetLocation = value;
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
                    this._fireEventID.Marshal(dos);
                    dos.WriteUnsignedShort((ushort)this._padding);
                    this._firingEntityID.Marshal(dos);
                    dos.WriteUnsignedShort((ushort)this._padding2);
                    this._targetEntityID.Marshal(dos);
                    dos.WriteUnsignedShort((ushort)this._padding3);
                    this._targetLocation.Marshal(dos);
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
                    this._fireEventID.Unmarshal(dis);
                    this._padding = dis.ReadUnsignedShort();
                    this._firingEntityID.Unmarshal(dis);
                    this._padding2 = dis.ReadUnsignedShort();
                    this._targetEntityID.Unmarshal(dis);
                    this._padding3 = dis.ReadUnsignedShort();
                    this._targetLocation.Unmarshal(dis);
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
            sb.AppendLine("<LaunchedMunitionRecord>");
            try
            {
                sb.AppendLine("<fireEventID>");
                this._fireEventID.Reflection(sb);
                sb.AppendLine("</fireEventID>");
                sb.AppendLine("<padding type=\"ushort\">" + this._padding.ToString(CultureInfo.InvariantCulture) + "</padding>");
                sb.AppendLine("<firingEntityID>");
                this._firingEntityID.Reflection(sb);
                sb.AppendLine("</firingEntityID>");
                sb.AppendLine("<padding2 type=\"ushort\">" + this._padding2.ToString(CultureInfo.InvariantCulture) + "</padding2>");
                sb.AppendLine("<targetEntityID>");
                this._targetEntityID.Reflection(sb);
                sb.AppendLine("</targetEntityID>");
                sb.AppendLine("<padding3 type=\"ushort\">" + this._padding3.ToString(CultureInfo.InvariantCulture) + "</padding3>");
                sb.AppendLine("<targetLocation>");
                this._targetLocation.Reflection(sb);
                sb.AppendLine("</targetLocation>");
                sb.AppendLine("</LaunchedMunitionRecord>");
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
            return this == obj as LaunchedMunitionRecord;
        }

        /// <summary>
        /// Compares for reference AND value equality.
        /// </summary>
        /// <param name="obj">The object to compare with this instance.</param>
        /// <returns>
        /// 	<c>true</c> if both operands are equal; otherwise, <c>false</c>.
        /// </returns>
        public bool Equals(LaunchedMunitionRecord obj)
        {
            bool ivarsEqual = true;

            if (obj.GetType() != this.GetType())
            {
                return false;
            }

            if (!this._fireEventID.Equals(obj._fireEventID))
            {
                ivarsEqual = false;
            }

            if (this._padding != obj._padding)
            {
                ivarsEqual = false;
            }

            if (!this._firingEntityID.Equals(obj._firingEntityID))
            {
                ivarsEqual = false;
            }

            if (this._padding2 != obj._padding2)
            {
                ivarsEqual = false;
            }

            if (!this._targetEntityID.Equals(obj._targetEntityID))
            {
                ivarsEqual = false;
            }

            if (this._padding3 != obj._padding3)
            {
                ivarsEqual = false;
            }

            if (!this._targetLocation.Equals(obj._targetLocation))
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

            result = GenerateHash(result) ^ this._fireEventID.GetHashCode();
            result = GenerateHash(result) ^ this._padding.GetHashCode();
            result = GenerateHash(result) ^ this._firingEntityID.GetHashCode();
            result = GenerateHash(result) ^ this._padding2.GetHashCode();
            result = GenerateHash(result) ^ this._targetEntityID.GetHashCode();
            result = GenerateHash(result) ^ this._padding3.GetHashCode();
            result = GenerateHash(result) ^ this._targetLocation.GetHashCode();

            return result;
        }
    }
}
