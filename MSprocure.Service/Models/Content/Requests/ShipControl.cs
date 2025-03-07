using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MSprocure.Service.Models.Content.Requests
{
#pragma warning disable IDE1006 // Ignore Naming Rule Violations for cXml
    [XmlRoot("ShipNoticeRequest")]
    public class ShipControl
    {

        [XmlElement("CarrierIdentifier")]
        public CarrierIdentifier[] CarrierIdentifier { get; set; }


        [XmlElement("ShipmentIdentifier")]
        public string ShipmentIdentifier { get; set; }

    }
#pragma warning restore IDE1006
}

