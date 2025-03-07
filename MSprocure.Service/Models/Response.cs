using System.Xml.Serialization;
using MSprocure.Service.Models.Content;

namespace MSprocure.Service.Models
{
#pragma warning disable IDE1006 // Ignore Naming Rule Violations for cXml
    [XmlRoot("Response")]
    public class Response : Body {
        [XmlElement("Status")]
        public Status Status { get; set; }

        public bool ShouldSerializeStatus() {
            return !string.IsNullOrEmpty(Status?.code);
        }
    }
#pragma warning restore IDE1006
}