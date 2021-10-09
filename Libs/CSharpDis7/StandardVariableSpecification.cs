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
    /// Does not work, and causes failure in anything it is embedded in. Section 6.2.82
    /// </summary>
    [Serializable]
    [XmlRoot]
    [XmlInclude(typeof(SimulationManagementPduHeader))]
    public partial class StandardVariableSpecification
    {
        /// <summary>
        /// Number of static variable records
        /// </summary>
        private ushort _numberOfStandardVariableRecords;

        /// <summary>
        /// variable length list of standard variables, The class type and length here are WRONG and will cause the incorrect serialization of any class in whihc it is embedded.
        /// </summary>
        private List<SimulationManagementPduHeader> _standardVariables = new List<SimulationManagementPduHeader>();

        /// <summary>
        /// Initializes a new instance of the <see cref="StandardVariableSpecification"/> class.
        /// </summary>
        public StandardVariableSpecification()
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
        public static bool operator !=(StandardVariableSpecification left, StandardVariableSpecification right)
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
        public static bool operator ==(StandardVariableSpecification left, StandardVariableSpecification right)
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

            marshalSize += 2;  // this._numberOfStandardVariableRecords
            for (int idx = 0; idx < this._standardVariables.Count; idx++)
            {
                SimulationManagementPduHeader listElement = (SimulationManagementPduHeader)this._standardVariables[idx];
                marshalSize += listElement.GetMarshalledSize();
            }

            return marshalSize;
        }

        /// <summary>
        /// Note that setting this value will not change the marshalled value. The list whose length this describes is used for that purpose.
        /// The getnumberOfStandardVariableRecords method will also be based on the actual list length rather than this value. 
        /// The method is simply here for completeness and should not be used for any computations.
        /// </summary>
        [XmlElement(Type = typeof(ushort), ElementName = "numberOfStandardVariableRecords")]
        public ushort NumberOfStandardVariableRecords
        {
            get
            {
                return this._numberOfStandardVariableRecords;
            }

            set
            {
                this._numberOfStandardVariableRecords = value;
            }
        }

        /// <summary>
        /// Gets or sets the variable length list of standard variables, The class type and length here are WRONG and will cause the incorrect serialization of any class in whihc it is embedded.
        /// </summary>
        [XmlElement(ElementName = "standardVariablesList", Type = typeof(List<SimulationManagementPduHeader>))]
        public List<SimulationManagementPduHeader> StandardVariables
        {
            get
            {
                return this._standardVariables;
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
                    dos.WriteUnsignedShort((ushort)this._standardVariables.Count);

                    for (int idx = 0; idx < this._standardVariables.Count; idx++)
                    {
                        SimulationManagementPduHeader aSimulationManagementPduHeader = (SimulationManagementPduHeader)this._standardVariables[idx];
                        aSimulationManagementPduHeader.Marshal(dos);
                    }
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
                    this._numberOfStandardVariableRecords = dis.ReadUnsignedShort();
                    for (int idx = 0; idx < this.NumberOfStandardVariableRecords; idx++)
                    {
                        SimulationManagementPduHeader anX = new SimulationManagementPduHeader();
                        anX.Unmarshal(dis);
                        this._standardVariables.Add(anX);
                    };

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
            sb.AppendLine("<StandardVariableSpecification>");
            try
            {
                sb.AppendLine("<standardVariables type=\"ushort\">" + this._standardVariables.Count.ToString(CultureInfo.InvariantCulture) + "</standardVariables>");
                for (int idx = 0; idx < this._standardVariables.Count; idx++)
                {
                    sb.AppendLine("<standardVariables" + idx.ToString(CultureInfo.InvariantCulture) + " type=\"SimulationManagementPduHeader\">");
                    SimulationManagementPduHeader aSimulationManagementPduHeader = (SimulationManagementPduHeader)this._standardVariables[idx];
                    aSimulationManagementPduHeader.Reflection(sb);
                    sb.AppendLine("</standardVariables" + idx.ToString(CultureInfo.InvariantCulture) + ">");
                }

                sb.AppendLine("</StandardVariableSpecification>");
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
            return this == obj as StandardVariableSpecification;
        }

        /// <summary>
        /// Compares for reference AND value equality.
        /// </summary>
        /// <param name="obj">The object to compare with this instance.</param>
        /// <returns>
        /// 	<c>true</c> if both operands are equal; otherwise, <c>false</c>.
        /// </returns>
        public bool Equals(StandardVariableSpecification obj)
        {
            bool ivarsEqual = true;

            if (obj.GetType() != this.GetType())
            {
                return false;
            }

            if (this._numberOfStandardVariableRecords != obj._numberOfStandardVariableRecords)
            {
                ivarsEqual = false;
            }

            if (this._standardVariables.Count != obj._standardVariables.Count)
            {
                ivarsEqual = false;
            }

            if (ivarsEqual)
            {
                for (int idx = 0; idx < this._standardVariables.Count; idx++)
                {
                    if (!this._standardVariables[idx].Equals(obj._standardVariables[idx]))
                    {
                        ivarsEqual = false;
                    }
                }
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

            result = GenerateHash(result) ^ this._numberOfStandardVariableRecords.GetHashCode();

            if (this._standardVariables.Count > 0)
            {
                for (int idx = 0; idx < this._standardVariables.Count; idx++)
                {
                    result = GenerateHash(result) ^ this._standardVariables[idx].GetHashCode();
                }
            }

            return result;
        }
    }
}
