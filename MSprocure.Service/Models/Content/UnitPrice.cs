using System.Xml.Serialization;

namespace MSprocure.Service.Models.Content {
#pragma warning disable IDE1006 // Ignore Naming Rule Violations for cXml
    [XmlRoot("UnitPrice")]
    public class UnitPrice {
        public UnitPrice() {
            Money = new Money();
        }

        public UnitPrice(string currency, decimal value) {
            Money = new Money(currency, value);
        }

        [XmlElement("Money")]
        public Money Money { get; set; }
    }
#pragma warning restore IDE1006
}