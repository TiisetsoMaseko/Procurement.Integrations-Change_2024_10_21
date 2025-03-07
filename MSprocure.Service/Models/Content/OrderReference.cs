using System.Xml.Serialization;

namespace MSprocure.Service.Models.Content {
#pragma warning disable IDE1006 // Ignore Naming Rule Violations for cXml
    [XmlRoot("OrderReference")]
    public class OrderReference {
        [XmlElement("DocumentReference")]
        public DocumentReference DocumentReference { get; set; }
        [XmlAttribute("orderID")]
        public string orderID { get; set; }
    }
#pragma warning restore IDE1006
}