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
    /// Explosion of a non-munition. Section 6.2.20.3
    /// </summary>
    [Serializable]
    [XmlRoot]
    [XmlInclude(typeof(EntityType))]
    public partial class ExplosionDescriptor
    {
        /// <summary>
        /// Type of the object that exploded. See 6.2.30
        /// </summary>
        private EntityType _explodingObject = new EntityType();

        /// <summary>
        /// Material that exploded. Can be grain dust, tnt, gasoline, etc.
        /// </summary>
        private ushort _explosiveMaterial;

        /// <summary>
        /// padding
        /// </summary>
        private ushort _padding;

        /// <summary>
        /// Force of explosion, in equivalent KG of TNT
        /// </summary>
        private float _explosiveForce;

        /// <summary>
        /// Initializes a new instance of the <see cref="ExplosionDescriptor"/> class.
        /// </summary>
        public ExplosionDescriptor()
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
        public static bool operator !=(ExplosionDescriptor left, ExplosionDescriptor right)
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
        public static bool operator ==(ExplosionDescriptor left, ExplosionDescriptor right)
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

            marshalSize += this._explodingObject.GetMarshalledSize();  // this._explodingObject
            marshalSize += 2;  // this._explosiveMaterial
            marshalSize += 2;  // this._padding
            marshalSize += 4;  // this._explosiveForce
            return marshalSize;
        }

        /// <summary>
        /// Gets or sets the Type of the object that exploded. See 6.2.30
        /// </summary>
        [XmlElement(Type = typeof(EntityType), ElementName = "explodingObject")]
        public EntityType ExplodingObject
        {
            get
            {
                return this._explodingObject;
            }

            set
            {
                this._explodingObject = value;
            }
        }

        /// <summary>
        /// Gets or sets the Material that exploded. Can be grain dust, tnt, gasoline, etc.
        /// </summary>
        [XmlElement(Type = typeof(ushort), ElementName = "explosiveMaterial")]
        public ushort ExplosiveMaterial
        {
            get
            {
                return this._explosiveMaterial;
            }

            set
            {
                this._explosiveMaterial = value;
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
        /// Gets or sets the Force of explosion, in equivalent KG of TNT
        /// </summary>
        [XmlElement(Type = typeof(float), ElementName = "explosiveForce")]
        public float ExplosiveForce
        {
            get
            {
                return this._explosiveForce;
            }

            set
            {
                this._explosiveForce = value;
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
                    this._explodingObject.Marshal(dos);
                    dos.WriteUnsignedShort((ushort)this._explosiveMaterial);
                    dos.WriteUnsignedShort((ushort)this._padding);
                    dos.WriteFloat((float)this._explosiveForce);
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
                    this._explodingObject.Unmarshal(dis);
                    this._explosiveMaterial = dis.ReadUnsignedShort();
                    this._padding = dis.ReadUnsignedShort();
                    this._explosiveForce = dis.ReadFloat();
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
            sb.AppendLine("<ExplosionDescriptor>");
            try
            {
                sb.AppendLine("<explodingObject>");
                this._explodingObject.Reflection(sb);
                sb.AppendLine("</explodingObject>");
                sb.AppendLine("<explosiveMaterial type=\"ushort\">" + this._explosiveMaterial.ToString(CultureInfo.InvariantCulture) + "</explosiveMaterial>");
                sb.AppendLine("<padding type=\"ushort\">" + this._padding.ToString(CultureInfo.InvariantCulture) + "</padding>");
                sb.AppendLine("<explosiveForce type=\"float\">" + this._explosiveForce.ToString(CultureInfo.InvariantCulture) + "</explosiveForce>");
                sb.AppendLine("</ExplosionDescriptor>");
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
            return this == obj as ExplosionDescriptor;
        }

        /// <summary>
        /// Compares for reference AND value equality.
        /// </summary>
        /// <param name="obj">The object to compare with this instance.</param>
        /// <returns>
        /// 	<c>true</c> if both operands are equal; otherwise, <c>false</c>.
        /// </returns>
        public bool Equals(ExplosionDescriptor obj)
        {
            bool ivarsEqual = true;

            if (obj.GetType() != this.GetType())
            {
                return false;
            }

            if (!this._explodingObject.Equals(obj._explodingObject))
            {
                ivarsEqual = false;
            }

            if (this._explosiveMaterial != obj._explosiveMaterial)
            {
                ivarsEqual = false;
            }

            if (this._padding != obj._padding)
            {
                ivarsEqual = false;
            }

            if (this._explosiveForce != obj._explosiveForce)
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

            result = GenerateHash(result) ^ this._explodingObject.GetHashCode();
            result = GenerateHash(result) ^ this._explosiveMaterial.GetHashCode();
            result = GenerateHash(result) ^ this._padding.GetHashCode();
            result = GenerateHash(result) ^ this._explosiveForce.GetHashCode();

            return result;
        }
    }
}
