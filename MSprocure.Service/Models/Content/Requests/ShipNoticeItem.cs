using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MSprocure.Service.Models.Content.Requests
{
#pragma warning disable IDE1006 // Ignore Naming Rule Violations for cXml
    [XmlRoot("ShipNoticeItem")]
    public class ShipNoticeItem
    {
        [XmlAttribute("lineNumber")]
        public string lineNumber { get; set; }

        [XmlAttribute("quantity")]
        public string quantity { get; set; }

        [XmlElement("UnitOfMeasure")]
        public string UnitOfMeasure { get; set; }
    }
#pragma warning restore IDE1006
}
