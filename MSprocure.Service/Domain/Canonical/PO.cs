using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace MSprocure.Service.Domain.Canonical
{
//
    public partial class PO
    {
        [JsonProperty("cXML")]
        public CXml CXml { get; set; }
    }

    public partial class CXml
    {
    [JsonProperty("Header")]
        public Header Header { get; set; }

    [JsonProperty("Request")]
        public Request Request { get; set; }
    }

    public partial class Header
    {
        [JsonProperty("From")]
        public From From { get; set; }

        [JsonProperty("To")]
        public From To { get; set; }

        [JsonProperty("Sender")]
        public Sender Sender { get; set; }
    }

    public partial class From
    {
        [JsonProperty("Credential")]
        public FromCredential Credential { get; set; }
    }

    public partial class FromCredential
    {
        [JsonProperty("Identity")]
        public string Identity { get; set; }

        [JsonProperty("_domain")]
        public string Domain { get; set; }
    }

    public partial class Sender
    {
        [JsonProperty("Credential")]
        public SenderCredential Credential { get; set; }

        [JsonProperty("UserAgent")]
        public string UserAgent { get; set; }
    }

    public partial class SenderCredential
    {
        [JsonProperty("Identity")]
        public string Identity { get; set; }

        [JsonProperty("SharedSecret")]
        public string SharedSecret { get; set; }

        [JsonProperty("_domain")]
        public string Domain { get; set; }
    }

    public partial class Request
        {
            [JsonProperty("OrderRequest")]
            public OrderRequest OrderRequest { get; set; }

            [JsonProperty("_deploymentMode")]
            public string DeploymentMode { get; set; }
        }

        public partial class OrderRequest
        {
            [JsonProperty("OrderRequestHeader")]
            public OrderRequestHeader OrderRequestHeader { get; set; }

            [JsonProperty("ItemOut")]
            public ItemOut ItemOut { get; set; }
        }

        public partial class ItemOut
        {
            [JsonProperty("ItemID")]
            public ItemId ItemId { get; set; }

            [JsonProperty("ItemDetail")]
            public ItemDetail ItemDetail { get; set; }

            [JsonProperty("Distribution")]
            public Distribution Distribution { get; set; }

            [JsonProperty("_quantity")]
            [JsonConverter(typeof(ParseStringConverter))]
            public long Quantity { get; set; }

            [JsonProperty("_lineNumber")]
            [JsonConverter(typeof(ParseStringConverter))]
            public long LineNumber { get; set; }
        }

        public partial class Distribution
        {
            [JsonProperty("Accounting")]
            public Accounting Accounting { get; set; }

            [JsonProperty("Charge")]
            public Total Charge { get; set; }
        }

        public partial class Accounting
        {
            [JsonProperty("Segment")]
            public Segment[] Segment { get; set; }

            [JsonProperty("_name")]
            public string Name { get; set; }
        }

        public partial class Segment
        {
            [JsonProperty("_id")]
            public string Id { get; set; }

            [JsonProperty("_description")]
            public string Description { get; set; }

            [JsonProperty("_type")]
            public string Type { get; set; }
        }

        public partial class Total
        {
            [JsonProperty("Money")]
            public Money Money { get; set; }
        }

        public partial class Money
        {
            [JsonProperty("_currency")]
            public string Currency { get; set; }

            [JsonProperty("__text")]
            public string Text { get; set; }
        }

        public partial class ItemDetail
        {
            [JsonProperty("UnitPrice")]
            public Total UnitPrice { get; set; }

            [JsonProperty("Description")]
            public Description Description { get; set; }

            [JsonProperty("UnitOfMeasure")]
            public string UnitOfMeasure { get; set; }

            [JsonProperty("Classification")]
            public Classification Classification { get; set; }
        }

        public partial class Classification
        {
            [JsonProperty("_domain")]
            public string Domain { get; set; }

            [JsonProperty("__text")]
            public string Text { get; set; }
        }

        public partial class Description
        {
            [JsonProperty("_xml:lang")]
            public string XmlLang { get; set; }

            [JsonProperty("__text")]
            public string Text { get; set; }
        }

        public partial class ItemId
        {
            [JsonProperty("SupplierPartID")]
            public string SupplierPartId { get; set; }

            [JsonProperty("SupplierPartAuxiliaryID")]
            public string SupplierPartAuxiliaryId { get; set; }
        }

        public partial class OrderRequestHeader
        {
            [JsonProperty("Total")]
            public Total Total { get; set; }

            [JsonProperty("ShipTo")]
            public To ShipTo { get; set; }

            [JsonProperty("BillTo")]
            public To BillTo { get; set; }

            [JsonProperty("Contact")]
            public Contact Contact { get; set; }

            [JsonProperty("_orderID")]
            [JsonConverter(typeof(ParseStringConverter))]
            public long OrderId { get; set; }

            [JsonProperty("_orderDate")]
            public DateTimeOffset OrderDate { get; set; }

            [JsonProperty("_type")]
            public string Type { get; set; }

            [JsonProperty("_orderType")]
            public string OrderType { get; set; }
        }

        public partial class To
        {
            [JsonProperty("Address")]
            public Address Address { get; set; }
        }

        public partial class Address
        {
            [JsonProperty("Name")]
            public Description Name { get; set; }

            [JsonProperty("PostalAddress")]
            public PostalAddress PostalAddress { get; set; }

            [JsonProperty("_isoCountryCode")]
            public string IsoCountryCode { get; set; }

            [JsonProperty("_addressID")]
            [JsonConverter(typeof(ParseStringConverter))]
            public long AddressId { get; set; }

            [JsonProperty("Email", NullValueHandling = NullValueHandling.Ignore)]
            public Email Email { get; set; }
        }

        public partial class Email
        {
            [JsonProperty("_name")]
            public string Name { get; set; }

            [JsonProperty("__text")]
            public string Text { get; set; }
        }

        public partial class PostalAddress
        {
            [JsonProperty("DeliverTo")]
            public string DeliverTo { get; set; }

            [JsonProperty("Street")]
            public string Street { get; set; }

            [JsonProperty("City")]
            public string City { get; set; }

            [JsonProperty("State")]
            public string State { get; set; }

            [JsonProperty("PostalCode")]
            [JsonConverter(typeof(ParseStringConverter))]
            public long PostalCode { get; set; }

            [JsonProperty("Country")]
            public Country Country { get; set; }

            [JsonProperty("_name")]
            public string Name { get; set; }
        }

        public partial class Country
        {
            [JsonProperty("_isoCountryCode")]
            public string IsoCountryCode { get; set; }

            [JsonProperty("__text")]
            public string Text { get; set; }
        }

        public partial class Contact
        {
            [JsonProperty("Name")]
            public Description Name { get; set; }

            [JsonProperty("Email")]
            public Email Email { get; set; }

            [JsonProperty("_role")]
            public string Role { get; set; }
        }

        public partial class PO
        {
            public static PO FromJson(string json) => JsonConvert.DeserializeObject<PO>(json, Canonical.Converter.Settings);
        }

        public static class Serialize
        {
            public static string ToJson(this PO self) => JsonConvert.SerializeObject(self, Canonical.Converter.Settings);
        }

        internal static class Converter
        {
            public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
            {
                MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
                DateParseHandling = DateParseHandling.None,
                Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
            };
        }

        internal class ParseStringConverter : JsonConverter
        {
            public override bool CanConvert(Type t) => t == typeof(long) || t == typeof(long?);

            public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
            {
                if (reader.TokenType == JsonToken.Null) return null;
                var value = serializer.Deserialize<string>(reader);
                long l;
                if (Int64.TryParse(value, out l))
                {
                    return l;
                }
                throw new Exception("Cannot unmarshal type long");
            }

            public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
            {
                if (untypedValue == null)
                {
                    serializer.Serialize(writer, null);
                    return;
                }
                var value = (long)untypedValue;
                serializer.Serialize(writer, value.ToString());
                return;
            }

            public static readonly ParseStringConverter Singleton = new ParseStringConverter();
        }
}


    //

