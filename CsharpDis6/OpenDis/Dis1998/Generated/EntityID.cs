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
    /// Each entity in a given DIS simulation application shall be given an entity identifier number unique to all other
    /// entities in that application. This identifier number is valid for the duration of the exercise; however, entity identifier numbers may be reused when all possible numbers have been exhausted. No entity shall  have an entity identifier number of NO_ENTITY, ALL_ENTITIES, or RQST_ASSIGN_ID. The entity iden-  tifier number need not be registered or retained for future exercises. The entity identifier number shall be  specified by a 16-bit unsigned integer.  An entity identifier number equal to zero with valid site and application identification shall address a  simulation application. An entity identifier number equal to ALL_ENTITIES shall mean all entities within  the specified site and application. An entity identifier number equal to RQST_ASSIGN_ID allows the  receiver of the create entity to define the entity identifier number of the new entity.
    /// </summary>
    [Serializable]
    [XmlRoot]
    public partial class EntityID : IEquatable<EntityID>, IReflectable
    {
        /// <summary>
        /// The site ID
        /// </summary>
        private ushort _site;

        /// <summary>
        /// The application ID
        /// </summary>
        private ushort _application;

        /// <summary>
        /// the entity ID
        /// </summary>
        private ushort _entity;

        /// <summary>
        /// Initializes a new instance of the <see cref="EntityID"/> class.
        /// </summary>
        public EntityID()
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
        public static bool operator !=(EntityID left, EntityID right) => !(left == right);

        /// <summary>
        /// Implements the operator ==.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>
        ///    <c>true</c> if both operands are equal; otherwise, <c>false</c>.
        /// </returns>
        public static bool operator ==(EntityID left, EntityID right)
            => ReferenceEquals(left, right) || (left is not null && right is not null && left.Equals(right));

        public virtual int GetMarshalledSize()
        {
            int marshalSize = 0;

            marshalSize += 2;  // this._site
            marshalSize += 2;  // this._application
            marshalSize += 2;  // this._entity
            return marshalSize;
        }

        /// <summary>
        /// Gets or sets the site ID
        /// </summary>
        [XmlElement(Type = typeof(ushort), ElementName = "site")]
        public ushort Site
        {
            get => _site;

            set => _site = value;
        }

        /// <summary>
        /// Gets or sets the application ID
        /// </summary>
        [XmlElement(Type = typeof(ushort), ElementName = "application")]
        public ushort Application
        {
            get => _application;

            set => _application = value;
        }

        /// <summary>
        /// Gets or sets the entity ID
        /// </summary>
        [XmlElement(Type = typeof(ushort), ElementName = "entity")]
        public ushort Entity
        {
            get => _entity;

            set => _entity = value;
        }

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
                    dos.WriteUnsignedShort(_site);
                    dos.WriteUnsignedShort(_application);
                    dos.WriteUnsignedShort(_entity);
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
                    _site = dis.ReadUnsignedShort();
                    _application = dis.ReadUnsignedShort();
                    _entity = dis.ReadUnsignedShort();
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
            sb.AppendLine("<EntityID>");
            try
            {
                sb.AppendLine("<site type=\"ushort\">" + _site.ToString(CultureInfo.InvariantCulture) + "</site>");
                sb.AppendLine("<application type=\"ushort\">" + _application.ToString(CultureInfo.InvariantCulture) + "</application>");
                sb.AppendLine("<entity type=\"ushort\">" + _entity.ToString(CultureInfo.InvariantCulture) + "</entity>");
                sb.AppendLine("</EntityID>");
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
        public override bool Equals(object obj) => this == obj as EntityID;

        ///<inheritdoc/>
        public bool Equals(EntityID obj)
        {
            bool ivarsEqual = true;

            if (obj.GetType() != GetType())
            {
                return false;
            }

            if (_site != obj._site)
            {
                ivarsEqual = false;
            }

            if (_application != obj._application)
            {
                ivarsEqual = false;
            }

            if (_entity != obj._entity)
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

            result = GenerateHash(result) ^ _site.GetHashCode();
            result = GenerateHash(result) ^ _application.GetHashCode();
            result = GenerateHash(result) ^ _entity.GetHashCode();

            return result;
        }
    }
}
