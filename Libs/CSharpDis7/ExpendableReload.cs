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
    /// An entity's expendable (chaff, flares, etc) information. Section 6.2.37
    /// </summary>
    [Serializable]
    [XmlRoot]
    [XmlInclude(typeof(EntityType))]
    public partial class ExpendableReload
    {
        /// <summary>
        /// Type of expendable
        /// </summary>
        private EntityType _expendable = new EntityType();

        private uint _station;

        private ushort _standardQuantity;

        private ushort _maximumQuantity;

        private uint _standardQuantityReloadTime;

        private uint _maximumQuantityReloadTime;

        /// <summary>
        /// Initializes a new instance of the <see cref="ExpendableReload"/> class.
        /// </summary>
        public ExpendableReload()
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
        public static bool operator !=(ExpendableReload left, ExpendableReload right)
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
        public static bool operator ==(ExpendableReload left, ExpendableReload right)
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

            marshalSize += this._expendable.GetMarshalledSize();  // this._expendable
            marshalSize += 4;  // this._station
            marshalSize += 2;  // this._standardQuantity
            marshalSize += 2;  // this._maximumQuantity
            marshalSize += 4;  // this._standardQuantityReloadTime
            marshalSize += 4;  // this._maximumQuantityReloadTime
            return marshalSize;
        }

        /// <summary>
        /// Gets or sets the Type of expendable
        /// </summary>
        [XmlElement(Type = typeof(EntityType), ElementName = "expendable")]
        public EntityType Expendable
        {
            get
            {
                return this._expendable;
            }

            set
            {
                this._expendable = value;
            }
        }

        [XmlElement(Type = typeof(uint), ElementName = "station")]
        public uint Station
        {
            get
            {
                return this._station;
            }

            set
            {
                this._station = value;
            }
        }

        [XmlElement(Type = typeof(ushort), ElementName = "standardQuantity")]
        public ushort StandardQuantity
        {
            get
            {
                return this._standardQuantity;
            }

            set
            {
                this._standardQuantity = value;
            }
        }

        [XmlElement(Type = typeof(ushort), ElementName = "maximumQuantity")]
        public ushort MaximumQuantity
        {
            get
            {
                return this._maximumQuantity;
            }

            set
            {
                this._maximumQuantity = value;
            }
        }

        [XmlElement(Type = typeof(uint), ElementName = "standardQuantityReloadTime")]
        public uint StandardQuantityReloadTime
        {
            get
            {
                return this._standardQuantityReloadTime;
            }

            set
            {
                this._standardQuantityReloadTime = value;
            }
        }

        [XmlElement(Type = typeof(uint), ElementName = "maximumQuantityReloadTime")]
        public uint MaximumQuantityReloadTime
        {
            get
            {
                return this._maximumQuantityReloadTime;
            }

            set
            {
                this._maximumQuantityReloadTime = value;
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
                    this._expendable.Marshal(dos);
                    dos.WriteUnsignedInt((uint)this._station);
                    dos.WriteUnsignedShort((ushort)this._standardQuantity);
                    dos.WriteUnsignedShort((ushort)this._maximumQuantity);
                    dos.WriteUnsignedInt((uint)this._standardQuantityReloadTime);
                    dos.WriteUnsignedInt((uint)this._maximumQuantityReloadTime);
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
                    this._expendable.Unmarshal(dis);
                    this._station = dis.ReadUnsignedInt();
                    this._standardQuantity = dis.ReadUnsignedShort();
                    this._maximumQuantity = dis.ReadUnsignedShort();
                    this._standardQuantityReloadTime = dis.ReadUnsignedInt();
                    this._maximumQuantityReloadTime = dis.ReadUnsignedInt();
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
            sb.AppendLine("<ExpendableReload>");
            try
            {
                sb.AppendLine("<expendable>");
                this._expendable.Reflection(sb);
                sb.AppendLine("</expendable>");
                sb.AppendLine("<station type=\"uint\">" + this._station.ToString(CultureInfo.InvariantCulture) + "</station>");
                sb.AppendLine("<standardQuantity type=\"ushort\">" + this._standardQuantity.ToString(CultureInfo.InvariantCulture) + "</standardQuantity>");
                sb.AppendLine("<maximumQuantity type=\"ushort\">" + this._maximumQuantity.ToString(CultureInfo.InvariantCulture) + "</maximumQuantity>");
                sb.AppendLine("<standardQuantityReloadTime type=\"uint\">" + this._standardQuantityReloadTime.ToString(CultureInfo.InvariantCulture) + "</standardQuantityReloadTime>");
                sb.AppendLine("<maximumQuantityReloadTime type=\"uint\">" + this._maximumQuantityReloadTime.ToString(CultureInfo.InvariantCulture) + "</maximumQuantityReloadTime>");
                sb.AppendLine("</ExpendableReload>");
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
            return this == obj as ExpendableReload;
        }

        /// <summary>
        /// Compares for reference AND value equality.
        /// </summary>
        /// <param name="obj">The object to compare with this instance.</param>
        /// <returns>
        /// 	<c>true</c> if both operands are equal; otherwise, <c>false</c>.
        /// </returns>
        public bool Equals(ExpendableReload obj)
        {
            bool ivarsEqual = true;

            if (obj.GetType() != this.GetType())
            {
                return false;
            }

            if (!this._expendable.Equals(obj._expendable))
            {
                ivarsEqual = false;
            }

            if (this._station != obj._station)
            {
                ivarsEqual = false;
            }

            if (this._standardQuantity != obj._standardQuantity)
            {
                ivarsEqual = false;
            }

            if (this._maximumQuantity != obj._maximumQuantity)
            {
                ivarsEqual = false;
            }

            if (this._standardQuantityReloadTime != obj._standardQuantityReloadTime)
            {
                ivarsEqual = false;
            }

            if (this._maximumQuantityReloadTime != obj._maximumQuantityReloadTime)
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

            result = GenerateHash(result) ^ this._expendable.GetHashCode();
            result = GenerateHash(result) ^ this._station.GetHashCode();
            result = GenerateHash(result) ^ this._standardQuantity.GetHashCode();
            result = GenerateHash(result) ^ this._maximumQuantity.GetHashCode();
            result = GenerateHash(result) ^ this._standardQuantityReloadTime.GetHashCode();
            result = GenerateHash(result) ^ this._maximumQuantityReloadTime.GetHashCode();

            return result;
        }
    }
}
