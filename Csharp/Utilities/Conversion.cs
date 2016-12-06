// Copyright (c) 1995-2009 held by the author(s).  All rights reserved.
// Redistribution and use in source and binary forms, with or without
// modification, are permitted provided that the following conditions
//  are met:
// 
//  * Redistributions of source code must retain the above copyright
// notice, this list of conditions and the following disclaimer.
// * Redistributions in binary form must reproduce the above copyright
// notice, this list of conditions and the following disclaimer
// in the documentation and/or other materials provided with the
// distribution.
// * Neither the names of the Naval Postgraduate School (NPS)
//  Modeling Virtual Environments and Simulation (MOVES) Institute
// (http://www.nps.edu and http://www.MovesInstitute.org)
// nor the names of its contributors may be used to endorse or
//  promote products derived from this software without specific
// prior written permission.
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

using System;
using System.Collections.Generic;
using System.Text;


namespace DISnet.Utilities
{
  /* Author Peter Smith (Naval Air Warfare Center - Training Systems Division) 01/23/2009
  * Modifications: none
  * Notes:
  */
   
    public static class Conversion
    {

         /// the mask that will leave only the typemetric
         /// from an integer representing the Articulation Parameter's parameter type.
         /// this mask is based on the IEEE Std 1278.1-1995
        const int ARTICULATION_PARAMETER_TYPE_METRIC_MASK = 0x001F;

        /// the number of bits used to store the type metric value
        /// within the Articulation Parameter's parameter type value.
        /// this mask is based on the IEEE Std 1278.1-1995
        const byte ARTICULATION_PARAMETER_TYPE_METRIC_NUMBER_OF_BITS = 5;

        /// make the value needed for the ArticulationParameter's Parameter Type.
        /// @param typeclass the enumeration for the articulated part.
        /// This must have less precision than ARTICULATION_PARAMETER_TYPE_METRIC_NUMBER_OF_BITS.
        /// @param typemetric the enumeration for the motion description.
        /// this must have less precision than 32 - ARTICULATION_PARAMETER_TYPE_METRIC_NUMBER_OF_BITS.
        /// @return the value to be used as the Parameter Type, with 32 bits precision.

        public static uint MakeArticulationParameterType(uint typeclass, uint typemetric)
        {
            // enforce a ceiling on typemetric
            typemetric = typemetric & ARTICULATION_PARAMETER_TYPE_METRIC_MASK;

            // shift the typeclass bits to the left by the precision amount of typemetric
            // and then add the typemetric bits
            return ((typeclass << ARTICULATION_PARAMETER_TYPE_METRIC_NUMBER_OF_BITS)
                   + typemetric);
        }

        /// extract the data for the type metric value stored within the parameter type value.
        /// this an inverse to the function, MakeArticulationParameterType.
        /// @param parametertype the value storing the type metric and type class values.
        /// @return the type metric value, with ARTICULATION_PARAMETER_TYPE_METRIC_NUMBER_OF_BITS bits precision.
        public static int GetArticulationTypeMetric(int parametertype)
        {
            // wipe off the typeclass bits and return the typemetric bits
            return (parametertype & ARTICULATION_PARAMETER_TYPE_METRIC_MASK);
        }

        /// extract the data for the type class value stored within the parameter type value.
        /// this an inverse to the function, MakeArticulationParameterType.
        /// @param parametertype the value storing the type metric and type class values.
        /// @return the type class value, with ARTICULATION_PARAMETER_TYPE_METRIC_NUMBER_OF_BITS bits precision
        public static int GetArticulationTypeClass(int parametertype)
        {
            // wipe off the typemetric bits and return the typeclass bits
            return (parametertype >> ARTICULATION_PARAMETER_TYPE_METRIC_NUMBER_OF_BITS);
        }
    }
}
