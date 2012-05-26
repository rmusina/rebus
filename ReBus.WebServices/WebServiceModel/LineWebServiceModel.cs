using System;
using System.Runtime.Serialization;
using ReBus.Model;

namespace ReBus.WebServices.WebServiceModel
{
    [DataContract]
    public class LineWebServiceModel
    {
        [DataMember]
        public Guid GUID { get; set; }

        [DataMember]
        public String Name { get; set; }

        public static LineWebServiceModel FromDataModel(Line line)
        {
            if (line == null)
                return null;

            return new LineWebServiceModel()
            {
                GUID = line.GUID,
                Name = line.Name
            };
        }
    }
}