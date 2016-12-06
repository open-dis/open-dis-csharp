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
    /// An entity's sensor information.  Section 6.2.77.
    /// </summary>
    [Serializable]
    [XmlRoot]
    public partial class Sensor
    {
        /// <summary>
        ///  the source of the Sensor Type field 
        /// </summary>
        private byte _sensorTypeSource;

        /// <summary>
        /// the on/off status of the sensor
        /// </summary>
        private byte _sensorOnOffStatus;

        /// <summary>
        /// the sensor type and shall be represented by a 16-bit enumeration. 
        /// </summary>
        private ushort _sensorType;

        /// <summary>
        ///  the station to which the sensor is assigned. A zero value shall indi- cate that this Sensor record is not associated with any particular station and represents the total quan- tity of this sensor for this entity. If this field is non-zero, it shall either reference an attached part or an articulated part
        /// </summary>
        private uint _station;

        /// <summary>
        /// quantity of the sensor 
        /// </summary>
        private ushort _quantity;

        /// <summary>
        /// padding
        /// </summary>
        private ushort _padding;

        /// <summary>
        /// Initializes a new instance of the <see cref="Sensor"/> class.
        /// </summary>
        public Sensor()
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
        public static bool operator !=(Sensor left, Sensor right)
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
        public static bool operator ==(Sensor left, Sensor right)
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

            marshalSize += 1;  // this._sensorTypeSource
            marshalSize += 1;  // this._sensorOnOffStatus
            marshalSize += 2;  // this._sensorType
            marshalSize += 4;  // this._station
            marshalSize += 2;  // this._quantity
            marshalSize += 2;  // this._padding
            return marshalSize;
        }

        /// <summary>
        /// Gets or sets the  the source of the Sensor Type field 
        /// </summary>
        [XmlElement(Type = typeof(byte), ElementName = "sensorTypeSource")]
        public byte SensorTypeSource
        {
            get
            {
                return this._sensorTypeSource;
            }

            set
            {
                this._sensorTypeSource = value;
            }
        }

        /// <summary>
        /// Gets or sets the the on/off status of the sensor
        /// </summary>
        [XmlElement(Type = typeof(byte), ElementName = "sensorOnOffStatus")]
        public byte SensorOnOffStatus
        {
            get
            {
                return this._sensorOnOffStatus;
            }

            set
            {
                this._sensorOnOffStatus = value;
            }
        }

        /// <summary>
        /// Gets or sets the the sensor type and shall be represented by a 16-bit enumeration. 
        /// </summary>
        [XmlElement(Type = typeof(ushort), ElementName = "sensorType")]
        public ushort SensorType
        {
            get
            {
                return this._sensorType;
            }

            set
            {
                this._sensorType = value;
            }
        }

        /// <summary>
        /// Gets or sets the  the station to which the sensor is assigned. A zero value shall indi- cate that this Sensor record is not associated with any particular station and represents the total quan- tity of this sensor for this entity. If this field is non-zero, it shall either reference an attached part or an articulated part
        /// </summary>
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

        /// <summary>
        /// Gets or sets the quantity of the sensor 
        /// </summary>
        [XmlElement(Type = typeof(ushort), ElementName = "quantity")]
        public ushort Quantity
        {
            get
            {
                return this._quantity;
            }

            set
            {
                this._quantity = value;
            }
        }

        /// <summary>
        /// Gets or sets the padding
        /// </summary>
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
                    dos.WriteUnsignedByte((byte)this._sensorTypeSource);
                    dos.WriteUnsignedByte((byte)this._sensorOnOffStatus);
                    dos.WriteUnsignedShort((ushort)this._sensorType);
                    dos.WriteUnsignedInt((uint)this._station);
                    dos.WriteUnsignedShort((ushort)this._quantity);
                    dos.WriteUnsignedShort((ushort)this._padding);
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
                    this._sensorTypeSource = dis.ReadUnsignedByte();
                    this._sensorOnOffStatus = dis.ReadUnsignedByte();
                    this._sensorType = dis.ReadUnsignedShort();
                    this._station = dis.ReadUnsignedInt();
                    this._quantity = dis.ReadUnsignedShort();
                    this._padding = dis.ReadUnsignedShort();
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
            sb.AppendLine("<Sensor>");
            try
            {
                sb.AppendLine("<sensorTypeSource type=\"byte\">" + this._sensorTypeSource.ToString(CultureInfo.InvariantCulture) + "</sensorTypeSource>");
                sb.AppendLine("<sensorOnOffStatus type=\"byte\">" + this._sensorOnOffStatus.ToString(CultureInfo.InvariantCulture) + "</sensorOnOffStatus>");
                sb.AppendLine("<sensorType type=\"ushort\">" + this._sensorType.ToString(CultureInfo.InvariantCulture) + "</sensorType>");
                sb.AppendLine("<station type=\"uint\">" + this._station.ToString(CultureInfo.InvariantCulture) + "</station>");
                sb.AppendLine("<quantity type=\"ushort\">" + this._quantity.ToString(CultureInfo.InvariantCulture) + "</quantity>");
                sb.AppendLine("<padding type=\"ushort\">" + this._padding.ToString(CultureInfo.InvariantCulture) + "</padding>");
                sb.AppendLine("</Sensor>");
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
            return this == obj as Sensor;
        }

        /// <summary>
        /// Compares for reference AND value equality.
        /// </summary>
        /// <param name="obj">The object to compare with this instance.</param>
        /// <returns>
        /// 	<c>true</c> if both operands are equal; otherwise, <c>false</c>.
        /// </returns>
        public bool Equals(Sensor obj)
        {
            bool ivarsEqual = true;

            if (obj.GetType() != this.GetType())
            {
                return false;
            }

            if (this._sensorTypeSource != obj._sensorTypeSource)
            {
                ivarsEqual = false;
            }

            if (this._sensorOnOffStatus != obj._sensorOnOffStatus)
            {
                ivarsEqual = false;
            }

            if (this._sensorType != obj._sensorType)
            {
                ivarsEqual = false;
            }

            if (this._station != obj._station)
            {
                ivarsEqual = false;
            }

            if (this._quantity != obj._quantity)
            {
                ivarsEqual = false;
            }

            if (this._padding != obj._padding)
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

            result = GenerateHash(result) ^ this._sensorTypeSource.GetHashCode();
            result = GenerateHash(result) ^ this._sensorOnOffStatus.GetHashCode();
            result = GenerateHash(result) ^ this._sensorType.GetHashCode();
            result = GenerateHash(result) ^ this._station.GetHashCode();
            result = GenerateHash(result) ^ this._quantity.GetHashCode();
            result = GenerateHash(result) ^ this._padding.GetHashCode();

            return result;
        }
    }
}
