using MSprocure.Service.Domain;
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
    public class ShipNoticeRequestBody
    {
        [XmlElement("ShipNoticeHeader")]
        public ShipNoticeHeader ShipNoticeHeader { get; set; }

        [XmlElement("ShipControl")]
        public ShipControl ShipControl { get; set; }

        [XmlElement("ShipNoticePortion")]
        public ShipNoticePortion ShipNoticePortion { get; set; }
    }
#pragma warning restore IDE1006
}
