using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MSprocure.Service.Models.Content.Requests
{
#pragma warning disable IDE1006 // Ignore Naming Rule Violations for cXml
    [XmlRoot("Request")]
    public class ShipNoticeRequestWrapper: Request
    {
        [XmlAttribute("deploymentMode")]
        public string deploymentMode { get; set; }

        [XmlElement("ShipNoticeRequest")]
        public ShipNoticeRequestBody Body { get; set; }
    }
#pragma warning restore IDE1006
}
