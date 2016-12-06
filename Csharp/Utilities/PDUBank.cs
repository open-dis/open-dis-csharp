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
using DIS1998net;

namespace DISnet.Utilities
{
    /* Author Peter Smith (Naval Air Warfare Center - Training Systems Division) 01/23/2009
* Modifications: none
* Notes:
*/

    public class PDUBank
    {
        static public DIS1998net.Pdu GetPDU(uint pdu_type)
        {
            DISnet.Utilities.PDUTypes.PDUType1998 enumType = (PDUTypes.PDUType1998)pdu_type;
            return GetPDU(enumType);
        }

        static public DIS1998net.Pdu GetPDU(DISnet.Utilities.PDUTypes.PDUType1998 pdu_type)
        {
            DIS1998net.Pdu pdu = null;

            switch (pdu_type)
            {

                case PDUTypes.PDUType1998.PDU_ENTITY_STATE: pdu =  new EntityStatePdu(); break;
                case PDUTypes.PDUType1998.PDU_FIRE: pdu = new FirePdu(); break;
                case PDUTypes.PDUType1998.PDU_DETONATION: pdu = new DetonationPdu(); break;
                case PDUTypes.PDUType1998.PDU_COLLISION: pdu = new CollisionPdu(); break;
                case PDUTypes.PDUType1998.PDU_SERVICE_REQUEST: pdu = new ServiceRequestPdu(); break;
                case PDUTypes.PDUType1998.PDU_RESUPPLY_OFFER: pdu = new ResupplyOfferPdu(); break;
                case PDUTypes.PDUType1998.PDU_RESUPPLY_RECEIVED: pdu = new ResupplyReceivedPdu(); break;
                case PDUTypes.PDUType1998.PDU_RESUPPLY_CANCEL: pdu = new ResupplyCancelPdu(); break;
                case PDUTypes.PDUType1998.PDU_REPAIR_COMPLETE: pdu = new RepairCompletePdu(); break;
                case PDUTypes.PDUType1998.PDU_REPAIR_RESPONSE: pdu = new RepairResponsePdu(); break;
                case PDUTypes.PDUType1998.PDU_CREATE_ENTITY: pdu = new CreateEntityPdu(); break;
                case PDUTypes.PDUType1998.PDU_REMOVE_ENTITY: pdu = new RemoveEntityPdu(); break;
                case PDUTypes.PDUType1998.PDU_START_RESUME: pdu = new StartResumePdu(); break;
                case PDUTypes.PDUType1998.PDU_ACKNOWLEDGE: pdu = new AcknowledgePdu(); break;
                case PDUTypes.PDUType1998.PDU_ACTION_REQUEST: pdu = new ActionRequestPdu(); break;
                case PDUTypes.PDUType1998.PDU_ACTION_RESPONSE: pdu = new ActionResponsePdu(); break;
                case PDUTypes.PDUType1998.PDU_DATA_QUERY: pdu = new DataQueryPdu(); break;
                case PDUTypes.PDUType1998.PDU_SET_DATA: pdu = new SetDataPdu(); break;
                case PDUTypes.PDUType1998.PDU_EVENT_REPORT: pdu = new EventReportPdu(); break;
                case PDUTypes.PDUType1998.PDU_COMMENT: pdu = new CommentPdu(); break;
                case PDUTypes.PDUType1998.PDU_STOP_FREEZE: pdu = new StopFreezePdu(); break;
                case PDUTypes.PDUType1998.PDU_SIGNAL: pdu = new SignalPdu(); break;
                case PDUTypes.PDUType1998.PDU_TRANSMITTER: pdu = new TransmitterPdu(); break;
            }

            return pdu;
        }
    }
}
