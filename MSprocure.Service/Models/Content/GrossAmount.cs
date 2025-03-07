using System.Xml.Serialization;

namespace MSprocure.Service.Models.Content {
#pragma warning disable IDE1006 // Ignore Naming Rule Violations for cXml
    [XmlRoot("GrossAmount")]
    public class GrossAmount {
        [XmlElement("Money")]
        public Money Money { get; set; }
    }
#pragma warning restore IDE1006
}