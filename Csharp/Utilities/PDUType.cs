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

   public class PDUTypes
    {
        public enum PDUType1998
        {
            PDU_OTHER = 0,
            PDU_ENTITY_STATE = 1,
            PDU_FIRE = 2,
            PDU_DETONATION = 3,
            PDU_COLLISION = 4,
            PDU_SERVICE_REQUEST = 5,
            PDU_RESUPPLY_OFFER = 6,
            PDU_RESUPPLY_RECEIVED = 7,
            PDU_RESUPPLY_CANCEL = 8,
            PDU_REPAIR_COMPLETE = 9,
            PDU_REPAIR_RESPONSE = 10,
            PDU_CREATE_ENTITY = 11,
            PDU_REMOVE_ENTITY = 12,
            PDU_START_RESUME = 13,
            PDU_STOP_FREEZE = 14,
            PDU_ACKNOWLEDGE = 15,
            PDU_ACTION_REQUEST = 16,
            PDU_ACTION_RESPONSE = 17,
            PDU_DATA_QUERY = 18,
            PDU_SET_DATA = 19,
            PDU_DATA = 20,
            PDU_EVENT_REPORT = 21,
            PDU_COMMENT = 22,
            PDU_ELECTROMAGNETICEMISSION = 23,
            PDU_DESIGNATOR = 24,
            PDU_TRANSMITTER = 25,
            PDU_SIGNAL = 26,
        };
    }
}
