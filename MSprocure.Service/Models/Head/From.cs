using System.Xml.Serialization;

namespace MSprocure.Service.Models.Head {
#pragma warning disable IDE1006 // Ignore Naming Rule Violations for cXml
    [XmlRoot("From")]
    public class From {
        [XmlElement("Credential")]
        public Credential[] Credential { get; set; }
    }
#pragma warning restore IDE1006
}