using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using ReBus.Model;

namespace ReBus.WebServices.WebServiceModel
{
    [DataContract]
    public class TicketWebServiceModel
    {
        [DataMember]
        public Guid GUID { get; set; }

        [DataMember]
        public DateTime Created { get; set; }

        [DataMember]
        public AccountWebServiceModel Account { get; set; }

        [DataMember]
        public BusWebServiceModel Bus { get; set; }

        public TicketWebServiceModel FromDataModel(Ticket ticket)
        {
            return FromDataModel(ticket, AccountWebServiceModel.FromModelObject(ticket == null ? null : ticket.Account));
        }

        private TicketWebServiceModel FromDataModel(Ticket ticket, AccountWebServiceModel accountWebServiceModel)
        {
            if (ticket == null)
                return null;

            return new TicketWebServiceModel
            {
                Account = accountWebServiceModel,
                Created = ticket.Created,
                GUID = ticket.GUID,
                Bus = BusWebServiceModel.FromDataModel(ticket.Bus)
            };
        }

    }
}