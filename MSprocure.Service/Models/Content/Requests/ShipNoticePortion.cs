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
    [XmlRoot("ShipNoticePortion")]
    public class ShipNoticePortion
    {
        [XmlElement("OrderReference")]
        public OrderReference OrderReference { get; set; }

        [XmlElement("ShipNoticeItem")]
        public ShipNoticeItem[] ShipNoticeItem { get; set; }

    }
#pragma warning restore IDE1006
}
