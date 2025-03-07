using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MSprocure.Service.Models.Content.Requests
{
#pragma warning disable IDE1006 // Ignore Naming Rule Violations for cXml
    [XmlRoot("cXML")]
    public class ShipNoticeRequest : cXml
    {
        [XmlElement("Request")]
        public ShipNoticeRequestWrapper Request { get; set; }
    }
#pragma warning restore IDE1006
}
