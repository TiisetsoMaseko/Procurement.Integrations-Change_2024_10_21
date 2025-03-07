using MSprocure.Service.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MSprocure.Service.Models.Content.Requests
{
#pragma warning disable IDE1006, CS8616 // Ignore Naming Rule Violations for cXml
    [XmlRoot("ShipNoticeHeader")]
    public class ShipNoticeHeader
    {
        [XmlElement("ServiceLevel", IsNullable = true)]
        public ServiceLevel[] ServiceLevel { get; set; }

        [XmlElement("DocumentReference")]
        public DocumentReference DocumentReference { get; set; }

        [XmlElement("Contact")]
        public Contact[] Contact { get; set; }

        [XmlElement("LegalEntity")]
        public LegalEntity LegalEntity { get; set; }

        //[XmlElement("OrganizationalUnit", IsNullable = true)]
        //public OrganizationalUnit[] OrganizationalUnit { get; set; }

        //[XmlElement("Hazard", IsNullable = true)]
        //public Hazard[] hazard { get; set; }

        [XmlElement("Comments")]
        public Comments[] comments { get; set; }
        //public string Comments { get; set; }

        [XmlElement("termsOfDelivery")]
        public TermsOfDelivery termsOfDelivery { get; set; }

        [XmlElement("termsOfTransport")]
        public TermsOfTransport[] termsOfTransport { get; set; }

        [XmlElement("packaging")]
        public Packaging packaging { get; set; }

        [XmlElement("Extrinsic", IsNullable = true)]
        public Extrinsic[] extrinsic { get; set; }

        //[XmlElement("IdReference", IsNullable = true)]
        //public IdReference[] idReference { get; set; }

        [XmlElement("referenceDocumentInfo", IsNullable = true)]
        public ReferenceDocumentInfo[] referenceDocumentInfo { get; set; }

        [XmlAttribute("shipmentID")]
        public string shipmentID { get; set; }

        //public ShipNoticeHeaderOperation operation;

        [XmlAttribute("noticeDate")]
        public string noticeDate { get; set; }

        [XmlAttribute("shipmentDate")]
        public string shipmentDate { get; set; }

        [XmlAttribute("deliveryDate")]
        public string deliveryDate { get; set; }

        //public ShipNoticeHeaderShipmentType shipmentType;

        //public bool shipmentTypeFieldSpecified;

        //public ShipNoticeHeaderFulfillmentType fulfillmentTypeField;

        //public bool fulfillmentTypeFieldSpecified;

        //public string requestedDeliveryDateField;

        //public ShipNoticeHeaderReason reasonField;

        //public bool reasonFieldSpecified;

        //public ShipNoticeHeaderActivityStepType activityStepTypeField;

        //public bool activityStepTypeFieldSpecified;
    }
    public enum ShipNoticeHeaderShipmentType
    {

        /// <remarks/>
        actual,

        /// <remarks/>
        planned,
    }
    public enum ShipNoticeHeaderOperation
    {

        /// <remarks/>
        @new,

        /// <remarks/>
        delete,

        /// <remarks/>
        update,
    }
    public enum ShipNoticeHeaderFulfillmentType
    {

        /// <remarks/>
        partial,

        /// <remarks/>
        complete,
    }
    public enum ShipNoticeHeaderReason
    {

        /// <remarks/>
        @return,
    }
    public enum ShipNoticeHeaderActivityStepType
    {

        /// <remarks/>
        stockTransfer,

        /// <remarks/>
        stockShippingAdvice,
    }
#pragma warning restore IDE1006, CS8616
}
