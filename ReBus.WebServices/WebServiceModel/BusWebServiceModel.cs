using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using ReBus.Model;

namespace ReBus.WebServices.WebServiceModel
{
    [DataContract]
    public class BusWebServiceModel
    {
        [DataMember]
        public Guid GUID { get; set; }

        [DataMember]
        public LineWebServiceModel Line { get; set; }

        public static BusWebServiceModel FromDataModel(Bus bus)
        {
            if (bus == null)
                return null;

            return new BusWebServiceModel
            {
                GUID = bus.GUID,
                Line = LineWebServiceModel.FromDataModel(bus.Line)
            };
        }
    }
}